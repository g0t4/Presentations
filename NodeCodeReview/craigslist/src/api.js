var agent = require('superagent')
  , cheerio = require('cheerio')
  , moment = require('moment')
  , feedParser = require('feedparser')
  , _ = require('underscore');
var htmlScarper = require('./htmlScraper');

cheerio.prototype.make = function(dom, context) {
  if (dom.cheerio) return dom;
  dom = (_.isArray(dom)) ? dom : [dom];
  context || (context = new cheerio())
  return _.extend(context, dom, { length: dom.length, find: context.find });
};

exports.headers = {
  'User-Agent': 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_6_8) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.64 Safari/537.11',
  'Cache-Control': 'no-cache',
  'Pragma': 'no-cache'
}

exports.get = function(url, callback) {
  agent.get(url).buffer(true).set(exports.headers).end(callback);
}

agent.parse['application/xml'] = agent.parse['text'];

// rss feed only updates every hour.
exports.getListRSS = function(url, callback) {
  url = url.replace(/\/$/, '');
  url = url + '/index.rss';

  var result = [];

  exports.get(url, function(response) {
    feedParser.parseString(response.text)
      .on('meta', function(meta) {

      })
      .on('article', function(article) {
        // 1 BD COTTAGE for Rent in CLAYTON (concord / pleasant hill / martinez) $1300 1bd 600sqft
        var title = article.title.split(/\) \$/);

        if (title.length < 2)
          return;

        var specs = title[1].split(' ')
          , price = '$' + specs[0]
          , bedrooms = specs[1]
          , footage = specs[2];

        title = title[0].split('(');

        var cities = title.pop().split(' / ');

        title = title.join('(').trim();

        article.cities = cities;
        article.price = price;
        article.bedrooms = bedrooms;
        article.footage = footage;

        result.push({
          title: title,
          description: article.description,
          publishedAt: article.pubDate,
          url: article.link,
          cities: cities,
          price: price,
          bedrooms: bedrooms,
          footage: footage
        });
      })
      .on('complete', function(feed) {
        if (callback) callback(null, result);
      });
  });
}

exports.getListHTML = function(url, params, callback) {
  if (typeof params == 'function') {
    callback = params;
    params = {};
  }

  exports.get(url, function(response) {
    var result = htmlScarper.scrapeListings(response.text, params);
    if (callback) callback(null, result);
  });
}

exports.getListing = function(url, callback) {
  var listing;

  if (typeof url == 'object') {
    listing = url;
    url = listing.url;
  } else {
    listing = {url: url};
  }

  exports.get(url, function(response) {
    var $ = cheerio.load(response.text);

    var emailLink = $('#replytext').next().find('a')
      , email = emailLink.text().trim()
      , emailUrl = emailLink.attr('href')
      , date = $('.postingdate').text().trim().replace(/^Date: +/, '').replace(/,\s+/, ' ');

    // Date: 2012-11-15,  1:12AM PST
    // Date: 2012-11-09, 10:19PM PST
    listing.publishedAt = moment(date, 'YYYY-MM-DD hh:mmA Z').toDate();

    function extractCoordinates() {
      var coordinates = $('#leaflet')
        , lat = coordinates.attr('data-latitude')
        , lng = coordinates.attr('data-longitude');

      if (lat && lng && parseFloat(lat) != 0) {
        listing.coordinates = {lat: lat, lng: lng};
      }
    }

    function extractImages() {
      var coverImage = $('#iwi').attr('src');

      if (coverImage) {
        var images = [];

        $('#iwt .tn a').each(function(i, node) {
          node = $(node);

          images.push({url: node.attr('href'), thumbUrl: node.find('img').attr('src')});
        });

        listing.coverImage = coverImage;
        listing.images = images;
      }
    }

    function extractMaps(node) {
      node.find('a').each(function(i, link) {
        link = $(link);
        var text = link.text().trim()
          , url = link.attr('href');
        if (text.match('google')) {
          listing.googleMap = url;
        } else if (text.match('yahoo')) {
          listing.yahooMap = url;
        }
      });
    }

    function extractBlurbs(node) {
      node.find('li').each(function(i, item) {
        var text = $(item).text();

        if (text.match('dogs are OK - wooof'))
          listing.dogsAllowed = true;
        if (text.match('cats are OK - purrr'))
          listing.catsAllowed = true;
      });
    }

    var node = $('#userbody > script'), nextNode;
    while (node) {
      if ((nextNode = node.next()) && (nextNode != node)) {
        if (nextNode.hasClass('iw'))
          extractImages();
        else if (nextNode[0].name == 'small')
          extractMaps(nextNode);
        else if (nextNode.hasClass('blurbs')) {
          extractBlurbs(nextNode);
        }
      } else {
        nextNode = null;
      }

      node.remove();
      node = nextNode;
    }

    var text = $('#userbody').text().trim().replace(/\n{2}\n+/, '\n\n');

    extractCoordinates();

    listing.email = email;
    listing.emailUrl = emailUrl;
    listing.text = text;

    if (callback) callback(null, listing);
  });
}

exports.getList = exports.getListHTML;