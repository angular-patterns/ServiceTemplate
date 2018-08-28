using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using System.Linq;
using DynamicRules.Common;
using DynamicRules.Common.Compilation;

namespace DynamicRules.Core
{
    public class CSharpCompiler : ICSharpCompiler
    {
        public CompilerResult Compile(string source)
        {
            using (var ms = new MemoryStream())
            {
                string assemblyFileName = "gen" + Guid.NewGuid().ToString().Replace("-", "") + ".dll";

                var rootPath = Path.GetDirectoryName(typeof(object).Assembly.Location);
                CSharpCompilation compilation = CSharpCompilation.Create(assemblyFileName,
                    new[] { CSharpSyntaxTree.ParseText(source) },
                    new[]
                    {

                        MetadataReference.CreateFromFile(typeof (object).Assembly.Location), //system.private.corelib.dll
                        MetadataReference.CreateFromFile(typeof(RequiredAttribute).Assembly.Location), //system.componentmodel.annotations.dll
                        MetadataReference.CreateFromFile(typeof(JsonConverter).Assembly.Location), //newtonsoft.json.dll
                        MetadataReference.CreateFromFile(typeof(GeneratedCodeAttribute).Assembly.Location), // system.diagnostics.tools.dll
                        MetadataReference.CreateFromFile(typeof(INotifyPropertyChanged).Assembly.Location), // system.objectmodel.dll

                        MetadataReference.CreateFromFile(rootPath + "\\system.runtime.dll"),
                        MetadataReference.CreateFromFile(rootPath + "\\netstandard.dll"),

                    },
                    new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                    );

                var result = compilation.Emit(ms);
                foreach (var error in result.Diagnostics)
                {
                   
                    Console.WriteLine(error.GetMessage());
                }

                var compilerResult = new CompilerResult();
                compilerResult.Success = result.Success;
                compilerResult.Errors = result.Diagnostics
                    .Select(t =>
                        new CompilerError {
                            Code = t.Id.ToString(),
                            Message = t.GetMessage(),
                            Severity = t.Severity.ToString(),
                            Location = new SourceLocation
                            {
                                IsInSource = t.Location.IsInSource,
                                Start = t.Location.SourceSpan.Start,
                                End = t.Location.SourceSpan.End,
                                Fragment = source.Substring(t.Location.SourceSpan.Start, t.Location.SourceSpan.End - t.Location.SourceSpan.Start)
                            }

                        }).ToList();
                    
                if (result.Success)
                {
                    compilerResult.Assembly = Assembly.Load(ms.GetBuffer());
                }
                return compilerResult;
            }

        }
    }
}
