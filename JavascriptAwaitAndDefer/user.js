var mongoose = require('mongoose');

var user = new mongoose.Schema({
    name: String,
    _id: Number,
    email: String
});

module.exports = mongoose.model('User', user);

