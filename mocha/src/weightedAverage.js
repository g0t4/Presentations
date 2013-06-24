module.exports = function (order, valueSelector, weightSelector) {
    var items = order.items;
    if (items.length == 0) {
        return 0;
    }
    var totalValueTimesWeight = 0;
    var totalWeight = 0;
    items.forEach(function (item) {
        var weight = weightSelector(item);
        totalValueTimesWeight += valueSelector(item) * weight;
        totalWeight += weight;
    });
    if (totalWeight === 0) {
        return 0;
    }
    return totalValueTimesWeight / totalWeight;
}