namespace AggregateSample
{
	using System;
	using System.Linq;
	using NUnit.Framework;
	using Raven.Client.Document;

	[TestFixture]
	public class Demos
	{
		private const string RavenConnectionString = "http://localhost:8080";

		public static Guid CornProductId = new Guid("AC47D366-C51D-4FE5-8676-7AED25703E61");

		[Test]
		public void SaveTrade()
		{
			var trade = GetTrade();

			using (var documentStore = new DocumentStore {Url = "http://localhost:8080"})
			{
				documentStore.Initialize();
				using (var session = documentStore.OpenSession())
				{
					session.Store(trade);
					session.SaveChanges();
				}
			}
		}

		[Test]
		public void QueryTrade()
		{
			using (var documentStore = new DocumentStore { Url = RavenConnectionString })
			{
				documentStore.Initialize();
				using (var session = documentStore.OpenSession())
				{
					var trades = session
						.Query<StructuredTrade>()
						.ToArray();
				}
			}
		}

		[Test]
		public void DynamicQueryTrade()
		{
			using (var documentStore = new DocumentStore { Url = RavenConnectionString })
			{
				documentStore.Initialize();
				using (var session = documentStore.OpenSession())
				{
					var trades = session
						.Query<StructuredTrade>()
						.Where(s=> s.Id == )
						.ToArray();
				}
			}
		}

		private static StructuredTrade GetTrade()
		{
			var trade = new StructuredTrade();
			var decemberCorn = new Contract(CornProductId, new MonthOfYear(2010, 12));
			var position = -5000;
			var price = 5;
			var swapExpiration = DateTime.Now.Date.AddMonths(1);
			var swap = new Swap(decemberCorn, position, price, swapExpiration);
			trade.AddTrade(swap);

			var payoutAmount = position*1;
			var expirationDate = DateTime.Now.Date;
			var premium = 0.01m;
			var digitalOption = Option.Digital(payoutAmount, expirationDate, Option.OptionType.Call, price, premium);
			trade.AddTrade(digitalOption);

			var optionOnASwap = new Swap(decemberCorn, position, default(decimal), swapExpiration);
			var strike = 6;
			var option = Option.OnSwap(optionOnASwap, expirationDate, Option.OptionType.Call, strike, premium);
			trade.AddTrade(option);

			return trade;
		}
	}
}