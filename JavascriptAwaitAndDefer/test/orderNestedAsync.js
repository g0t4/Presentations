var expect = require('node-assertthat').that;
var Order = require('../order');
var mongoose = require('mongoose');
var tracking = require('../tracking');
var emailer = require('../emailer');
var User = require('../user');

module.exports = function (test) {
    mongoose.connect('mongodb://localhost/awaitdefer', function (error) {
        if (error) throw error;
        var orderId = 1;
        Order.findById(orderId, function (error, order) {
            if (error) throw error;
            User.findById(order.customer.id, function (error, user) {
                if (error) throw error;
                mongoose.connection.close();
                tracking.track(order.trackingId, function (error, trackingInformation) {
                    if (error) throw error;
                    var message = {
                        subject: 'Order: ' + order.name,
                        email: user.email,
                        body: 'Tracking: ' + trackingInformation
                    };
                    emailer.sendEmail(message, function (error) {
                        if (error) throw error;
                        test.done();
                    });
                });
            });
        });
    });
};