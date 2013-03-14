namespace Samples.DotNetSpecific
{
	using System.Collections.Generic;
	using System.Linq;
	using NUnit.Framework;

	[TestFixture]
	public class TechnologyEvolvesLinqGoals : AssertionHelper
	{
		[Test]
		public void GettingOddNumbersThen()
		{
			var allNumbers = AllNumbers();
			
			var oddNumbers = allNumbers
				.Where(IsOdd)
				.ToList();

			Expect(oddNumbers, Is.EquivalentTo(new[] {1, 3, 5, 7, 9}));
		}

		private static bool IsOdd(int number)
		{
			return number%2 != 0;
		}

		private static IEnumerable<int> AllNumbers()
		{
			return new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
		}
	}
}