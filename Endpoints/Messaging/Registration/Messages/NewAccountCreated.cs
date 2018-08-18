using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Endpoints.Messaging.Registration.Messages
{
    public class NewAccountCreated: IMessage
    {
        public int AccountId { get; set; }
    }
}
