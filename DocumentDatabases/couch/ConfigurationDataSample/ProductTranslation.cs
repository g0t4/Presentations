namespace ConfigurationDataSample
{
	using System;

	public class ProductTranslation
	{
		public int ForeignId { get; set; }
		public Guid ProductId { get; set; }
		public decimal PriceTranslation { get; set; }

		public override string ToString()
		{
			return string.Format("ForeignId: {0}, ProductId: {1}, PriceTranslation: {2}", ForeignId, ProductId, PriceTranslation);
		}
	}
}