var cheerio = require('cheerio');
var moment = require('moment');

function getPostId(element) {
  return element.attr('data-pid');
}

function getPrice(element) {
  return element.find('.price').text();
}
function getTitle(element) {
  return element.find('a').text().trim();
}
function getUrl(element) {
  return element.find('a').attr('href');
}
function getListingDetails(element) {
  return element.find('.itemph').text().trim().replace(/ +-$/, '');
}
function getBedrooms(element) {
  return getListingDetails(element).split(/ *[-\/] */g)[1];
}
function getFootage(element) {
  return getListingDetails(element).split(/ *[-\/] */g)[2];
}
function getHasPicture(element) {
  return !!element.find('.itempx').text().trim().match('pic');
}
exports.scrapeListings = function(text, params) {
  var $ = cheerio.load(text);
  var result = [];
  var previousDate;

  var didBreak = false;

  $('#toc_rows .row').each(function(index, element) {
    element = $(element)

    var postId = getPostId(element);

    if (didBreak || (params.postId && postId === params.postId)) {
      didBreak = true;
      return false;
    }

    var date = element.find('.itemdate').text().trim();

    if (!date || date == '') {
      var prev = element.prev();
      if (prev && prev[0].name.match(/h/i) && prev.hasClass('ban')) {
        date = prev.text().trim()
      } else {
        date = previousDate;
      }
    }

    var listing = {
      postId: postId,
      title: getTitle(element),
      url: getUrl(element),
      price: getPrice(element),
      bedrooms: getBedrooms(element),
      footage: getFootage(element),
      hasPic: getHasPicture(element)
    };

    if (date && date != '') {
      listing.publishedAt = moment(date).toDate();

      if (!previousDate) {
        previousDate = listing.publishedAt;
      }
    }

    result.push(listing);
  });
  return result;
}
