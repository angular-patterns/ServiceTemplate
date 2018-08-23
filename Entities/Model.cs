using GraphQL.Types;
using System;

namespace Entities
{
    public class Model
    {
        public int ModelId { get; set; }

        public int AccountId { get; set; }

        public string JsonSchema { get; set; }

        public string CSharpSource { get; set; }

        public string Namespace { get; set; }

        public string TypeName { get; set; }

        public Model()
        {

        }

    }

}
