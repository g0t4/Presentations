"use strict";
var mongodb = require('mongodb');

var db = mongodb.connect('mongodb://localhost/awaitdefer', _);

var order = {
    _id: 1,
    customer: {
        name: 'Bob Jones',
        id: 123
    },
    trackingId: 'ups-134',
    name: 'Treadmill'
};
db.collection('orders').save(order, _);

var bob = {
    _id: 123,
    name: 'Bob Jones',
    email: 'bob@jones.com'
};
db.collection('users').save(bob, _);

db.close();