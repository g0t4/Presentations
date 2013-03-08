namespace Async
{
    using System;
    using System.Threading.Tasks;

    public class Emailer
    {
        public virtual void SendEmail(object message)
        {
            Console.WriteLine("email sent: " + message);
        }

        public Task SendEmailAsync(object message)
        {
            return Task.Factory.StartNew(() => SendEmail(message));
        }
    }
}