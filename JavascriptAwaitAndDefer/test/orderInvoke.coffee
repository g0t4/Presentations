expect = require("node-assertthat").that
Order = require "../order"
mongoose = require "mongoose"
tracking = require "../tracking"
emailer = require "../emailer"
User = require "../user"
invoke = require 'invoke'

module.exports = (test) ->
  connect = (data, callback) -> mongoose.connect "mongodb://localhost/awaitdefer", callback

  lookupOrder = (data, callback)->
    orderId = 1
    Order.findById orderId, callback

  order = null
  queryUser = (data, callback) ->
    order = data
    User.findById order.customer.id, callback

  queryTracking = (data, callback) ->
    tracking.track data.trackingId, callback

  sendEmail = (data, callback) ->
    user = data[0]
    trackingInformation = data[1]
    mongoose.connection.close()
    message =
      subject: "Order: " + order.name
      email: user.email
      body: "Tracking: " + trackingInformation
    emailer.sendEmail message, callback
    return

  rescue = (error) ->
    throw error if error
    test.done()

  end = -> test.done()

  invoke(connect)
    .then(lookupOrder)
    .then(queryUser)
    .and(queryTracking)
    .then(sendEmail)
    .rescue(rescue)
    .end({}, end)


# No easy way to pass data between stages without globals outside of the scope of the invocation chain