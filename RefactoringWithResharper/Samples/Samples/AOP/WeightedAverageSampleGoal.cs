//namespace Samples
//{
//    using System;
//    using System.Collections.Generic;
//    using NUnit.Framework;

//    [TestFixture]
//    public class WeightedAverageSampleGoal : AssertionHelper
//    {
//        public class Order
//        {
//            public int Quantity { get; set; }
//            public decimal Price { get; set; }
//        }

//        [Test]
//        public void WeightedAveragePrice()
//        {
//            var orders = new[]
//                {
//                    new Order {Quantity = 1, Price = 2m},
//                    new Order {Quantity = 2, Price = 3m},
//                    new Order {Quantity = 7, Price = 2m}
//                };

//            var averagePrice = orders.WeightedAverage(o => o.Price, o => o.Quantity);

//            Expect(averagePrice, Is.EqualTo(2.2m));
//        }

//        public class Assignment
//        {
//            public decimal Weight { get; set; }
//            public int Grade { get; set; }
//        }

//        [Test]
//        public void WeightedAverageGrade()
//        {
//            var grades = new[]
//                {
//                    new Assignment {Grade = 93, Weight = 0.30m},
//                    new Assignment {Grade = 88, Weight = 0.50m},
//                    new Assignment {Grade = 91, Weight = 0.20m}
//                };

//            var grade = grades.WeightedAverage(g => g.Grade, g => g.Weight);

//            Expect(grade, Is.EqualTo(90.1m));
//        }
//    }

//    public static class EnumerableExtensions
//    {
//        public static decimal WeightedAverage<T>(this IEnumerable<T> items, Func<T, decimal> valueSelector, Func<T, decimal> weightSelector)
//        {
//            decimal totalWeight = 0;
//            decimal totalWeightedValue = 0;
//            foreach (var item in items)
//            {
//                totalWeight += weightSelector(item);
//                totalWeightedValue += weightSelector(item)*valueSelector(item);
//            }
//            return totalWeightedValue/totalWeight;
//        }
//    }
//}