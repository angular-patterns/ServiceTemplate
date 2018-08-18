using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Endpoints.Messaging.Registration.Commands
{
    public class CreateNewAccount: ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
