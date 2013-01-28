expect = require("node-assertthat").that
Order = require "../order"
mongoose = require "mongoose"
tracking = require "../tracking"
emailer = require "../emailer"
User = require "../user"

module.exports = (test) ->
  await mongoose.connect "mongodb://localhost/awaitdefer", defer error
  throw error if error

  orderId = 1
  await Order.findById orderId, defer error, order
  throw error if error

  await
    User.findById order.customer.id, defer error, user
    tracking.track order.trackingId, defer error2, trackingInformation
  throw error || error2  if error || error2
  mongoose.connection.close()

  message =
    subject: "Order: " + order.name
    email: user.email
    body: "Tracking: " + trackingInformation
  await emailer.sendEmail message, defer error
  throw error  if error
  test.done()