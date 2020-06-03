
namespace OpenFAC.Library
{

    public class OpenCapSensorRESTWindows : OpenCapSensorBase
    {
        private bool isTrigged;

        public OpenCapSensorRESTWindows()
        {
        }

        public new void Dispose()
        {
            base.Dispose();
        }

        public bool IsTrigged()
        {
            return isTrigged;
        }

        public static IOpenCapSensor Create()
        {
            return new OpenCapSensorRESTWindows();
        }

    }
}