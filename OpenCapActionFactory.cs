using System;
using System.Collections.Generic;

namespace OpenFAC.Library
{


    public class OpenCapActionFactory<T>
    {
        static readonly SortedDictionary<string, Type> m_FactoryMap = new SortedDictionary<string, Type>();

        private OpenCapActionFactory()
        {
        }

        public static void Register<Tderived>(string actionName) where Tderived : T
        {
            var type = typeof(Tderived);

            if (type.IsInterface || type.IsAbstract)
                throw new ArgumentException("...");

            m_FactoryMap.Add(actionName, type);
        }

        public static T Create(string actionName, params object[] args)
        {
            Type type = null;
            if (m_FactoryMap.TryGetValue(actionName, out type))
                return (T)Activator.CreateInstance(type);

            throw new ArgumentException("No type registered for this id");

        }


    }
}
