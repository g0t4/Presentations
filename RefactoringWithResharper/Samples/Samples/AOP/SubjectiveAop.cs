namespace Samples
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SubjectiveAop : AssertionHelper
    {
        [Test]
        [TestCase("1,000.5", 1000.5)]
        [TestCase("Garbage", null)]
        [TestCase(null, null)]
        public void HowCanWeMakeDoubleParsingReusable(string userInput, double? result)
        {
            double? parsedPrice = null;
            if (userInput != null)
            {
                double value;
                var success = Double.TryParse(userInput, out value);
                if (success)
                {
                    parsedPrice = value;
                }
            }

            Expect(parsedPrice, Is.EqualTo(result));
        }

        [Test]
        public void AnotherUseOfDoubleParsing()
        {
            var inputAge = "21";

            // todo plugin shared approach
            var age = 0;

            Expect(age, Is.EqualTo(21));
        }
    }

    // Before
    // Explain TestCase
    // Explain sharing with second context
    // Explain - write down major refactorings from ReSharper that were used

    // Once done talk about making parsing more robust
}