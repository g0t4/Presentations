namespace Refactoring
{
	using System;
	using NUnit.Framework;

	public class Testing : AssertionHelper
	{
		public static void ProvidesConfidence()
		{
		}

		#region Manual - Run code and view the output

		public static void Main()
		{
			var test = new Testing();
			test.PrintInterest(4000m, 0.05m, 2m);
			Console.ReadKey();
		}

		public void PrintInterest(decimal principal, decimal rate, decimal duration)
		{
			var interest = principal*rate*duration;
			Console.WriteLine("Interest is: " + interest);
		}

		#endregion

		#region Automated

		public decimal CalculateInterest(decimal principal, decimal rate, decimal duration)
		{
			return principal*rate*duration;
		}

		[Test]
		public void CalculateInterest_PositiveRate_AccruesInterest()
		{
			var principal = 5000m;
			var rate = 0.05m;
			var duration = 2m;

			var interest = CalculateInterest(principal, rate, duration);

			Expect(interest, Is.EqualTo(500m));
		}

		#endregion

		#region Creating seams - manual to automated

		/*
		 * Seam busting:
		 *	Use automated tools to avoid testing breaking the seams
		 *	
		 * Steps: (via What (interest) v How (testing it))
		 *	Extract a method for GetInterest
		 *	Inline the print interest method
		 *	Make Main method a test and inherit from AssertionHelper
		 *	Make Console.WriteLine an assertion instead
		 */

		public class IntroductingSeams
		{
			public static void Main()
			{
				var seams = new IntroductingSeams();
				seams.PrintInterest(5000m, 0.05m, 2m);
				Console.ReadKey();
			}

			public void PrintInterest(decimal principal, decimal rate, decimal duration)
			{
				var interest = principal*rate*duration;
				Console.WriteLine("Interest is: " + interest);
			}
		}

		#endregion
	}
}