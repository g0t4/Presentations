using System;
using System.Collections.Generic;

namespace AggregateSample
{
	public class StructuredTrade : ITrade
	{
		public StructuredTrade()
		{
			Id = Guid.NewGuid();
			Trades = new List<ITrade>();
		}

		public Guid Id { get; set; }

		public IList<ITrade> Trades { get; protected set; }

		public void AddTrade(ITrade trade)
		{
			Trades.Add(trade);
		}
	}
}