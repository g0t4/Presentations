var chai = require('chai');
var expect = chai.expect;
var weightedAverage = require('../');

describe('weightedAverage', function () {
    var quantitySelector = function (item) { return item.quantity;};

    describe('price of an order', function () {
        var priceSelector = function (item) { return item.price;};

        describe('with no items', function () {
            it('should return 0', function () {
                var orderWithNoItems = { items: []};

                var weightedAveragePrice = weightedAverage(orderWithNoItems);

                expect(weightedAveragePrice).to.equal(0);
            });
        });

        describe('with one item', function () {
            it('should return the items price', function () {
                var item = { price: 1, quantity: 1 };
                var orderWithOneItem = { items: [item]};

                var weightedAveragePrice = weightedAverage(orderWithOneItem, priceSelector, quantitySelector);

                expect(weightedAveragePrice).to.equal(1);
            });
        });

        describe('with two items with differing non-zero prices and non-zero quantities', function () {
            it('should return the weighted average price', function () {
                var differingItems = [
                    { price: 1, quantity: 2 },
                    { price: 3, quantity: 4 }
                ];
                var differingOrders = { items: differingItems};

                var weightedAveragePrice = weightedAverage(differingOrders, priceSelector, quantitySelector);

                expect(weightedAveragePrice).to.be.closeTo(2.333, 0.001);
            });
        });

        describe('with one zero quantity item', function () {
            it('should return 0', function () {
                var item = { price: 1, quantity: 0 };
                var orderWithZeroQuantityItem = { items: [item]};

                var weightedAveragePrice = weightedAverage(orderWithZeroQuantityItem, priceSelector, quantitySelector);

                expect(weightedAveragePrice).to.equal(0);
            });
        });

    });

    describe('discountedPrice of an order', function () {
        describe('with one item', function () {
            it('should return the items discounted price', function () {
                var item = { discountedPrice: 1, quantity: 1 };
                var orderWithOneItem = { items: [item]};

                var discountedPriceSelector = function (item) { return item.discountedPrice;};
                var weightedAveragePrice = weightedAverage(orderWithOneItem, discountedPriceSelector, quantitySelector);

                expect(weightedAveragePrice).to.equal(1);
            });
        });
    });

    describe('grade of weighted assignments', function () {
        describe('with two assignments', function () {
            it('should return the weighted average assignment grade', function () {
                var assignments = [
                    {grade: 93, weight: 0.3},
                    {grade: 88, weight: 0.7}
                ]
                var student = { items: assignments};

                var gradeSelector = function (assignment) { return assignment.grade;};
                var weightSelector = function (assignment) { return assignment.weight;};
                var weightedAverageGrade = weightedAverage(student, gradeSelector, weightSelector);

                expect(weightedAverageGrade).to.equal(89.5);
            })
        })
    })


});