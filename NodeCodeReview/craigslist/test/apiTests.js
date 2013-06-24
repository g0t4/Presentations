var api = require('..');
var chai = require('chai');
var expect = chai.expect;
chai.should();

describe('integration test of the api', function() {
  it('should fetch 100 listings for seattle', function(done) {
    var seattleListings = 'http://seattle.craigslist.org/search/apa/see?maxAsk=250&srchType=A';
    api.getList(seattleListings, function(error, listings) {
      if (error) throw error;
      expect(listings.length >= 100);
      done();
    });
  })
})