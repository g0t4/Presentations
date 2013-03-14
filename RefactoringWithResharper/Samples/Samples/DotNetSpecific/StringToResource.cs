namespace Samples.DotNetSpecific
{
	using System;
	using NUnit.Framework;

	[TestFixture]
	public class StringToResource : AssertionHelper
	{
		[Test]
		public void Sample()
		{
			var verbiage = "Blah de dah";
			Console.WriteLine(verbiage);
		}
	}
}