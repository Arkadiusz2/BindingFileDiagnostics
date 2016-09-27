using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Extensions
{
    public static class ServiceRefListExtensions
    {
        public static List<ServiceRef> SortByNameAsc(this List<ServiceRef> list)
        {
            List<ServiceRef> result = list.Clone<ServiceRef>();
            result.Sort((x, y) => x.Name.CompareTo(y.Name));
            return result;
        }
    }
}
