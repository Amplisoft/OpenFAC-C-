using System;
using System.Collections.Generic;

namespace OpenFAC.Library
{

    public class OpenCapSensorFactory<T>
    {

        static readonly SortedDictionary<string, Type> m_FactoryMap = new SortedDictionary<string, Type>();

        private OpenCapSensorFactory()
        {
        }

        public static void Register<Tderived>(string sensorName) where Tderived : T
        {
            var type = typeof(Tderived);

            if (type.IsInterface || type.IsAbstract)
                throw new ArgumentException("...");

            m_FactoryMap.Add(sensorName, type);
        }

        public static T Create(string sensorName, params object[] args)
        {
            Type type = null;
            if (m_FactoryMap.TryGetValue(sensorName, out type))
                return (T)Activator.CreateInstance(type);

            throw new ArgumentException("No type registered for this id");

        }


    }
}