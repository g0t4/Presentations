var Order = require('../src/order');
var chai = require('chai');
var expect = chai.expect;
chai.should();

describe('Order tests', function () {
    describe('An order with no itms', function () {
        var orderWithNoItems = new Order([]);

        it('should have an average price of 0', function () {
            var avgPx = orderWithNoItems.avgPx();

            avgPx.should.equal(0);
        })
    })

    describe('An order with 1 item', function () {
        var orderWithOneItem = new Order([
            {
                px: 1,
                qty: 2
            }
        ]);

        it('should have an average price of the item', function () {
            var avgPx = orderWithOneItem.avgPx();

            avgPx.should.equal(1);
        })
    })

    describe('Two orders with non zero price and qty', function () {
        var orderWithTwoItems = new Order([
            {
                px: 2,
                qty: 3
            },
            {
                px: 4,
                qty: 5
            }
        ]);

        it('should have an average price of both itms', function () {
            var avgPx = orderWithTwoItems.avgPx();

            avgPx.should.equal(3.25);
        })
    })
})