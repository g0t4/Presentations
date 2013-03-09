var mongodb = require('mongodb');
var tracking = require('../tracking');
var emailer = require('../emailer');

module.exports = function (test) {
    mongodb.connect('mongodb://localhost/awaitdefer', function (error, db) {
        if (error) throw error;
        var orderId = 1;
        db.collection('orders').findOne(orderId, function (error, order) {
            if (error) throw error;
            db.collection('users').findOne(order.customer.id, function (error, user) {
                if (error) throw error;
                db.close();
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