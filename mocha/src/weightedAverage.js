module.exports = function (order) {
    var items = order.items;
    if (items.length == 0) {
        return 0;
    }
    var totalDollars = 0;
    var totalQuantity = 0;
    items.forEach(function (item) {
        totalDollars += item.price * item.quantity;
        totalQuantity += item.quantity;
    });
    if (totalQuantity === 0) {
        return 0;
    }
    return totalDollars / totalQuantity;
}