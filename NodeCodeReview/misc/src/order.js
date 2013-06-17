function Order(itms) {
    var o = this;
    o.itms = itms || [];
    return o;
}

Order.prototype.avgPx = function () {
    var itms = this.itms;
    if (itms.length == 0) {
        return 0;
    }
    var num = 0;
    var denom = 0;
    for (var i = 0; i < itms.length; i++) {
        num += itms[i].px * itms[i].qty;
        denom += itms[i].qty;
    }
    return num / denom;
}

module.exports = Order;