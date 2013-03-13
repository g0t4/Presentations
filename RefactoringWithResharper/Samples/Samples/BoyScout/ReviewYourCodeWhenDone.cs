namespace Samples.BoyScout
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ReviewYourCodeWhenDone : AssertionHelper
    {
        [Test]
        public void TimeSince_WithinLastMinute_ReturnsJustNow()
        {
            Expect(TimeSpan.Parse("00:00:00").TimeSince(), Is.EqualTo("just now"));
            Expect(TimeSpan.Parse("00:00:59").TimeSince(), Is.EqualTo("just now"));
        }

        [Test]
        public void TimeSince_BetweenOneAndTwoMinutes_ReturnsOneMinuteAgo()
        {
            Expect(TimeSpan.Parse("00:01:00").TimeSince(), Is.EqualTo("1 minute ago"));
            Expect(TimeSpan.Parse("00:01:59").TimeSince(), Is.EqualTo("1 minute ago"));
        }

        [Test]
        public void TimeSince_BetweenTwoMinutesAndOneHour_ReturnsMinutesRoundedDown()
        {
            Expect(TimeSpan.Parse("00:02:00").TimeSince(), Is.EqualTo("2 minutes ago"));
            Expect(TimeSpan.Parse("00:59:59").TimeSince(), Is.EqualTo("59 minutes ago"));
        }

        [Test]
        public void TimeSince_BetweenOneHourAndTwoHours_ReturnsOneHourAgo()
        {
            Expect(TimeSpan.Parse("01:00:00").TimeSince(), Is.EqualTo("1 hour ago"));
            Expect(TimeSpan.Parse("01:59:59").TimeSince(), Is.EqualTo("1 hour ago"));
        }

        [Test]
        public void TimeSince_BetweenTwoHoursAndOneDay_ReturnsHours()
        {
            Expect(TimeSpan.Parse("02:00:00").TimeSince(), Is.EqualTo("2 hours ago"));
            Expect(TimeSpan.Parse("23:59:59").TimeSince(), Is.EqualTo("23 hours ago"));
        }

        [Test]
        public void TimeSince_BetweenOneDayAndTwoDays_ReturnsYesterday()
        {
            Expect(TimeSpan.FromDays(1).TimeSince(), Is.EqualTo("yesterday"));
            Expect(TimeSpan.FromDays(2).Subtract(TimeSpan.FromSeconds(1)).TimeSince(), Is.EqualTo("yesterday"));
        }

        [Test]
        public void TimeSince_BetweenTwoDaysAndOneWeek_ReturnsDays()
        {
            Expect(TimeSpan.FromDays(2).TimeSince(), Is.EqualTo("2 days ago"));
            Expect(TimeSpan.FromDays(7).Subtract(TimeSpan.FromSeconds(1)).TimeSince(), Is.EqualTo("6 days ago"));
        }

        [Test]
        public void TimeSince_GreaterThanOneWeek_ReturnsWeeks()
        {
            Expect(TimeSpan.FromDays(7).TimeSince(), Is.EqualTo("1 weeks ago"));
            Expect(TimeSpan.FromDays(14).TimeSince(), Is.EqualTo("2 weeks ago"));
            Expect(TimeSpan.FromDays(21).TimeSince(), Is.EqualTo("3 weeks ago"));
            Expect(TimeSpan.FromDays(28).TimeSince(), Is.EqualTo("4 weeks ago"));
            Expect(TimeSpan.FromDays(35).TimeSince(), Is.EqualTo("5 weeks ago"));
        }
    }

    public static class Friendly
    {
        /// <summary>
        ///     Get the time since in human readable terms given a pre calculated timespan from the current time.
        /// </summary>
        public static string TimeSince(this TimeSpan elapsedTime)
        {
            // 2.
            // Get total number of days elapsed.
            var dayDiff   = (int) elapsedTime.TotalDays;

            // 3.
            // Get total number of seconds elapsed.
            var secDiff = (int) elapsedTime.TotalSeconds;

            // 4.
            // Don't allow out of range values.
            if   (dayDiff < 0)
            {
                return null;
            }

            // 5.
            // Handle same-day times.
             if (dayDiff == 0)
             {
                // A.
                // Less than one minute ago.
                if (secDiff < 60)
                {
                     return "just now";
                }
                // B.
                // Less than 2 minutes ago.
                if (secDiff < 120)
                {
                    return "1 minute ago";
                }
                // C.
                // Less than one hour ago.
                if (secDiff < 3600 )
                {
                      return 
                          string.Format("{0} minutes ago",  Math.Floor((double) secDiff/60));
                }
                // D.
                // Less than 2 hours ago.
                if ( secDiff < 7200)
                {
                    return "1 hour ago";
                }
                // E.
                // Less than one day ago.
                if (secDiff < 86400)
                {
                     return string.Format("{0} hours ago",   Math.Floor((double) secDiff/3600));
                }
             }
            // 6.
            // Handle previous days.
            if ( dayDiff == 1)
            {
                return "yesterday";
            }
            if (dayDiff   < 7)
            {
                return string.Format("{0} days ago", dayDiff);
            }
            return string.Format("{0} weeks ago", Math.Ceiling((double) dayDiff/7));
        }
    }

    // Code cleanup

    // Add tests!

    // Introduce variables for conditions instead of using comments for this
    // Now rethink these conditions, they don't make sense with the odd (int) casting, so why not just use elapsedTime.TotalDays directly?

    // How about just return a string of "future" if it's a negative timespan? 

    // Move secDiff into less than one day
    // last if case of withinlastday is redundant, don't check it
    // Extract method for WithinLastDay
    // how about Math.Floor instead of (int) casting to floor
    // how about just totalSeconds
    // do we really need to floor initially on seconds? inline and cleanup!
    // introduce variables for minutes / hours calculations to avoid confusion here
    // wait, doesn't timespan have TotalMinutes and TotalHours!
    // introduce constant fields for 60, 120, 3600 etc and remove comments

    // Consider WithinLastWeek
    // move withinlastweek to surround everything before it
    // last if statement is default now
    // get rid of dependency to totalDays (int)
    // extract metho WithinLastWeek

    // now it's easy to see that this only really provides detail within the last week, if someone wants to update for months/years they could add these options successively wrapping them and cleanly implementing the additional functionality.
    // add todo

    // make it an extension method
}