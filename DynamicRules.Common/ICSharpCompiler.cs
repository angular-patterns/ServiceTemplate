using DynamicRules.Common.Compilation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DynamicRules.Common
{
    public interface ICSharpCompiler
    {
        CompilerResult Compile(string source);
    }
}
