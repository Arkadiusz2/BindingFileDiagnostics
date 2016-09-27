using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Extensions
{
    public static class SendPortListExtensions
    {
        public static List<SendPort> SortByNameAsc(this List<SendPort> list)
        {
            List<SendPort> result = list.Clone<SendPort>();
            result.Sort((x, y) => x.Name.CompareTo(y.Name));
            return result;
        }
    }
}
