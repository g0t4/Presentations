expect = require("node-assertthat").that
Order = require "../order"
mongoose = require "mongoose"
tracking = require "../tracking"
emailer = require "../emailer"
User = require "../user"
step = require 'step'


module.exports = (test) ->
  connect = -> mongoose.connect "mongodb://localhost/awaitdefer"

  lookupOrder = (error)->
    throw error if error
    orderId = 1
    Order.findById orderId, this
    return

  queryEmailDetails = (error, order) ->
    throw error if error
    this.parallel()(null, order)
    User.findById order.customer.id, this.parallel()
    tracking.track order.trackingId, this.parallel()
    return

  sendEmail = (error, order, user, trackingInformation) ->
    throw error if error
    mongoose.connection.close()
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


