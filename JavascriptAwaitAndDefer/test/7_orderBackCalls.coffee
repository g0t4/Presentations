mongodb = require "mongodb"
tracking = require "../tracking"
emailer = require "../emailer"

# All of this is hypothetical at this point and is very likely to not get added

module.exports = (test) ->
  (error, db) <- mongodb.connect "mongodb://localhost/awaitdefer"
  throw error if error

  orderId = 1
  (error, order) <- await db.collection("orders").findOne orderId
  throw error if error

  (error, user) <- db.collection("users").findOne order.customer.id
  throw error if error

  (error, trackingInformation) <- tracking.track order.trackingId
  throw error if error
  db.close()

  message =
    subject: "Order: " + order.name
    email: user.email
    body: "Tracking: " + trackingInformation
  (error) <- await emailer.sendEmail message
  throw error if error

  test.done()