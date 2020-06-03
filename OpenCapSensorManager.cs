using System.Collections.Generic;
namespace OpenFAC.Library
{
    public class OpenCapSensorManager
    {

        private SortedDictionary<string, IOpenCapSensor> sensorList = new SortedDictionary<string, IOpenCapSensor>();

        public void Add(string sensorName, IOpenCapSensor ISensor)
        {
            sensorList.Add(sensorName, ISensor);
        }

        public SortedDictionary<string, IOpenCapSensor> List()
        {
            return sensorList;
        }

        public IOpenCapSensor Find(string sensorName)
        {
            IOpenCapSensor sensor;

            if (sensorList.TryGetValue(sensorName, out sensor))
            {
                return sensor;
            }

            sensor = OpenCapSensorFactory<IOpenCapSensor>.Create(sensorName);

            if (sensor != null)
            {
                Add(sensorName, sensor);
            }
            return sensor;
        }
    }
}