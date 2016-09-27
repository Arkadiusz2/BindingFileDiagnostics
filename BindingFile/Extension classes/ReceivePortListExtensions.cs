using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Extensions
{
    public static class ReceivePortListExtensions
    {
        public static List<ReceivePort> SortByNameAsc(this List<ReceivePort> list)
        {
            List<ReceivePort> result = list.Clone<ReceivePort>();
            result.Sort((x, y) => x.Name.CompareTo(y.Name));
            return result;
        }
    }
}
