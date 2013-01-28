var Order = require('../order');
var mongoose = require('mongoose');
var User = require('../user');

function createOrders(test) {
    mongoose.connect('mongodb://localhost/awaitdefer', function (error, db) {
        var order = new Order({
            _id: 1,
            customer: {
                name: 'Bob Jones',
                id: 123
            },
            trackingId: 'ups-134',
            name: 'Treadmill'
        })
        order.save(function (error) {
            if (error) throw error;
            var bob = new User({
                _id: 123,
                name: 'Bob Jones',
                email: 'bob@jones.com'
            })
            bob.save(function (error) {
                mongoose.connection.close();
                test.done();
            })
        })
    });
}
module.exports.createOrders = createOrders;
