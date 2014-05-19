namespace Samples
{
    using NUnit.Framework;

    [TestFixture]
    public class WeightedAverageSample : AssertionHelper
    {
	    [Test]
        public void WeightedAveragePrice()
        {
            var orders = new[]
                {
                    new {Quantity = 1, Price = 2m},
                    new {Quantity = 2, Price = 3m},
                    new {Quantity = 7, Price = 2m}
                };

            decimal totalQuantity = 0;
            decimal totalDollars = 0;
            foreach (var order in orders)
            {
                totalQuantity += order.Quantity;
                totalDollars += order.Quantity*order.Price;
            }
            var averagePrice = totalDollars/totalQuantity;

            Expect(averagePrice, Is.EqualTo(2.2m));
        }

	    public class Assignment
        {
	        public decimal Weight { get; set; }
	        public int Grade { get; set; }
        }

        [Test]
        public void WeightedAverageGrade()
        {
            var assignments = new[]
                {
                    new Assignment {Grade = 93, Weight = 0.30m},
                    new Assignment {Grade = 88, Weight = 0.50m},
                    new Assignment {Grade = 91, Weight = 0.20m}
                };

            var grade = 0;

            Expect(grade, Is.EqualTo(90.1m));
        }
    }

    // IEnumerable<T> is part of the frameworks, so we can't directly extend it

    // Replace Anonymous Type With Named Class - Order objects
    // Extract Method - WeightedAveragePrice
    // Introduce Parameter - Func valueSelector and weightSelector
    // Make Generic - manually
    // Rename - to generic variable names
    // Reorder signature - parameters
    // Move Method - new class
    // Convert Static to Extension method

    // Use for a different use case
}