MongoClient = require "mongodb"
tracking = require "../tracking"
emailer = require "../emailer"

module.exports = (test) ->
  await MongoClient.connect "mongodb://localhost/awaitdefer", defer error, db
  throw error if error

  orderId = 1
  await db.collection("orders").findOne orderId, defer error, order
  throw error if error

  await
    db.collection("users").findOne order.customer.id, defer error, user
    tracking.track order.trackingId, defer error2, trackingInformation
  throw error || error2  if error || error2
  db.close()

  message =
    subject: "Order: " + order.name
    email: user.email
    body: "Tracking: " + trackingInformation
  await emailer.sendEmail message, defer error
  throw error  if error
  test.done()