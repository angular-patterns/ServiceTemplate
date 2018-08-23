using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DynamicRules.Interfaces
{
    public interface ICSharpCompiler
    {
        CompilerResult Compile(string source);
    }
}
