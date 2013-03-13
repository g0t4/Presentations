namespace Samples.BoyScout
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ReviewYourCodeWhenDoneGoals : AssertionHelper
    {
        [Test]
        public void TimeSince_WithinLastMinute_ReturnsJustNow()
        {
            Expect(FriendlyGoals.TimeSince(TimeSpan.Parse("00:00:00")), Is.EqualTo("just now"));
            Expect(FriendlyGoals.TimeSince(TimeSpan.Parse("00:00:59")), Is.EqualTo("just now"));
        }

        [Test]
        public void TimeSince_BetweenOneAndTwoMinutes_ReturnsOneMinuteAgo()
        {
            Expect(FriendlyGoals.TimeSince(TimeSpan.Parse("00:01:00")), Is.EqualTo("1 minute ago"));
            Expect(FriendlyGoals.TimeSince(TimeSpan.Parse("00:01:59")), Is.EqualTo("1 minute ago"));
        }

        [Test]
        public void TimeSince_BetweenTwoMinutesAndOneHour_ReturnsMinutesRoundedDown()
        {
            Expect(FriendlyGoals.TimeSince(TimeSpan.Parse("00:02:00")), Is.EqualTo("2 minutes ago"));
            Expect(FriendlyGoals.TimeSince(TimeSpan.Parse("00:59:59")), Is.EqualTo("59 minutes ago"));
        }

        [Test]
        public void TimeSince_BetweenOneHourAndTwoHours_ReturnsOneHourAgo()
        {
            Expect(FriendlyGoals.TimeSince(TimeSpan.Parse("01:00:00")), Is.EqualTo("1 hour ago"));
            Expect(FriendlyGoals.TimeSince(TimeSpan.Parse("01:59:59")), Is.EqualTo("1 hour ago"));
        }

        [Test]
        public void TimeSince_BetweenTwoHoursAndOneDay_ReturnsHours()
        {
            Expect(FriendlyGoals.TimeSince(TimeSpan.Parse("02:00:00")), Is.EqualTo("2 hours ago"));
            Expect(FriendlyGoals.TimeSince(TimeSpan.Parse("23:59:59")), Is.EqualTo("23 hours ago"));
        }

        [Test]
        public void TimeSince_BetweenOneDayAndTwoDays_ReturnsYesterday()
        {
            Expect(FriendlyGoals.TimeSince(TimeSpan.FromDays(1)), Is.EqualTo("yesterday"));
            Expect(FriendlyGoals.TimeSince(TimeSpan.FromDays(2).Subtract(TimeSpan.FromSeconds(1))), Is.EqualTo("yesterday"));
        }

        [Test]
        public void TimeSince_BetweenTwoDaysAndOneWeek_ReturnsDays()
        {
            Expect(FriendlyGoals.TimeSince(TimeSpan.FromDays(2)), Is.EqualTo("2 days ago"));
            Expect(FriendlyGoals.TimeSince(TimeSpan.FromDays(7).Subtract(TimeSpan.FromSeconds(1))), Is.EqualTo("6 days ago"));
        }

        [Test]
        public void TimeSince_GreaterThanOneWeek_ReturnsWeeks()
        {
            Expect(FriendlyGoals.TimeSince(TimeSpan.FromDays(7)), Is.EqualTo("1 weeks ago"));
            Expect(FriendlyGoals.TimeSince(TimeSpan.FromDays(14)), Is.EqualTo("2 weeks ago"));
            Expect(FriendlyGoals.TimeSince(TimeSpan.FromDays(21)), Is.EqualTo("3 weeks ago"));
            Expect(FriendlyGoals.TimeSince(TimeSpan.FromDays(28)), Is.EqualTo("4 weeks ago"));
            Expect(FriendlyGoals.TimeSince(TimeSpan.FromDays(35)), Is.EqualTo("5 weeks ago"));
        }
    }

    public static class FriendlyGoals
    {
        private const int SecondsInAMinute = 60;
        private const int SecondsInTwoMinutes = 120;
        private const int SecondsInAnHour = 3600;
        private const int SecondsInTwoHours = 7200;

        /// <summary>
        ///     Get the time since in human readable terms given a pre calculated timespan from the current time.
        /// </summary>
        public static string TimeSince(TimeSpan elapsedTime)
        {
            var totalDays = (int) elapsedTime.TotalDays;

            var inTheFuture = totalDays < 0;
            if (inTheFuture)
            {
                return null;
            }

            var withinLastWeek = elapsedTime.TotalDays < 7;
            if (withinLastWeek)
            {
                return WithinLastWeek(elapsedTime);
            }

            return string.Format("{0} weeks ago", Math.Ceiling((double) totalDays/7));
            // todo in the future it would be nice to show months/years, but this would probably require the relative dates or suffer from error in # days in month / year/leap years
        }

        private static string WithinLastWeek(TimeSpan elapsedTime)
        {
            var withinLastDay = elapsedTime.TotalDays < 1;
            if (withinLastDay)
            {
                return WithinLastDay(elapsedTime);
            }

            var yesterday = elapsedTime.TotalDays < 2;
            if (yesterday)
            {
                return "yesterday";
            }

            var days = Math.Floor(elapsedTime.TotalDays);
            return string.Format("{0} days ago", days);
        }

        private static string WithinLastDay(TimeSpan elapsedTime)
        {
            if (elapsedTime.TotalSeconds < SecondsInAMinute)
            {
                return "just now";
            }
            if (elapsedTime.TotalSeconds < SecondsInTwoMinutes)
            {
                return "1 minute ago";
            }
            if (elapsedTime.TotalSeconds < SecondsInAnHour)
            {
                var minutes = Math.Floor(elapsedTime.TotalMinutes);
                return string.Format("{0} minutes ago", minutes);
            }
            if (elapsedTime.TotalSeconds < SecondsInTwoHours)
            {
                return "1 hour ago";
            }
            var hours = Math.Floor(elapsedTime.TotalHours);
            return string.Format("{0} hours ago", hours);
        }
    }
}