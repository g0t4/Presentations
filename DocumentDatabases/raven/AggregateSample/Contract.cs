namespace AggregateSample
{
	using System;

	public struct Contract
	{
		public MonthOfYear Month;
		public Guid ProductId;

		public Contract(Guid productId, MonthOfYear month)
		{
			Month = month;
			ProductId = productId;
		}
	}
}