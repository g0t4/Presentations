namespace Samples.OOP
{
	using System.Collections.Generic;
	using NUnit.Framework;

	[TestFixture]
	public class AggregatesGoal : AssertionHelper
	{
		[Test]
		public void CalculateOrderPrice_NoDiscountAndNoTaxes_SumsPrice()
		{
			var order = new Order();
			order.AddItem(new Order.OrderItem {Price = 2});

			var price = order.CalculateOrderPrice();

			Expect(price, Is.EqualTo(2));
		}

		[Test]
		public void CalculateOrderPrice_Discounted_IncludesDiscount()
		{
			var order = new Order {DiscountRate = 0.20m};
			order.AddItem(new Order.OrderItem {Price = 2});

			var price = order.CalculateOrderPrice();

			Expect(price, Is.EqualTo(1.6m));
		}

		[Test]
		public void CalculateOrderPrice_WithTax_IncludesTax()
		{
			var order = new Order {TaxRate = 0.10m};
			order.AddItem(new Order.OrderItem {Price = 2});

			var price = order.CalculateOrderPrice();

			Expect(price, Is.EqualTo(2.2m));
		}

		public class Order
		{
			public Order()
			{
				_Items = new List<OrderItem>();
			}

			public decimal TaxRate { get; set; }
			public decimal DiscountRate { get; set; }

			private readonly IList<OrderItem> _Items;

			public IEnumerable<OrderItem> GetItems()
			{
				return _Items;
			}

			public class OrderItem
			{
				public decimal Price { get; set; }
			}

			public decimal CalculateOrderPrice()
			{
				var total = 0m;
				foreach (var item in GetItems())
				{
					var discount = item.Price*(1 - DiscountRate);
					var taxes = discount*TaxRate;
					total += discount + taxes;
				}
				return total;
			}

			public void AddItem(OrderItem orderItem)
			{
				_Items.Add(orderItem);
			}
		}
	}
}