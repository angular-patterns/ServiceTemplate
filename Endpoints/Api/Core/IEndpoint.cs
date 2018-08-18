using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Endpoints.Api.Core
{
    public interface IEndpoint
    {
        string Name { get; }

        void Init();

        IEndpointInstance Instance { get; }
    }
}
