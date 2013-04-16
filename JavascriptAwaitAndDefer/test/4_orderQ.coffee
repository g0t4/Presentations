mongodb = require "mongodb"
tracking = require "../tracking"
emailer = require "../emailer"
Q = require "q"

module.exports = (test) ->
  connect = () ->
    return Q.nfcall(mongodb.connect, "mongodb://localhost/awaitdefer")

  db = null
  lookupOrder = (_db)->
    db = _db
    orderId = 1
    return Q.nfcall(db.collection("orders").findOne.bind(db.collection("orders")), orderId)

  queryEmailDetails = (order) ->
    tasks = [
      order,
      Q.nfcall(db.collection("users").findOne.bind(db.collection("users")), order.customer.id),
      Q.nfcall(tracking.track, order.trackingId)
    ]
    return tasks

  sendEmail = (order, user, trackingInformation) ->
    db.close()
    message =
      subject: "Order: " + order.name
      email: user.email
      body: "Tracking: " + trackingInformation
    return Q.nfcall(emailer.sendEmail, message)

  connect()
    .then(lookupOrder)
    .then(queryEmailDetails)
    .spread(sendEmail)
    .fail(test.fail)
    .finally(()->
              db.close() if db?
              test.done())

  return

## My style - separate out steps into named functions for readability
## use callback style for steps, could have embraced promises
## extract parallel tasks (could be inlined too)
