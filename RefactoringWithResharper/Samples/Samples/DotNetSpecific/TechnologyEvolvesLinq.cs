namespace Samples.DotNetSpecific
{
	using System.Collections.Generic;
	using NUnit.Framework;

	[TestFixture]
	public class TechnologyEvolvesLinq : AssertionHelper
	{
		[Test]
		public void GettingOddNumbersThen()
		{
			var allNumbers = AllNumbers();

			var oddNumbers = new List<int>();
			foreach (var number in allNumbers)
			{
				if (number%2 != 0)
				{
					oddNumbers.Add(number);
				}
			}

			Expect(oddNumbers, Is.EquivalentTo(new[] {1, 3, 5, 7, 9}));
		}

		private static IEnumerable<int> AllNumbers()
		{
			return new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
		}
	}

	// LINQ replace
	// toggle back to for loop too

	// Extract method on IsOdd
	// Replace with method group (alt + enter)
}