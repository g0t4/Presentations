namespace Async
{
    using System;

    public class FaultyEmailer : Emailer
    {
        public override void SendEmail(object message)
        {
            throw new ApplicationException("Oh noes error sending email!");
        }
    }
}