namespace Samples.Testing
{
    using System;
    using System.IO;
    using System.Net;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using NUnit.Framework;

    [TestFixture]
    public class IntroducingSeamsGoals : AssertionHelper
    {
        [Test]
        public void ForecastFromXml_XmlHasMin_ParsesMin()
        {
            var data = File.ReadAllText("weather.xml");

            var forecast = ForecastFromXml("60613", data);

            Expect(forecast.Min, Is.EqualTo(25));
        }

        [Test]
        public void ForecastFromXml_XmlHasMax_ParsesMax()
        {
            var data = File.ReadAllText("weather.xml");

            var forecast = ForecastFromXml("60613", data);

            Expect(forecast.Max, Is.EqualTo(34));
        }

        [Test]
        public void ForecastFromXml_XmlMissingMin_ReturnsNullForecast()
        {
            var data = File.ReadAllText("weather.xml");
            data = data.Replace("minimum", "");

            var forecast = ForecastFromXml("60613", data);

            Expect(forecast, Is.Null);
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
                var data = reader.ReadToEnd();
                return ForecastFromXml(zipCode, data);
            }
        }

        private static Forecast ForecastFromXml(string zipCode, string data)
        {
            var xml = XDocument.Parse(data);
            var minimum = xml.XPathSelectElement("dwml/data/parameters/temperature[@type='minimum']/value");
            if (minimum == null)
            {
                return null;
            }
            var min = minimum.Value;
            var max = xml.XPathSelectElement("dwml/data/parameters/temperature[@type='maximum']/value").Value;
            return new Forecast
                {
                    ZipCode = zipCode,
                    Min = Convert.ToInt32(min),
                    Max = Convert.ToInt32(max)
                };
        }
    }
}