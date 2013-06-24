module.exports = function (order, valueSelector) {
    var items = order.items;
    if (items.length == 0) {
        return 0;
    }
    var totalDollars = 0;
    var totalQuantity = 0;
    items.forEach(function (item) {
        totalDollars += valueSelector(item) * item.quantity;
        totalQuantity += item.quantity;
    });
    if (totalQuantity === 0) {
        return 0;
    }
    return totalDollars / totalQuantity;
}