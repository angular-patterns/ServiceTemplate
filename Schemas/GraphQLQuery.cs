using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphQL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Schemas
{

    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine();
            if (!string.IsNullOrWhiteSpace(OperationName))
            {
                builder.AppendLine($"OperationName = {OperationName}");
            }
            if (!string.IsNullOrWhiteSpace(NamedQuery))
            {
                builder.AppendLine($"NamedQuery = {NamedQuery}");
            }
            if (!string.IsNullOrWhiteSpace(Query))
            {
                builder.AppendLine($"Query = {Query}");
            }
            if (Variables != null)
            {
                builder.AppendLine($"variables = {Variables}");
            }
            return builder.ToString();

        }

        public Inputs GetInputs(IDictionary<string, object> variables)
        {
            var dict = new Inputs(variables);

            foreach (var key in variables.Keys)
            {
                if (dict[key] is JObject jObject)
                {
                    dict[key] = jObject.ToObject<Dictionary<string, object>>();
                    GetInputs((IDictionary<string, object>) dict[key]);
                }
                if (dict[key] is JArray jArray)
                {
                    dict[key] = GetInputs(jArray);
                }
            }
            return dict;
        }

        public Array GetInputs(JArray array)
        {
            var arr = new List<object>();
            for (var i = 0; i < array.Count; ++i)
            {

                var obj = array[i];
                arr.Add(obj);
                if (obj is JObject o)
                {
                    var dict = o.ToObject<Dictionary<string, object>>();
                    arr[i] = GetInputs(dict);

                }
                if (obj is JArray jArray)
                {
                    arr[i] = GetInputs(jArray);
                }
            }
            return arr.ToArray();
        }
    }
}

