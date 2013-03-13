namespace Samples.Understandable
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class UnusedCodeSampleGoal : AssertionHelper
    {
        [Test]
        public void Sample()
        {
            var ageCalculator = new AgeCalculations(() => new DateTime(2012, 1, 1));
            var birthDate = new DateTime(2001, 2, 1);

            var age = ageCalculator.YearsOld(birthDate);

            Expect(age, Is.EqualTo(10));
        }

        public class AgeCalculations
        {
            private readonly Func<DateTime> _CurrentProvider;

            public AgeCalculations(Func<DateTime> currentProvider)
            {
                _CurrentProvider = currentProvider;
            }

            public decimal YearsOld(DateTime birthDate)
            {
                var today = _CurrentProvider();
                var age = today.Year - birthDate.Year;
                if (birthDate > today.AddYears(-age)) age--;
                return age;
            }
        }
    }
}