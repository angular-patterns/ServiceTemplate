using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicRules.Interfaces
{
    public interface IRuleEvaluator
    {
        bool RunPredicate(IDictionary<string, KeyValuePair<Type, Object>> context, string codeLogic);
    }
}
