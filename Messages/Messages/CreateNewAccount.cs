using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messages.Messages
{
    public class CreateNewAccount: IMessage
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
