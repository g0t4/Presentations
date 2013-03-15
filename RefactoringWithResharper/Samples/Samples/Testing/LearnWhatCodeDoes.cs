namespace Samples.Testing
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class LearnWhatCodeDoes : AssertionHelper
    {
        [Test]
        public void HowToTestFizzBuzz()
        {
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

		// Ctrl + U, R
		// Ctrl + U, D

        // write a test to assert what output contains at each step of algorithm
        // %4 -> contains Derp
        // %6 -> Contains Herp
        // what about both conditions met?
        // what about not?
        // helps us learn and cover code we didn't write and leave behind tests for the next guy!
    }
}