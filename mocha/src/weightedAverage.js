module.exports = function (order, valueSelector, weightSelector) {
    var items = order.items;
    if (items.length == 0) {
        return 0;
    }
    var totalDollars = 0;
    var totalQuantity = 0;
    items.forEach(function (item) {
        var quantity = weightSelector(item);
        totalDollars += valueSelector(item) * quantity;
        totalQuantity += quantity;
    });
    if (totalQuantity === 0) {
        return 0;
    }
    return totalDollars / totalQuantity;
}