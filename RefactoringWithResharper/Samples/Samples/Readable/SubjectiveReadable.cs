namespace Samples.Readable
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class SubjectiveReadable : AssertionHelper
    {
        [Test]
        public void Sample()
        {
            var values = new double[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            double result =  0;
            if (values.Count() > 0)
            {
                // Compute the Average      
                double avg  = 0;
                foreach (double value in values)
                {
                    avg += value;
                }
                avg = avg/values.Count();

                // Calc sum of differences squared
                double sum = 0;
                foreach (double d in values) sum += Math.Pow(d - avg, 2);

                // Calc the std dev   
                result = Math.Sqrt(  (sum )/( values.Count() - 1));
             }

            Expect(result, Is.EqualTo(3.02765).Within(0.00001));
        }
    }
}