using System;
using System.Collections.Generic;

namespace OpenFAC.Library
{

    public class OpenCapKeyboardFactory<T>
    {

        private IOpenCapKeyboard keyboard;
        static readonly SortedDictionary<string, Type> m_FactoryMap = new SortedDictionary<string, Type>();

        private OpenCapKeyboardFactory()
        {
        }

        public static void Register<Tderived>(string keyboardName) where Tderived : T
        {
            var type = typeof(Tderived);

            if (type.IsInterface || type.IsAbstract)
                throw new ArgumentException("...");

            m_FactoryMap.Add(keyboardName, type);
        }

        public static T Create(string keyboardName, params object[] args)
        {
            Type type = null;
            if (m_FactoryMap.TryGetValue(keyboardName, out type))
                return (T)Activator.CreateInstance(type);

            throw new ArgumentException("No type registered for this id");

        }


    }
}