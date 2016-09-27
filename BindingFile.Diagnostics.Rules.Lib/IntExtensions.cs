using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Diagnostics.Rules
{
    internal static class IntExtensions
    {
        /// <summary>
        /// Switches off the bits that are set in the pattern
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public static int BitwiseAndNot(this int i, int j)
        {
            return i & ~j;
        }

    }
}
