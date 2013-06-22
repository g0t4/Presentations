var htmlScraper = require('../src/htmlScraper');
var chai = require('chai');
var expect = chai.expect;
var fs = require('fs');
chai.should();

describe('html scraper', function() {

  describe('html with one listing', function() {
    var htmlWithOneListing = fs.readFileSync('test/oneListing.html');
    var listings = htmlScraper.scrapeListings(htmlWithOneListing, 'http://seattle.craigslist.org/', {});

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

    it('parse the url and append the host', function() {
      expect(listings[0].url).to.eql('http://seattle.craigslist.org/see/apa/1234.html');
    });

    it('should have the date', function() {
      var expectedDate = new Date('2001-06-17T05:00:00Z');
      expect(listings[0].publishedAt).to.eql(expectedDate);
    });

    it('should have cities', function() {
      expect(listings[0].cities).to.eql("(SEATTLE)");
    });
  })

  describe('listing with location', function() {
    var listingWithLocation = fs.readFileSync('test/listingWithLocation.html');
    var listings = htmlScraper.scrapeListings(listingWithLocation, 'http://seattle.craigslist.org/', {});
    var listing = listings[0];

    it('should parse the latitude', function() {
      expect(listing.latitude).to.eql('47');
    });

    it('should parse the longitude', function() {
      expect(listing.longitude).to.eql('-100');
    });
  })
})