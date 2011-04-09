namespace AggregateSample
{
	public class Cash : IUnderlying
	{
		public Cash(decimal amount)
		{
			Amount = amount;
		}

		public decimal Amount { get; protected set; }

		public virtual ITrade ExerciseAt(decimal strike)
		{
			return Clone();
		}

		public virtual IUnderlying Clone()
		{
			return new Cash(Amount = Amount);
		}
	}
}