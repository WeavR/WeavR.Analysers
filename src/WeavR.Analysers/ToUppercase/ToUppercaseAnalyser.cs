using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using WeavR.Analysers.Framework;

namespace WeavR.Analysers.ToUppercase
{
    [DiagnosticAnalyzer]
    public class ToUppercaseAnalyser : SymbolDiagnosticAnalyser<INamedTypeSymbol>
    {
        public ToUppercaseAnalyser() :base(Descriptors.WV0001, SymbolKind.NamedType)
        {
        }

        protected override void AnalyseSymbol(INamedTypeSymbol symbol, Action<Diagnostic> reportDiagnostic)
        {
            // Find just those named type symbols with names containing lowercase letters.
            if (symbol.Name.ToCharArray().Any(char.IsLower))
            {
                // For all such symbols, produce a diagnostic.
                var diagnostic = Diagnostic.Create(Descriptors.WV0001, symbol.Locations[0], symbol.Name);

                reportDiagnostic(diagnostic);
            }
        }
    }
}
