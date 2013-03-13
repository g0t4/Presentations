namespace Samples.Testing
{
    using NUnit.Framework;

    [TestFixture]
    public class Intro : AssertionHelper
    {
        [Test]
        public void AdvantagesOfIntegratedTesting()
        {
            Expect(true);
        }

        // Run this in Nunit GUI
        // Make true
        // Rerun in GUI

        // Repeat with R#
    }
}