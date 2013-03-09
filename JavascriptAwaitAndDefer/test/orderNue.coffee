MongoClient = require "mongodb"
tracking = require "../tracking"
emailer = require "../emailer"
{flow} = require 'nue'
{as} = require 'nue'

module.exports = (test) ->
  connect = ->
    MongoClient.connect "mongodb://localhost/awaitdefer", this.async(as(1))

  lookupOrder = (db) ->
    orderId = 1
    this.data.db = db
    db.collection("orders").findOne orderId, this.async(as(1))

  queryEmailDetails = (order) ->
    this.data.order = order
    this.data.db.collection("orders").findOne order.customer.id, this.async(as(1))
    tracking.track order.trackingId, this.async(as(1))

  sendEmail = (user, trackingInformation) ->
    this.data.db.close()
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
