namespace AggregateSample
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class StructuredTrade : ITrade
	{
		public StructuredTrade()
		{
			Id = Guid.NewGuid();
		}

		public Guid Id { get; set; }

		private readonly IList<ITrade> _Trades = new List<ITrade>();

		public IEnumerable<ITrade> Trades
		{
			get { return _Trades; }
		}

		public void AddTrade(ITrade trade)
		{
			_Trades.Add(trade);
			_ExpirationDates = _Trades
				.OfType<IExpire>()
				.SelectMany(s => s.ExpirationDates)
				.ToList();
		}

		private IList<DateTime> _ExpirationDates = new List<DateTime>();

		public virtual IEnumerable<DateTime> ExpirationDates
		{
			get { return _ExpirationDates; }
		}
	}
}