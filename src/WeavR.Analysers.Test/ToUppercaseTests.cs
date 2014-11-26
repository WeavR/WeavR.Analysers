using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestHelper;
using WeavR.Analysers.ToUppercase;

namespace WeavR.Analysers.Test
{
    [TestClass]
    public class ToUppercaseTests : CodeFixVerifier
    {
        [TestMethod]
        public void BlankShouldNotProduceDiagnostics()
        {
            var test = @"";

            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void DiagnosticDetectsTypeName()
        {
            var expected = Descriptors.WV0001
                .CreateResult(new DiagnosticResultLocation("ToUppercase.Simple.cs", 10, 11), "TypeName");

            VerifyCSharpDiagnostic("ToUppercase.Simple.cs", expected);
        }

        [TestMethod]
        public void CodeFixChangesTypeName()
        {
            VerifyCSharpFix("ToUppercase.Simple.cs");
        }

        protected override CodeFixProvider GetCSharpCodeFixProvider()
        {
            return new ToUppercaseCodeFixProvider();
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new ToUppercaseAnalyser();
        }
    }
}