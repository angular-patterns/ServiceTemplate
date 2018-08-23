using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DynamicRules.Interfaces
{
    public interface IJsonSchemaConverter
    {
        Task<string> JsonSchemaToCSharp(string schemaData, string ns);
        Task<string> CSharpToJsonSchema(Type type);
    }
}
