expect = require("node-assertthat").that
Order = require "../order"
mongoose = require "mongoose"
tracking = require "../tracking"
emailer = require "../emailer"
User = require "../user"

module.exports = (test) ->
  mongoose.connect "mongodb://localhost/awaitdefer", (error) ->
    throw error  if error
    orderId = 1
    Order.findById orderId, (error, order) ->
      throw error  if error
      User.findById order.customer.id, (error, user) ->
        throw error  if error
        mongoose.connection.close()
        tracking.track order.trackingId, (error, trackingInformation) ->
          throw error  if error
          message =
            subject: "Order: " + order.name
            email: user.email
            body: "Tracking: " + trackingInformation

          emailer.sendEmail message, (error) ->
            throw error  if error
            test.done()