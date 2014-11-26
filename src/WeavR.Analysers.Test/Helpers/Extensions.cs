using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using TestHelper;

namespace WeavR.Analysers.Test
{
    static class Extensions
    {
        public static DiagnosticResult CreateResult(this DiagnosticDescriptor descriptor, DiagnosticResultLocation location, params object[] messageArgs)
        {
            return new DiagnosticResult
            {
                Id = descriptor.Id,
                Message = String.Format(descriptor.MessageFormat, messageArgs),
                Severity = descriptor.DefaultSeverity,
                Locations = new[] { location }
            };
        }
    }
}
