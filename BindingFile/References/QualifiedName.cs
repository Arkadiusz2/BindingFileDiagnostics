using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile
{
    public class ClassQualifiedName
    {
        public string _fullName;
        public string _assemblyQualifiedName;
        public string _classQualifiedName;
        
        public ClassQualifiedName(string classQualifiedName)
        {
            if (classQualifiedName == null)
            {
                throw new ArgumentNullException("classQualifiedName");
            }

            _classQualifiedName = classQualifiedName;
            Parse(classQualifiedName);
        }
        
        private void Parse(string classQualifiedName)
        {
            int index = classQualifiedName.IndexOf(",");

            if (index > 0)
            {
                _fullName = classQualifiedName.Substring(0, index);
                if (index + 1 < classQualifiedName.Length)
                {
                    _assemblyQualifiedName = classQualifiedName.Substring(index + 1).TrimStart();
                }
                else
                {
                    _assemblyQualifiedName = "";
                }
            }
            else
            {
                _fullName = classQualifiedName;
                _assemblyQualifiedName = "";
            }
        }

        public string FullName
        {
            get
            {
                return _fullName;
            }
        }

        public string AssemblyQualifiedName
        {
            get
            {
                return _assemblyQualifiedName;
            }
        }

        public string CalssQualifiedName
        {
            get
            {
                return _classQualifiedName;
            }
        }
    }
}
