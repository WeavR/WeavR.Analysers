using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace WeavR.Analysers.Framework
{
    public abstract class SymbolDiagnosticAnalyser<T> : DiagnosticAnalyzer where T : ISymbol
    {
        private DiagnosticDescriptor descriptor;
        private SymbolKind symbolKind;

        private SymbolDiagnosticAnalyser()
        {
        }

        protected SymbolDiagnosticAnalyser(DiagnosticDescriptor descriptor, SymbolKind symbolKind)
        {
            this.descriptor = descriptor;
            this.symbolKind = symbolKind;
        }

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get
            {
                return ImmutableArray.Create(descriptor);
            }
        }

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(AnalyseSymbol, symbolKind);
        }

        protected virtual void AnalyseSymbol(SymbolAnalysisContext context)
        {
            var symbol = (T)context.Symbol;
            AnalyseSymbol(symbol, d => context.ReportDiagnostic(d));
        }

        protected abstract void AnalyseSymbol(T symbol, Action<Diagnostic> reportDiagnostic);
    }
}
