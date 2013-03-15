namespace Samples.Understandable
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ChangeSignatureSamples : AssertionHelper
    {
        [Test]
        public void Sample()
        {
            var a = 1;
            var b = 2;

            Expect(GreaterThan(a, b), Is.False);
            Expect(LessThan(a, b), Is.True);
        }

        public bool GreaterThan(int a, int b)
        {
            return a > b;
        }

        public bool LessThan(int b, int a)
        {
            return a < b;
        }

        // How confusing is this and it happens at times!
        // Explain dialog for changing signature
        // Show sample of delegate via introducing intermediary call

        [Test]
        public void UnusedParameter()
        {
            MethodWithUnusedParameter(1, 2, 3);
        }

        private void MethodWithUnusedParameter(int i, int i1, int i2)
        {
            Console.WriteLine(i + i1);
        }

        // Notice i2 is grayed out
        // Use safe delete on i2
    }
}