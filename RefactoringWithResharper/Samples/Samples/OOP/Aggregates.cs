namespace Samples.OOP
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Transactions;
	using NUnit.Framework;

	[TestFixture]
	public class Aggregates : AssertionHelper
	{
		private decimal GetOrderPrice(Guid orderId)
		{
			using (new TransactionScope())
			{
				var items = GetOrderItems(orderId);
				var order = GetOrder(orderId);

				var total = 0m;
				foreach (var item in items)
				{
					var discount = item.Price*(1 - order.DiscountRate);
					var taxes = discount*order.TaxRate;
					total += discount + taxes;
				}
				return total;
			}
		}

		private Order GetOrder(Guid orderId)
		{
			return new Order();
		}

		private IEnumerable<OrderItem> GetOrderItems(Guid orderId)
		{
			return Enumerable.Empty<OrderItem>();
		}

		public class Order
		{
			public decimal TaxRate { get; set; }
			public decimal DiscountRate { get; set; }
		}

		public class OrderItem
		{
			public decimal Price { get; set; }
		}
	}

	// How would we test the above?
	// What about the transaction scope and worrying about partial updates of order items?

	// Introduce a layer to load an order as an aggregate (ORM or other)
	// Extract method for calculating price and move to Order class, make non static
	// Add AddItem method

	// Virtue of unit testing aggregates 
	// integration glue is a removed aspect
	// talk about changes to calculation and how it's all encapsulated and HIGHLY testable!
}