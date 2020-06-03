namespace OpenFAC.Library
{

    public abstract class OpenCapSensorBase : IOpenCapSensor
    {
        private CallBackSensor func;

        private object pObject;

        public OpenCapSensorBase()
        {
        }

        public void Dispose()
        {
        }

        public virtual void Start()
        {

        }

        public virtual void Stop()
        {

        }

        public void DoCallBack(object pFunc, CallBackSensor sensor)
        {
            func = sensor;
            pObject = pFunc;
        }

        public virtual void DoAction(SensorState state)
        {
            if (func != null)
            {
                func(SensorState.SensorAuto);
            }
        }


    }
}