namespace OpenFAC.Library
{
    public class OpenCapSensorJoystickWindows : OpenCapSensorBase
    {
        public OpenCapSensorJoystickWindows()
        {
        }
        public new void Dispose()
        {
            base.Dispose();
        }

        public bool IsTrigged()
        {
            return false;
        }

        public static IOpenCapSensor Create()
        {
            return new OpenCapSensorJoystickWindows();
        }
    }
}
