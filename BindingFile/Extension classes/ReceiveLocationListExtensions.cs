using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Extensions
{
    public static class ReceiveLocationListExtensions
    {
        public static List<ReceiveLocation> SortByNameAsc(this List<ReceiveLocation> list)
        {
            List<ReceiveLocation> result = list.Clone<ReceiveLocation>();
            result.Sort((x, y) => x.Name.CompareTo(y.Name));
            return result;
        }
    }
}
