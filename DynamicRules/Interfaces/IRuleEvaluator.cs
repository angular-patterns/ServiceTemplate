using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicRules.Interfaces
{
    public interface IRuleEvaluator
    {
        bool RunPredicate(Type type, Object value, string codeLogic);
    }
}
