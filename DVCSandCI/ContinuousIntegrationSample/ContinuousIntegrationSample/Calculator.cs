namespace ContinuousIntegrationSample
{
	using NUnit.Framework;

	public class Calculator
	{
		public decimal Add(int a, int b)
		{
			return a + b;
		}
	}

	[TestFixture]
	public class CalculatorTests : AssertionHelper
	{
		[Test]
		public void Add_TwoPositiveIntegers_ReturnsExpectedResult()
		{
			var a = 5;
			var b = 4;
			var expectedResult = 10;
			var calculator = new Calculator();

			var actualResult = calculator.Add(a, b);

			Expect(actualResult, Is.EqualTo(expectedResult));
		}
	}
}