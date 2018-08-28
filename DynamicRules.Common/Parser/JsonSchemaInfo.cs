using System;
using System.Reflection;

namespace DynamicRules.Common.Parser
{
    public class JsonSchemaInfo
    {
        public string TypeName { get; set; }
        public string Namespace { get; set; }
        public string Schema { get; set; }

        public string CSharpSource { get; set; }

        public Type ModelType { get; set; }

        public Assembly ModelAssembly { get; set; }
    }
}
