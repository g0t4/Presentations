var cheerio = require('cheerio');
var moment = require('moment');

function getPostId(element) {
  return element.attr('data-pid');
}

exports.scrapeListings = function(text, params) {
  var $ = cheerio.load(text);
  var result = [];
  var date;
  var previousDate;

  var didBreak = false;

  $('#toc_rows .row').each(function(index, element) {
    element = $(element)

    var id = getPostId(element);

    if (didBreak || (params.postId && id === params.postId)) {
      didBreak = true;
      return false;
    }

    date = element.find('.itemdate').text().trim();

    if (!date || date == '') {
      var prev = element.prev();
      if (prev && prev[0].name.match(/h/i) && prev.hasClass('ban')) {
        date = prev.text().trim()
      } else {
        date = previousDate;
      }
    }

    var item = {};
    if (date && date != '') {
      item.publishedAt = moment(date).toDate();

      if (!previousDate) {
        previousDate = item.publishedAt;
      }
    }

    var offer = element.find('.itemph').text().trim().replace(/ +-$/, '');
    var offerArray = offer.split(/ *[-\/] */g);
    var bedrooms = offerArray[1];
    var footage = offerArray[2];
    var hasPic = !!element.find('.itempx').text().trim().match('pic');

    item.postId = id;

    var link = element.find('a');
    item.title = link.text().trim();
    item.url = link.attr('href');

    item.price = element.find('.price').text();
    if (bedrooms) item.bedrooms = bedrooms;
    if (footage) item.footage = footage;
    item.hasPic = hasPic;

    result.push(item);
  });
  return result;
}
