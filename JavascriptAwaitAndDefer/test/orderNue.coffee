expect = require("node-assertthat").that
Order = require "../order"
mongoose = require "mongoose"
tracking = require "../tracking"
emailer = require "../emailer"
User = require "../user"
{flow} = require 'nue'
{as} = require 'nue'

module.exports = (test) ->
  connect = ->
    mongoose.connect "mongodb://localhost/awaitdefer", this.async()

  lookupOrder = ->
    orderId = 1
    Order.findById orderId, this.async(as(1))

  queryEmailDetails = (order) ->
    this.data.order = order
    User.findById order.customer.id, this.async(as(1))
    tracking.track order.trackingId, this.async(as(1))

  sendEmail = (user, trackingInformation) ->
    mongoose.connection.close()
    message =
      subject: "Order: " + this.data.order.name
      email: user.email
      body: "Tracking: " + trackingInformation
    emailer.sendEmail message, this.async()

  end = ->
    throw this.err if this.err
    test.done()

  flow(
    connect
    lookupOrder
    queryEmailDetails
    sendEmail
    end
  )()

# Pros: easily share data between steps, but I'd prefer if this were through parameters in which case you can call this.async(as(1))(null, order) to pass order along with other async callbacks
