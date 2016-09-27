using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile
{
    public class ReferencedMapCollection
    {
        private Dictionary<string, ReferencedMap> _items = new Dictionary<string, ReferencedMap>();

        public ReferencedMapCollection()
        {
        }

        /// <summary>
        /// Gets or create pipeline in the collection
        /// </summary>
        /// <param name="fullyQualifiedName">Qualified name of the assembly</param>
        /// <returns></returns>
        public ReferencedMap GetOrCreateItem(string fullyQualifiedName)
        {
            ReferencedMap item;
            if (_items.ContainsKey(fullyQualifiedName))
            {
                item = _items[fullyQualifiedName];
            }
            else
            {
                item = new ReferencedMap(null, fullyQualifiedName);
                _items.Add(fullyQualifiedName, item);
            }
            return item;
        }

        /// <summary>
        /// Collection of maps referenced by receive lcoations and send ports
        /// </summary>
        public IEnumerable<ReferencedMap> Items
        {
            get
            {
                return _items.Values;
            }
        }
    }
}
