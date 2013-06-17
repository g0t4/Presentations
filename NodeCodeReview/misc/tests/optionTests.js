var Option = require('../src/option');
var chai = require('chai');
var expect = chai.expect;
chai.should();

describe('option tests', function () {
    describe('payout at expiration', function () {

        var call = new Option({
            callOrPut: Option.CALL,
            strike: 5.00,
            premium: 0.10,
            quantity: 1000
        });

        // What is wrong with this code?
        describe('call in the money', function () {
            it('should have a payout', function () {
                var underlierPriceInTheMoney = 4;

                var payout = call.payoutAtExpiration(underlierPriceInTheMoney);

                expect(payout).to.equal(1000);
            })
        })

        describe('call out of the money', function () {
            it('should not have a payout', function () {
                var underlierPriceOutOfTheMoney = 6;

                var payout = call.payoutAtExpiration(underlierPriceOutOfTheMoney);

                expect(payout).to.equal(0);
            })
        })

        var put = new Option({
            callOrPut: Option.PUT,
            strike: 5.00,
            premium: 0.10,
            quantity: 1000
        });

        describe('put in the money', function () {
            it('should have a payout', function () {
                var underlierPriceInTheMoney = 6;

                var payout = put.payoutAtExpiration(underlierPriceInTheMoney);

                expect(payout).to.equal(1000);
            })
        })

        describe('put out of the money', function () {
            it('should not have a payout', function () {
                var underlierPriceOutOfTheMoney = 4;

                var payout = put.payoutAtExpiration(underlierPriceOutOfTheMoney);

                expect(payout).to.equal(0);
            })
        })
    })
})
