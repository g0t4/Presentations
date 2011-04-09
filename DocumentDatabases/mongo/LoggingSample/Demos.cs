namespace LoggingSample
{
	using System;
	using System.Linq;
	using System.Threading;
	using log4net;
	using log4net.Config;
	using log4net.Repository.Hierarchy;
	using mongo4log4net;
	using MongoDB.Bson.DefaultSerializer;
	using MongoDB.Bson.DefaultSerializer.Conventions;
	using MongoDB.Driver;
	using NUnit.Framework;

	[TestFixture]
	public class Demos
	{
		private const string _MongoConnectionString = "mongodb://localhost/mongolog";
		/*
		 * db.LogEntry.find({ TimeStamp : {$gte: new Date(2010,10,13,16,10), $lte: new Date(2010,10,13,16,30)}});
		 * db.LogEntry.find({ "MessageObject.Number" : 20});
		 * db.LogEntry.find({ "MessageObject.String" : /thx/});
		 * */

		[Test]
		public void SimpleLogs()
		{
			XmlConfigurator.Configure();
			var log = LogManager.GetLogger("test");

			log.Error(new RandomMessage {Decimal = 1, Number = 10, String = "a thing"});
			log.Error(new RandomMessage {NullableDecimal = 2, Number = 20, String = "another"});
			log.Error(new RandomMessage {Number = 30, String = "okthxbai"});
		}

		[Test]
		public void LogExceptions()
		{
			XmlConfigurator.Configure();
			var log = LogManager.GetLogger("test");
			try
			{
				try
				{
					throw new ArgumentException("oh noes!"); 
				}
				catch (Exception exception)
				{
					throw new Exception("stack trace", exception);
				}
			}
			catch (Exception exception)
			{
				log.Error("or GTFO", exception);
			}
		}

		/*
		 * { 	"Message.Number" : {$gte: 100, $lte: 200 } }
		 * */
		[Test]
		public void LotsOfData()
		{
			BasicConfigurator.Configure();
			var root = (LogManager.GetRepository() as Hierarchy).Root;

			root.RemoveAllAppenders();
			root.AddAppender(new MongoAppender
			                 	{CollectionName = "biglog", MongoConnectionString = _MongoConnectionString});

			var log = LogManager.GetLogger("test");
			foreach(var i in Enumerable.Range(0, 100000))
			{
				log.Error(new RandomMessage { Number = i, String = Guid.NewGuid().ToString() });
			}
		}

		[Test]
		public void Auditing()
		{
			var mongo = MongoServer.Create(_MongoConnectionString);
			MongoAppenderInit.Provider().Init();
			var audits = mongo.GetDatabase("auditing").GetCollection<AuditEntry>("audits");

			var bob = new Employee{ Name = "bob" };
			var promotion = new PromoteEmployee {Level = Employee.EmployeeLevel.God};
	
			var audit = new AuditEntry(promotion, bob) {UserName = "Jane"};
			audits.Insert(audit);
		}

		public class Employee
		{
			public enum EmployeeLevel
			{
				Minion, 
				Manager,
				God
			}

			public EmployeeLevel Level { get; protected set; }
			public string Name { get; set; }

			public void Promote(PromoteEmployee promotion)
			{
				Level = promotion.Level;
			}
		}

		public class PromoteEmployee
		{
			public Employee.EmployeeLevel Level { get; set; }
		}
	}
}