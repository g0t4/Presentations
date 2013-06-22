var cheerio = require('cheerio');
var moment = require('moment');
var Url = require('url');

function getPostId(element) {
  return element.attr('data-pid');
}

function getPrice(element) {
  return element.find('.price').text();
}

function getTitle(element) {
  return element.find('a').text().trim();
}

function getUrl(element, url) {
  var relativeUrl = element.find('a').attr('href');
  return Url.resolve(url, relativeUrl);
}

function getListingDetails(element) {
  return element.find('.pnr').text().trim().split(/ *[-\/] */g);
}

function getBedrooms(element) {
  return getListingDetails(element)[1];
}

function getFootage(element) {
  return getListingDetails(element)[2];
}

function getHasPicture(element) {
  return !!element.find('.itempx').text().trim().match('pic');
}

function getDate(element, previousDate) {
  var date = element.find('.itemdate').text().trim();

  if (!date || date == '') {
    var prev = element.prev();
    if (prev && prev[0].name.match(/h/i) && prev.hasClass('ban')) {
      date = prev.text().trim()
    } else {
      date = previousDate;
    }
  }
  if (date && date != '') {
    return moment(date).toDate();
  }
  return undefined;
}

function getCities(element) {
  return element.find('.pnr small').text().trim();
}

function getLatitude(element) {
  return element.attr('data-latitude');
}

function getLongitude(element) {
  return element.attr('data-longitude');
}

exports.scrapeListings = function(text, url, params) {
  var listings = [];
  var previousDate;
  var didBreak = false;

  var $ = cheerio.load(text);
  $('#toc_rows .row').each(function(index, element) {
    element = $(element)

    var postId = getPostId(element);

    if (didBreak || (params.postId && postId === params.postId)) {
      didBreak = true;
      return false;
    }

    var listing = {
      postId: postId,
      title: getTitle(element),
      url: getUrl(element, url),
      price: getPrice(element),
      bedrooms: getBedrooms(element),
      footage: getFootage(element),
      hasPic: getHasPicture(element),
      publishedAt: getDate(element, previousDate),
      cities: getCities(element),
      latitude: getLatitude(element),
      longitude: getLongitude(element)
    };

    if (!previousDate) {
      previousDate = listing.publishedAt;
    }

    listings.push(listing);
  });

  return listings;
}
