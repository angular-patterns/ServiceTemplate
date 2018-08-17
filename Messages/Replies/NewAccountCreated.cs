using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messages.Replies
{
    public class NewAccountCreated: IMessage
    {
        public int AccountId { get; set; }
    }
}
