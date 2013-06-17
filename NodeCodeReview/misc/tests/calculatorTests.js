var Calculator = require('../src/calculator');
var chai = require('chai');
var expect = chai.expect;
chai.should();

// what about this?
it('', function () {
    expect(Calculator.add(1, 2)).equals(3);
    expect(Calculator.subtract(1, 2)).equals(-1);
    expect(Calculator.add(-1, 2)).equals(1);
    expect(Calculator.divide(1, 2)).equals(0.5);
    expect(Calculator.subtract(2, 1)).equals(1);
})
