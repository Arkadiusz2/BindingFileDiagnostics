using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Extensions
{
    public static class ApplciationListExtensions
    {
        public static List<BtsApplication> SortByNameAsc(this List<BtsApplication> list)
        {
            List<BtsApplication> result = list.Clone<BtsApplication>();
            result.Sort((x, y) => x.Name.CompareTo(y.Name));
            return result;
        }
    }
}
