MongoClient = require "mongodb"
tracking = require "../tracking"
emailer = require "../emailer"

module.exports = (test) ->
  MongoClient.connect "mongodb://localhost/awaitdefer", (error, db) ->
    throw error  if error
    orderId = 1
    db.collection("orders").findOne orderId, (error, order) ->
      throw error  if error
      db.collection("users").findOne order.customer.id, (error, user) ->
        throw error  if error
        db.close()
        tracking.track order.trackingId, (error, trackingInformation) ->
          throw error  if error
          message =
            subject: "Order: " + order.name
            email: user.email
            body: "Tracking: " + trackingInformation

          emailer.sendEmail message, (error) ->
            throw error  if error
            test.done()