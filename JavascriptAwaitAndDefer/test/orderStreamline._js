var mongodb = require('mongodb');
var tracking = require('../tracking');
var emailer = require('../emailer');

module.exports = function (test, _) {
    var db = mongodb.connect('mongodb://localhost/awaitdefer', _);
    try {
        var orderId = 1;
        var order = db.collection('orders').findOne(orderId, _);
        var getUser = (function (_) { return db.collection('users').findOne(order.customer.id, _); })();
        var getTracking = (function (_) { return tracking.track(order.trackingId, _); })();
        var message = {
            subject: 'Order: ' + order.name,
            email: getUser(_).email,
            body: 'Tracking: ' + getTracking(_)
        };
        emailer.sendEmail(message, _);
    }
    catch (exception) {
        test.fail(exception);
    }
    finally {
        db.close();
        test.done();
    }
}
