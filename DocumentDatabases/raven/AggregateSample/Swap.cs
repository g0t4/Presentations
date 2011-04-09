namespace AggregateSample
{
	using System;
	using System.Collections.Generic;

	public class Swap : IUnderlying, IExpire
	{
		public Swap(Contract contract, decimal position, decimal price, DateTime expiration)
		{
			Contract = contract;
			Position = position;
			Price = price;
		}

		public Contract Contract { get; protected set; }
		public decimal Position { get; protected set; }
		public decimal Price { get; protected set; }
		public DateTime ExpirationDate { get; protected set; }

		public virtual ITrade ExerciseAt(decimal strike)
		{
			var swap = CloneSwap();
			swap.Price = strike;
			return swap;
		}

		public virtual IUnderlying Clone()
		{
			return CloneSwap();
		}

		private Swap CloneSwap()
		{
			return new Swap(Contract, Position, Price, ExpirationDate);
		}

		public virtual IEnumerable<DateTime> ExpirationDates
		{
			get { return new[] {ExpirationDate}; }
		}
	}
}