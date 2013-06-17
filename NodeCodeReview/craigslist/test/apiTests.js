var api = require('..');
var chai = require('chai');
var expect = chai.expect;
chai.should();

describe('integration test of the api', function() {
  it('should fetch 100 listings for seattle', function(done) {
    var seattleListings = 'http://seattle.craigslist.org/see/apa/';
    api.getList(seattleListings, function(error, listings) {
      if (error) throw error;
      expect(listings.length).to.equal(100);
      done();
    });
  })
})