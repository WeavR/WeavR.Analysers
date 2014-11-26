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

        //No diagnostics expected to show up
        [TestMethod]
        public void BlankShouldNotProduceDiagnostics()
        {
            var test = @"";

            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void DiagnosticDetectsTypeName()
        {
            var expected = new DiagnosticResult
            {
                Id = WeavRAnalysersAnalyzer.DiagnosticId,
                Message = String.Format("Type name '{0}' contains lowercase letters", "TypeName"),
                Severity = DiagnosticSeverity.Warning,
                Locations =
                    new[] {
                            new DiagnosticResultLocation("Test0.cs", 10, 11)
                        }
            };

            VerifyCSharpDiagnostic("ToUppercase.Simple.cs", expected);
        }

        [TestMethod]
        public void CodeFixChangesTypeName()
        {
            VerifyCSharpFix("ToUppercase.Simple.cs");
        }

        protected override CodeFixProvider GetCSharpCodeFixProvider()
        {
            return new WeavRAnalysersCodeFixProvider();
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new WeavRAnalysersAnalyzer();
        }
    }
}