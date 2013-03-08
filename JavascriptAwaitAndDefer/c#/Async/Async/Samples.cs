namespace Async
{
    using System;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using NUnit.Framework;

    [TestFixture]
    public class Samples : AssertionHelper
    {
        [Test]
        public void Sync()
        {
            Sync(new Emailer());
        }

        private static void Sync(Emailer emailer)
        {
            var orderId = 1;
            var mongo = new MongoClient("mongodb://localhost");
            var db = mongo.GetServer().GetDatabase("awaitdefer");
            var order = db.GetCollection("orders").FindOneById(orderId);
            var user = db.GetCollection("users").FindOneById(order["customer"].AsBsonDocument["id"]);
            var trackingInformation = Tracking.Track(order["trackingId"].AsString);
            var message = new
                {
                    subject = "Order: " + order["name"],
                    email = user["email"],
                    body = "Tracking: " + trackingInformation
                };
            emailer.SendEmail(message);
        }

        [Test]
        public void SyncHandleExceptions()
        {
            Exception caughtException = null;
            try
            {
                Sync(new FaultyEmailer());
            }
            catch (Exception exception)
            {
                caughtException = exception;
            }
            Console.WriteLine(caughtException);
            Expect(caughtException, Is.Not.Null);
        }

        [Test]
        public async void Async()
        {
            await Async(new Emailer());
        }

        public async Task Async(Emailer emailer)
        {
            var orderId = 1;
            var mongo = new MongoClient("mongodb://localhost");
            var db = mongo.GetServer().GetDatabase("awaitdefer");
            var order = await db.GetCollection("orders").FindOneByIdAsync(orderId);
            var user = await db.GetCollection("users").FindOneByIdAsync(order["customer"].AsBsonDocument["id"]);
            var trackingInformation = await Tracking.TrackAsync(order["trackingId"].AsString);
            var message = new
                {
                    subject = "Order: " + order["name"],
                    email = user["email"],
                    body = "Tracking: " + trackingInformation
                };
            await emailer.SendEmailAsync(message);
        }

        [Test]
        public async void AsyncHandleExceptions()
        {
            Exception caughtException = null;
            try
            {
                await Async(new FaultyEmailer());
            }
            catch (Exception exception)
            {
                caughtException = exception;
            }
            Console.WriteLine(caughtException);
            Expect(caughtException, Is.Not.Null);
        }
    }
}