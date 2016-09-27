using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Diagnostics.Rules
{
    public static class StringExtensions
    {
        public static IEnumerable<string> Wrap(this string s)
        {
            return new string[] { s };
        }

        public static string Unwrap(this IEnumerable<string> a)
        {
            return string.Join("\r\n", a);
        }
    }
}
