namespace Samples.Testing
{
    using System;
    using System.IO;
    using System.Net;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using NUnit.Framework;

    [TestFixture]
    public class IntroducingSeams : AssertionHelper
    {
        [Test]
        public void Sample()
        {
            var forecast = GetForecast("60613");
            Console.WriteLine(forecast);
        }

        public class Forecast
        {
            public string ZipCode { get; set; }
            public int Min { get; set; }
            public int Max { get; set; }

            public override string ToString()
            {
                return string.Format("ZipCode: {0}, Min: {1}, Max: {2}", ZipCode, Min, Max);
            }
        }

        public static Forecast GetForecast(string zipCode)
        {
            var resource = string.Format("http://graphical.weather.gov/xml/sample_products/browser_interface/ndfdBrowserClientByDay.php?zipCodeList={0}&format=24+hourly&startDate=2013-03-13&numDays=1", zipCode);
            using (var response = WebRequest.Create(resource).GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var xml = XDocument.Parse(reader.ReadToEnd());
                var min = xml.XPathSelectElement("dwml/data/parameters/temperature[@type='minimum']/value").Value;
                var max = xml.XPathSelectElement("dwml/data/parameters/temperature[@type='maximum']/value").Value;
                return new Forecast
                    {
                        ZipCode = zipCode,
                        Min = Convert.ToInt32(min),
                        Max = Convert.ToInt32(max)
                    };
            }
        }

        // Introduce variable for reader.ReadToEnd()
        // Extract method for parsing xml
        // Deal with zipcode -> set after parsing or if you are really worried just leave it and we can clean that up after we have tests
        // use File.WriteAllText to setup test case
        // use File.ReadAllText to read in test case

        // Add test case of parsing minimum
        // Add test case of parsing maximum

        // Refactoring: enhancing robustness
        // Add new code for missing minimum or maximum

        // Refactoring: adding features
        // Add parsing of temperature scale

        // Extol virtue of a tool introducing seams quickly so you can add the tests and make changes
    }
}