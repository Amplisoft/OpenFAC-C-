
namespace OpenFAC.Library
{


    public enum SensorState
    {
        SensorDown,
        SensorUp,
        SensorRight,
        SensorLeft,
        SensorAuto
    }

    public delegate void CallBackSensor(SensorState state);

    public interface IOpenCapSensor
    {

        void DoCallBack(object pFunc, CallBackSensor sensor);
        void DoAction(SensorState state);
        void Start();
        void Stop();
    }

}

