using NJsonSchema;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DynamicRules.Interfaces
{
    public class JsonSchemaInfo
    {
        public string TypeName { get; set; }
        public string Namespace { get; set; }
        public string Schema { get; set; }

        public Type ModelType { get; set; }

        public Assembly ModelAssembly { get; set; }
    }
}
