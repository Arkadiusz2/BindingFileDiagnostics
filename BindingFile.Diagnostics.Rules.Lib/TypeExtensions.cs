using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Diagnostics.Rules
{
    public static class TypeExtensions
    {
        public static bool Implements<I>(this Type type) 
            where I : class
        {
            var interfaceType = typeof(I);

            if (!interfaceType.IsInterface)
            {
                throw new InvalidOperationException("Only interfaces can be implemented.");
            }

            return (interfaceType.IsAssignableFrom(type));
        }

        public static bool HasParameterlessConstructor(this Type t)
        {
            return t.GetConstructor(new Type[0]) != null;
        }

    }
}
