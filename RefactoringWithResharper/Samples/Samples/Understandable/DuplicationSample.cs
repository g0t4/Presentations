namespace Samples.Understandable
{
    using NUnit.Framework;

    [TestFixture]
    public class DuplicationSample : AssertionHelper
    {
        [Test]
        public void Sample()
        {
            var circumference = CalculateCircumference(1.5);
            var area = CalculateArea(1.5);

            Expect(circumference, Is.EqualTo(9.42).Within(0.01));
            Expect(area, Is.EqualTo(7.065).Within(0.01));
        }

        private double CalculateArea(double radius)
        {
            return 3.14*radius*radius;
        }

        private double CalculateCircumference(double radius)
        {
            return 2*3.14*radius;
        }

        // Introduce field for pi - replace both occurences
        // Introduce variable for radius - replace both occurences
    }
}