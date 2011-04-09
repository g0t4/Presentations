namespace mongo4log4net
{
	using log4net.Core;
	using MongoDB.Bson.DefaultSerializer;

	public class LocationInformationMap : BsonClassMap<LocationInfo>
	{
		public LocationInformationMap()
		{
			MapProperty(c => c.ClassName);
			MapProperty(c => c.LineNumber);
			MapProperty(c => c.MethodName);
			MapProperty(c => c.FileName);
		}
	}
}