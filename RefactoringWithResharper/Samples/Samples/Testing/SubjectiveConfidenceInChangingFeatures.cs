namespace Samples.Testing
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SubjectiveConfidenceInChangingFeatures : AssertionHelper
    {
        [Test]
        public void HerpDerp_NumberDivisibleBy4_ContainsDerp()
        {
            Expect(HerpDerp(4).Contains("Herp"));
        }

        [Test]
        public void HerpDerp_NumberDivisibleBy6_ContainsHerp()
        {
            Expect(HerpDerp(6).Contains("Derp"));
        }

        [Test]
        public void HerpDerp_NumberDivisibleBy6and4_ContainsHerpAndDerp()
        {
            Expect(HerpDerp(12).Equals("HerpDerp"));
        }

        [Test]
        public void HerpDerp_NumberNotDivisibleBy6Nor4_ContainsNumber()
        {
            Expect(HerpDerp(3).Equals("3"));
        }

        public string HerpDerp(int i)
        {
            var output = string.Empty;
            if (i%4 == 0) output += "Herp";
            if (i%6 == 0) output += "Derp";
            if (String.IsNullOrEmpty(output))
                output = i.ToString();
            return output;
        }

        // change this to fizz buzz with 3 & 5 and Fizz and Buzz
    }
}