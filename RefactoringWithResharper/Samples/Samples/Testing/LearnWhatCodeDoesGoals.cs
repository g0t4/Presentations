namespace Samples.Testing
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class LearnWhatCodeDoesGoals : AssertionHelper
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

        // write a test to assert what output contains at each step of algorithm
        // %4 -> contains Derp
        // %6 -> Contains Herp
        // what about both conditions met? is it HerpDerp or DerpHerp, show failed versus passing and learning
        // what about not?
        // helps us learn and cover code we didn't write and leave behind tests for the next guy!
    }
}