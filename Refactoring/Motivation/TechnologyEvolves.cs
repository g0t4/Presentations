namespace Refactoring
{
	using System.Collections.Generic;
	using System.Linq;

	public class TechnologyEvolves
	{
		public static void Then()
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
		}

		public static void Now()
		{
			var oddNumbers = AllNumbers()
				.Where(NumberIsOdd)
				.ToList();
		}

		private static IEnumerable<int> AllNumbers()
		{
			return new List<int>();
		}

		private static bool NumberIsOdd(int number)
		{
			return number%2 != 0;
		}
	}
}