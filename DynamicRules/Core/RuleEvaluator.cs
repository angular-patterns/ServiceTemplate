using DynamicRules.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DynamicRules.Core
{
    public class RuleEvaluator: IRuleEvaluator
    {

        public bool RunPredicate(IDictionary<string, KeyValuePair<Type,Object>> context, string logic)
        {
            var parameters = new List<ParameterExpression>();
            var values = new List<Object>();
            foreach (var keyValue in context)
            {
                parameters.Add(Expression.Parameter(context[keyValue.Key].Key, keyValue.Key));
                values.Add(context[keyValue.Key].Value);
            }
            

            var expr = System.Linq.Dynamic.DynamicExpression.ParseLambda(parameters.ToArray(), typeof(bool), logic );

            return (bool)expr.Compile().DynamicInvoke(values.ToArray());

        }
    }
}
