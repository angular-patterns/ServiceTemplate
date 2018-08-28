using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Models
{
    public class FromJsonSchema
    {
        public int AccountId { get; set; }

        public string JsonSchema { get; set; }

        public string TypeName { get; set; }

        public string Namespace { get; set; }

    }
}
