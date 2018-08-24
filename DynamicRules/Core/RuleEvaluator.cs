using DynamicRules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DynamicRules.Core
{
    public class RuleEvaluator: IRuleEvaluator
    {

        public bool RunPredicate(IDictionary<Type, Object> context, string logic)
        {
            var parameters = new List<ParameterExpression>();
            var values = new List<Object>();
            foreach (var keyValue in context)
            {
                parameters.Add(Expression.Parameter(keyValue.Key, keyValue.Key.Name));
                values.Add(keyValue.Value);
            }
            

            var expr = System.Linq.Dynamic.DynamicExpression.ParseLambda(parameters.ToArray(), typeof(bool), logic, values );

            return (bool)expr.Compile().DynamicInvoke(values);

        }
    }
}
