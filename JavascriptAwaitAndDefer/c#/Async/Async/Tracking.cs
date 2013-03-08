namespace Async
{
    using System.Threading.Tasks;

    public class Tracking
    {
        public static string Track(string trackingId)
        {
            return "Package in transit";
        }

        public static Task<string> TrackAsync(string trackingId)
        {
            return Task.Factory.StartNew(() => Track(trackingId));
        }
    }
}