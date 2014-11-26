using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace WeavR.Analysers
{
    public static class Descriptors
    {
        public static DiagnosticDescriptor WV0001 = new DiagnosticDescriptor(
            "WV0001", 
            "Type name contains lowercase letters",
            "Type name '{0}' contains lowercase letters", 
            "Naming", 
            DiagnosticSeverity.Warning, 
            true);
    }
}
