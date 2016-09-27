using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    public class AdapterInfo : IAdapterInfo
    {
        string _name;
        Guid _classId;

        public AdapterInfo(string name, Guid classId)
        {
            this._name = name;
            this._classId = classId;
        }

        /// <summary>
        /// Name of transport type as displayed in binding file 
        /// </summary>
        public string Name
        {
            get 
            {
                return this._name;
            }
        }

        /// <summary>
        /// Configuration class id of transport type as displayed in binding file
        /// </summary>
        public Guid ConfigurationClsid
        {
            get 
            {
                return this._classId;
            }
        }
    }

    
}
