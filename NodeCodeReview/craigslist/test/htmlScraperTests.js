var htmlScraper = require('../src/htmlScraper');
var chai = require('chai');
var expect = chai.expect;
var fs = require('fs');
chai.should();

describe('html scraper', function() {
  describe('html with one listing', function() {
    var htmlWithOneListing = fs.readFileSync('test/oneListing.html');
    var listings = htmlScraper.scrapeListings(htmlWithOneListing, {});

    it('should have one listing', function() {
      expect(listings.length).to.equal(1);
    })

    it('should have the price', function() {
      expect(listings[0].price).to.equal('$50000');
    });

    it('should have the postId', function() {
      expect(listings[0].postId).to.equal('1234');
    });

    it('should have the title', function() {
      expect(listings[0].title).to.equal('OMG THE BEST APARTMENT EVAR NO LIES!!!');
    });

    it('should have the url', function() {
      expect(listings[0].url).to.equal('/see/apa/1234.html');
    });

    it('should have the date', function() {
      var expectedDate = new Date('2001-06-17T05:00:00Z');
      expect(listings[0].publishedAt).to.eql(expectedDate);
    });

  })
})