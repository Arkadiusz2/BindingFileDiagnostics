using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Extensions
{
    public static class DistributionListListExtensions
    {

        public static List<DistributionList> SortByNameAsc(this List<DistributionList> list)
        {
            List<DistributionList> result = list.Clone<DistributionList>();
            result.Sort((x, y) => x.Name.CompareTo(y.Name));
            return result;
        }
    }
}
