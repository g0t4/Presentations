MongoClient = require "mongodb"
tracking = require "../tracking"
emailer = require "../emailer"
async = require "async"

module.exports = (test) ->
  connect = (callback) ->
    MongoClient.connect "mongodb://localhost/awaitdefer", callback

  db = null
  lookupOrder = (_db, callback)->
    db = _db
    orderId = 1
    db.collection("orders").findOne orderId, callback
    return

  order = null
  queryEmailDetails = (_order, callback) ->
    order = _order
    tasks =
      user: (cb) ->
        db.collection("users").findOne order.customer.id, cb
      trackingInformation: (cb) ->
        tracking.track order.trackingId, cb

    async.parallel(tasks, callback)
    return

  sendEmail = (details, callback) ->
    db.close()
    message =
      subject: "Order: " + order.name
      email: details.user.email
      body: "Tracking: " + details.trackingInformation
    emailer.sendEmail message, callback
    return

  end = (error) ->
    throw error if error
    test.done()

  async.waterfall([
                    connect
                    lookupOrder
                    queryEmailDetails
                    sendEmail
                  ], end)