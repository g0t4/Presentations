namespace ConfigurationDataSample
{
	using System;
	using System.Linq;
	using NUnit.Framework;
	using RedBranch.Hammock;

	[TestFixture]
	public class Demos
	{

		// http://localhost:5984/_utils/
	
		private const string _DatabaseName = "translations";

		[Test]
		public void ConfigureTranslations()
		{
			var session = ConnectAndResetDatabase(_DatabaseName).CreateSession(_DatabaseName);

			session.Save(new ProductTranslation
			             	{ForeignId = 1, ProductId = new Guid("148D74AA-393E-4A53-A673-A86F74498256"), PriceTranslation = 100});
			session.Save(new ProductTranslation
			             	{ForeignId = 4, ProductId = new Guid("146C7041-155E-45F1-97B4-1DC6898ACFD9"), PriceTranslation = 10});
			session.Save(new ProductTranslation
			             	{ForeignId = 10, ProductId = new Guid("8CB83EA4-C5A8-46E5-BD86-6F9DB396B242"), PriceTranslation = 1});
			session.Save(new ProductTranslation
			             	{ForeignId = 13, ProductId = new Guid("607B29AA-BDB8-4FFA-AF00-357FC3D5B61D"), PriceTranslation = 1});
		}

		[Test]
		public void QueryAll()
		{
			var session = GetConnection().CreateSession(_DatabaseName);
			var repository = new Repository<ProductTranslation>(session);
			var savedProducts = repository.All();
			savedProducts.ToList().ForEach(Console.WriteLine);
		}

		[Test]
		public void GetByForeignId()
		{
			var session = GetConnection().CreateSession(_DatabaseName);
			var repository = new Repository<ProductTranslation>(session);
			var translation = repository.Where(t => t.ForeignId).Eq(1).First();
			Console.WriteLine(translation);
		}

		private Connection ConnectAndResetDatabase(string databaseName)
		{
			var connection = GetConnection();
			if (connection.ListDatabases().Contains(databaseName))
			{
				connection.DeleteDatabase(databaseName);
			}
			connection.CreateDatabase(databaseName);
			return connection;
		}

		private Connection GetConnection()
		{
			return new CouchProcess(new Uri("http://localhost:5984")).Connect();
		}
	}
}