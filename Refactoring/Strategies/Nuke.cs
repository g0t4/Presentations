namespace Refactoring.Strategies
{
	using System;

	public class Nuke
	{
		public static void UnusedCode()
		{
		}

		public void WeHaveVersionControlForAReason()
		{
			// Compare paying off current loans in one year
			// At some point someone decided to test continuously compounded interest
			var loans = new[]
			            {
			            	new {Principal = 5000m, Rate = 0.05m, Duration = 2},
			            	new {Principal = 15000m, Rate = 0.04m, Duration = 5},
			            	new {Principal = 50000m, Rate = 0.08m, Duration = 7},
			            };
			var totalInterst = 0m;
			foreach (var loan in loans)
			{
				// totalInterst += loan.Principal*loan.Rate*loan.Duration;
				totalInterst += CalculateInterest(loan.Principal, loan.Rate, loan.Duration);
			}

			var totalInterestForOneYear = 0m;
			var duration = 1m;
			foreach (var loan in loans)
			{
				// totalInterst += loan.Principal*loan.Rate*loan.Duration;
				totalInterestForOneYear += ContinuouslyCompoundedInterest(loan.Principal, loan.Rate, duration);
			}

			totalInterst = 0m;
			foreach (var loan in loans)
			{
				// totalInterst += loan.Principal*loan.Rate*loan.Duration;
				totalInterst += ContinuouslyCompoundedInterest(loan.Principal, loan.Rate, loan.Duration);
			}

			var savings = totalInterst - totalInterestForOneYear;
			Console.WriteLine(savings);
		}

		private decimal CalculateInterest(decimal principal, decimal rate, decimal duration)
		{
			return principal*rate*duration;
		}

		private decimal ContinuouslyCompoundedInterest(decimal principal, decimal rate, decimal duration)
		{
			return principal*(decimal) Math.Exp((double) rate*(double) duration);
		}
	}
}