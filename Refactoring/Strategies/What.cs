namespace Refactoring.Strategies
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Threading;
	using NUnit.Framework;

	public class What
	{
		public static void VersusHow()
		{
			// It's really about composition and re-use
			// Frameworks like Steve said
		}

		public void FilePaths(string fileName)
		{
			var basePath = Environment.CurrentDirectory.TrimEnd('\\', '/');
			fileName = fileName.TrimStart('\\', '/');
			var path = basePath + "\\temp\\" + fileName;

			// or

			path = Path.Combine(Environment.CurrentDirectory, "temp", fileName);
		}

		[Test]
		public void Threading()
		{
			var threads = new List<Thread>();
			for (var i = 0; i < 10; i++)
			{
				var number = i;
				var thread = new Thread(() => ReallyComplexWork(number));
				threads.Add(thread);
				thread.Start();
			}
			foreach (var thread in threads)
			{
				thread.Join();
			}

			Console.WriteLine();
			// or

			Enumerable
				.Range(0, 10)
				.AsParallel()
				.ForAll(ReallyComplexWork);
		}

		private void ReallyComplexWork(int number)
		{
			Console.WriteLine(number);
		}

		[Test]
		public void WeightedAverage()
		{
			var orders = new[]
			             {
			             	new {Quantity = 1m, Price = 2m},
			             	new {Quantity = 2m, Price = 3m},
			             	new {Quantity = 3m, Price = 4m}
			             };
			decimal totalQuantity = 0;
			decimal totalDollars = 0;
			foreach (var order in orders)
			{
				totalQuantity += order.Quantity;
				totalDollars += order.Quantity*order.Price;
			}
			var averagePrice = totalDollars/totalQuantity;
			Console.WriteLine(averagePrice);

			//or

			averagePrice = orders.WeightedAverage(o => o.Price, o => o.Quantity);
			Console.WriteLine(averagePrice);
		}
	}

	public static class WeightedAverageExtensions
	{
		public static decimal WeightedAverage<T>(this IEnumerable<T> source, Func<T, decimal> valueSelector,
		                                         Func<T, decimal> weightSelector)
		{
			decimal totalWeight = 0;
			decimal totalWeightedValues = 0;
			foreach (var item in source)
			{
				totalWeight += weightSelector(item);
				totalWeightedValues += weightSelector(item)*valueSelector(item);
			}
			return totalWeightedValues/totalWeight;
		}
	}
}