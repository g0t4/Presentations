namespace AggregateSample
{
	using System;
	using System.Collections.Generic;

	public interface IExpire
	{
		IEnumerable<DateTime> ExpirationDates { get; }
	}
}