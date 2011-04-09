namespace mongo4log4net
{
	using System;
	using MongoDB.Bson.DefaultSerializer;
	using MongoDB.Bson.DefaultSerializer.Conventions;

	public class MongoAppenderInit
	{
		public static Func<MongoAppenderInit> Provider { get; set; }

		static MongoAppenderInit()
		{
			Provider = () => new MongoAppenderInit();
		}

		public virtual void Init()
		{
			BsonClassMap.UnregisterClassMap(typeof(Exception));
			var profile = new ConventionProfile();
			profile.SetMemberFinderConvention(new LoggingMemberFinderConvention());
			BsonClassMap.RegisterClassMap(new ExceptionMap());
			BsonClassMap.RegisterClassMap(new LocationInformationMap());
			BsonClassMap.RegisterConventions(profile, t => true);
		}
	}
}