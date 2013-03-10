mongodb = require("mongodb")
tracking = require("../tracking")
emailer = require("../emailer")

module.exports = (test, _) ->
  db = mongodb.connect("mongodb://localhost/awaitdefer", _)
  try
    orderId = 1
    order = db.collection("orders").findOne(orderId, _)
    userTask = ((_) -> db.collection("users").findOne(order.customer.id, _))()
    trackingTask = ((_) -> tracking.track(order.trackingId, _))()
    message =
      subject: "Order: " + order.name
      email: userTask(_).email
      body: "Tracking: " + trackingTask(_)

    emailer.sendEmail(message, _)
  catch exception
    test.fail(exception)
  finally
    db.close()
    test.done()