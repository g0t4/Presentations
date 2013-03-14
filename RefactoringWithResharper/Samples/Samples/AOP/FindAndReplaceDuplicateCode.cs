namespace Samples
{
    using NUnit.Framework;

    [TestFixture]
    public class FindAndReplaceDuplicateCode : AssertionHelper
    {
        [Test]
        public void Sample()
        {
            var aInput = "1";
            decimal a;
            decimal.TryParse(aInput, out a);

            var bInput = "2";
            decimal b;
            decimal.TryParse(bInput, out b);

            var cInput = "3";
            decimal c;
            decimal.TryParse(cInput, out c);

            Expect(a, Is.EqualTo(1));
            Expect(b, Is.EqualTo(2));
            Expect(c, Is.EqualTo(3));
        }
    }

    public static class Parsers
    {
        public static decimal DecimalTryParse(this string input)
        {
            decimal temp;
            decimal.TryParse(input, out temp);
            return temp;
        }
    }

    // sample catalog online: http://blogs.jetbrains.com/dotnet/2010/06/sample-ssr-pattern-catalog-available-for-download/

    // explain using smart search to do refactorings too
}