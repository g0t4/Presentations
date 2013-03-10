mongodb = require "mongodb"
tracking = require "../tracking"
emailer = require "../emailer"
invoke = require "invoke"

module.exports = (test) ->
  connect = (data, callback) ->
    mongodb.connect "mongodb://localhost/awaitdefer", callback

  db = null
  lookupOrder = (data, callback)->
    db = data
    orderId = 1
    db.collection("orders").findOne orderId, callback

  order = null
  queryUser = (data, callback) ->
    order = data
    db.collection("users").findOne order.customer.id, callback

  queryTracking = (data, callback) ->
    tracking.track data.trackingId, callback

  sendEmail = (data, callback) ->
    user = data[0]
    trackingInformation = data[1]
    db.close()
    message =
      subject: "Order: " + order.name
      email: user.email
      body: "Tracking: " + trackingInformation
    emailer.sendEmail message, callback
    return

  rescue = (error) ->
    throw error if error
    test.done()

  end = ->
    test.done()

  invoke(connect)
    .then(lookupOrder)
    .then(queryUser)
    .and(queryTracking)
    .then(sendEmail)
    .rescue(rescue)
    .end({}, end)