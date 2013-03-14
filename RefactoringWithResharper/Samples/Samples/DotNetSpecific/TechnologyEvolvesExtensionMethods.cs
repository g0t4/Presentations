namespace Samples.DotNetSpecific
{
	using NUnit.Framework;

	[TestFixture]
	public class TechnologyEvolvesExtensionMethods : AssertionHelper
	{
		[Test]
		public void Sample()
		{
			Expect(StringHelpers.IsNullOrWhitespace(""), Is.True);
			Expect(StringHelpers.IsNullOrWhitespace(null), Is.True);
			Expect(StringHelpers.IsNullOrWhitespace("notempty"), Is.False);
		}
	}

	public static class StringHelpers
	{
		public static bool IsNullOrWhitespace(string input)
		{
			return input == null || input.Trim() == string.Empty;
		}
	}

	// try this manually

	// try this with resharper - convert static to extension method

	// convert back to plain static method
}