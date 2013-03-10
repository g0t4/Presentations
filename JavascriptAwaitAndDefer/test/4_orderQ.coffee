mongodb = require "mongodb"
tracking = require "../tracking"
emailer = require "../emailer"
Q = require "q"

module.exports = (test) ->
  connect = (callback) ->
    return mongodb.connect "mongodb://localhost/awaitdefer", callback

  db = null
  lookupOrder = (_db, callback)->
    db = _db
    orderId = 1
    db.collection("orders").findOne orderId, callback
    return

  getUser = (order, cb) ->
    db.collection("users").findOne order.customer.id, cb

  getTrackingInformation = (order, cb) ->
    tracking.track order.trackingId, cb

  sendEmail = (order, user, trackingInformation, callback) ->
    db.close()
    message =
      subject: "Order: " + order.name
      email: user.email
      body: "Tracking: " + trackingInformation
    emailer.sendEmail message, callback
    return

  Q.nfcall(connect)
    .then(Q.nfbind(lookupOrder))
    .then((order) ->
           [order, Q.nfcall(getUser, order), Q.nfcall(getTrackingInformation, order)])
    .spread(Q.nfbind(sendEmail))
    .fail(test.fail)
    .then(()->
           test.done())
