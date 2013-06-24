var chai = require('chai');
var expect = chai.expect;
var weightedAverage = require('../');
require('should');

suite('weightedAverage - suite');

test('price of an order with no items should return 0', function () {
    var orderWithNoItems = { items: []};

    var weightedAveragePrice = weightedAverage(orderWithNoItems);

    weightedAveragePrice.should.equal(0);
});
