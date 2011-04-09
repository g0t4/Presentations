namespace AggregateSample
{
	using System;
	using System.Collections.Generic;

	public class Option : IUnderlying, IExpire
	{
		protected Option(IUnderlying underlying, DateTime expirationDate, OptionType callOrPut, decimal strike,
		                 decimal premium)
		{
			Underlying = underlying;
			ExpirationDate = expirationDate;
			CallOrPut = callOrPut;
			Strike = strike;
			Premium = premium;
		}

		protected Option()
		{
		}

		public enum OptionType
		{
			Call,
			Put
		}

		public static Option OnSwap(Swap swap, DateTime expirationDate, OptionType callOrPut, decimal strike, decimal premium)
		{
			return new Option(swap, expirationDate, callOrPut, strike, premium);
		}

		public static Option Digital(decimal amount, DateTime expirationDate, OptionType callOrPut, decimal strike,
		                             decimal premium)
		{
			var underlying = new Cash(amount);
			return new Option(underlying, expirationDate, callOrPut, strike, premium);
		}

		public OptionType CallOrPut { get; set; }

		public IUnderlying Underlying { get; protected set; }

		public DateTime ExpirationDate { get; protected set; }

		public decimal Strike { get; protected set; }

		public decimal Premium { get; protected set; }

		public virtual ITrade ExerciseAt(decimal strike)
		{
			var option = CloneOption();
			option.Premium = strike;
			return option;
		}

		public virtual IUnderlying Clone()
		{
			return CloneOption();
		}

		private Option CloneOption()
		{
			return new Option(Underlying.Clone(), ExpirationDate, CallOrPut, Strike, Premium);
		}

		public virtual IEnumerable<DateTime> ExpirationDates
		{
			get
			{
				var expirations = new List<DateTime>();
				if (Underlying is IExpire)
				{
					expirations.AddRange((Underlying as IExpire).ExpirationDates);
				}
				if (!expirations.Contains(ExpirationDate))
				{
					expirations.Add(ExpirationDate);
				}
				return expirations;
			}
		}
	}
}