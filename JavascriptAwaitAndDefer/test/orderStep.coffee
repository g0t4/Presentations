mongodb = require "mongodb"
tracking = require "../tracking"
emailer = require "../emailer"
step = require 'step'

module.exports = (test) ->
  connect = ->
    mongodb.connect "mongodb://localhost/awaitdefer", this

  db = null
  lookupOrder = (error, _db)->
    throw error if error
    db = _db
    orderId = 1
    db.collection("orders").findOne orderId, this
    return

  queryEmailDetails = (error, order) ->
    throw error if error
    this.parallel()(null, order)
    db.collection("users").findOne order.customer.id, this.parallel()
    tracking.track order.trackingId, this.parallel()
    return

  sendEmail = (error, order, user, trackingInformation) ->
    throw error if error
    db.close()
    message =
      subject: "Order: " + order.name
      email: user.email
      body: "Tracking: " + trackingInformation
    emailer.sendEmail message, this
    return

  end = (error) ->
    throw error if error
    test.done()

  step(
        connect
        lookupOrder
        queryEmailDetails
        sendEmail
        end
      )

###
Cons
  No error handling
  No state sharing

Pros

###
