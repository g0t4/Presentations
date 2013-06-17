Option = module.exports = function (parameters) {
    parameters = parameters || {};
    var option = this;
    option.callOrPut = parameters.callOrPut;
    option.strike = parameters.strike || 0;
    option.quantity = parameters.quantity || 0;
    return option;
};

Option.CALL = 'CALL';
Option.PUT = 'PUT';

Option.prototype.isCall = function () {
    return this.callOrPut === Option.CALL;
}

Option.prototype.isPut = function () {
    return !this.isCall();
}

// What is wrong with this code?
function payoutAtExpirationPerUnit(option, underlierPrice) {
    var strike = option.strike;
    var isCallNotInTheMoney = option.isCall() && underlierPrice >= strike;
    var isPutNotInTheMoney = option.isPut() && underlierPrice <= strike;
    var isNotInTheMoney = isCallNotInTheMoney || isPutNotInTheMoney;
    if (isNotInTheMoney) {
        return 0;
    }
    return Math.abs(strike - underlierPrice);
}

Option.prototype.payoutAtExpiration = function (underlierPriceAtExpiration) {
    var option = this;
    var payoutPerUnit = payoutAtExpirationPerUnit(option, underlierPriceAtExpiration);
    return payoutPerUnit * option.quantity;
}
