using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Extensions
{
    public static class ListExtensions
    {
        public static List<T> Clone<T>(this List<T> list)
        {
            return list.GetRange(0, list.Count);
        }
    }
}
