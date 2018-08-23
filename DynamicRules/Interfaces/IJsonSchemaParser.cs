using System.Threading.Tasks;

namespace DynamicRules.Interfaces
{
    public interface IJsonSchemaParser
    {
        Task<JsonSchemaInfo> FromSchema(string jsonSchema, string typeName, string nameSpace);

        Task<JsonSchemaInfo> FromCSharp(string csharpFile, string typeName);
    }
}
