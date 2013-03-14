namespace Samples.Expansions
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using NUnit.Framework;

    [TestFixture]
    public class ConsumptionConcerns : AssertionHelper
    {
        [Test]
        public void Sample()
        {
            CheckIfGrowthIsUnlikelyThisWeek("60613");
        }

        private void CheckIfGrowthIsUnlikelyThisWeek(string zipCode)
        {
            var zip = "60613";
            var getLatitudeAndLongitudeUri = string.Format("http://graphical.weather.gov/xml/sample_products/browser_interface/ndfdXMLclient.php?listZipCodeList={0}", zip);
            var xml = XDocument.Load(getLatitudeAndLongitudeUri);
            var xmlLocation = xml.XPathSelectElement("dwml/latLonList").Value.Split(',');
            var latitude = xmlLocation[0];
            var longitude = xmlLocation[1];

            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(7);
            var getWeeklyForecastResource = string.Format("http://graphical.weather.gov/xml/sample_products/browser_interface/ndfdXMLclient.php?lat={0}&lon={1}&product=time-series&begin={2:yyyy-MM-dd}T00:00:00&end={3:yyyy-MM-dd}T00:00:00&maxt=maxt&mint=mint", latitude, longitude, startDate, endDate);
            var forecast = XDocument.Load(getWeeklyForecastResource);

            var minimums = forecast.XPathSelectElements("dwml/data/parameters/temperature[@type='minimum']/value");
            var weeklyMinimum = minimums.Select(m => Convert.ToDecimal(m.Value)).Min();
            var maximums = forecast.XPathSelectElements("dwml/data/parameters/temperature[@type='maximum']/value");
            var weeklyMaximum = maximums.Select(m => Convert.ToDecimal(m.Value)).Max();
            var averageDailyChange = minimums.Zip(maximums, (min, max) => Convert.ToDecimal(max.Value) - Convert.ToDecimal(min.Value)).Average();
            Console.WriteLine(forecast);
            Console.WriteLine(weeklyMinimum);
            Console.WriteLine(weeklyMaximum);
            Console.WriteLine(averageDailyChange);

            var growthUnlikely = WillGrowthBeUnlikely(weeklyMinimum, weeklyMaximum, averageDailyChange);
            if (growthUnlikely)
            {
                throw new ApplicationException("Growth is unlikely");
            }
        }

        private bool WillGrowthBeUnlikely(decimal weeklyMinimum, decimal weeklyMaximum, decimal averageDailyChange)
        {
            return averageDailyChange > 40 || weeklyMinimum < 5 || weeklyMaximum > 99;
        }

        // we've talked about introducing seams to test mapping code
        // we've talked about extracting query objects
        // how can we refactor this code to separate querying (loading data), mapping (translating the data set) and consumption (using the data set for our own specific purpose)

        // mapping ideas (getting all mins, all maxes and daily min and max as methods on a mapping layer)
    }
}