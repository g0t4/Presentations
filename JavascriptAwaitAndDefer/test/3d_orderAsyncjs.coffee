mongodb = require "mongodb"
tracking = require "../tracking"
emailer = require "../emailer"
async = require "async"

module.exports = (test) ->
  connect = (callback) ->
    mongodb.connect "mongodb://localhost/awaitdefer", callback

  db = null
  lookupOrder = (_db, callback)->
    db = _db
    orderId = 1
    db.collection("orders").findOne orderId, callback

  order = null
  queryEmailDetails = (_order, callback) ->
    order = _order
    tasks =
      user: (callback) -> db.collection("users").findOne order.customer.id, callback
      trackingInformation: (callback) -> tracking.track order.trackingId, callback

    async.parallel(tasks, callback)

  sendEmail = (details, callback) ->
    db.close()
    message =
      subject: "Order: " + order.name
      email: details.user.email
      body: "Tracking: " + details.trackingInformation
    emailer.sendEmail message, callback

  end = (error) ->
    throw error if error
    test.done()

  async.waterfall([
                    connect
                    lookupOrder
                    queryEmailDetails
                    sendEmail
                  ], end)