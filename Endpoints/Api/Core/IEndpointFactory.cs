using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Endpoints.Api.Core
{
    public interface IEndpointFactory
    {
        IEndpointInstance Get(string name);
    }
}
