var mongoose = require('mongoose');

var order = new mongoose.Schema({
    customer: {
        name: String,
        id: Number
    },
    name: String,
    trackingId: String,
    _id: Number
});

module.exports = mongoose.model('Order', order);

