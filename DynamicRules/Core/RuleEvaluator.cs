using DynamicRules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DynamicRules.Core
{
    public class RuleEvaluator: IRuleEvaluator
    {

        public bool RunPredicate(Type type, Object value, string codeLogic)
        {

            ParameterExpression parm1 = Expression.Parameter(type, type.Name);

            var expr = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { parm1 }, typeof(bool), codeLogic);

            return (bool)expr.Compile().DynamicInvoke(value);

        }
    }
}
