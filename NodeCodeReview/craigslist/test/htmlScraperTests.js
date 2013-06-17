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
  })
})