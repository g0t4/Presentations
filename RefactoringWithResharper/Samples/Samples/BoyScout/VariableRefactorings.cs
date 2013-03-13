namespace Samples.BoyScout
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class VariableRefactorings : AssertionHelper
    {
        public string Name { get; set; }

        [Test]
        public void Sample()
        {
            var area = 3.14159*Math.Pow(2, 2);
        }

        // introduce field
        // inline field

        // introduce variable
        // inline variable

        // extract method
        // introduce parameter for radius

        // auto prop to backing prop (alt + enter)
        // convert to auto prop (alt + enter)

        // encapsulate field (alt + enter)
    }
}