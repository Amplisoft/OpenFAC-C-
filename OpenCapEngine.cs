
namespace OpenFAC.Library
{

    public enum EngineState
    {
        LineDown,
        ColumnRight,
        DoAction,
        LineUp,
        ColumnLeft
    }

    public delegate bool CallBackEngine(OpenCapEngine engine);

    public class OpenCapEngine : IOpenCapEngine
    {

        private EngineState currentState;
        private OpenCapKeyboard currentKeyboard;
        private OpenCapKeyboardManager keyboardManager;
        private IOpenCapKeyboard keyboardEngine;
        private IOpenCapConfig openCapConfig;
        private CallBackEngine func;
        private OpenCapKeyboardLine currentLine;
        private OpenCapSensorManager sensorManager = new OpenCapSensorManager();
        private EngineScanType scanType;
        private int currentRowNumber;
        private int priorRowNumber;
        private int currentColumnNumber;
        private int priorColumnNumber;

        public OpenCapEngine(IOpenCapConfig config)
        {
            openCapConfig = config;
            currentState = EngineState.LineDown;
            currentRowNumber = priorRowNumber = currentColumnNumber = priorColumnNumber = 0;
            keyboardManager = openCapConfig.GetKeyboardManager();
        }

        public void DoCallBack(CallBackEngine pFunc)
        {
            func = pFunc;
        }

        public void CallSensorAction(SensorState sensor)
        {
            SensorDoAction(sensor);
        }

        public void InvokeCallBack()
        {
            if (func != null)
            {
                func(this);
            }
        }

        public EngineState CurrentState()
        {
            return currentState;
        }

        public void SetCurrentState(EngineState state)
        {
            currentState = state;
        }

        public OpenCapKeyboard CurrentKeyboard()
        {
            return currentKeyboard;
        }

        public int GetCurrentRowNumber()
        {
            return currentRowNumber;
        }

        public int GetPriorRowNumber()
        {
            return priorRowNumber;
        }

        public int GetCurrentColumnNumber()
        {
            return currentColumnNumber;
        }

        public int GetPriorColumnNumber()
        {
            return priorColumnNumber;
        }

        public void CalculateNextButton()
        {
            priorColumnNumber = currentColumnNumber;
            currentColumnNumber++;
            if (currentColumnNumber == currentLine.Buttons.Count())
            {
                currentColumnNumber = 0;
            }
            InvokeCallBack();
        }

        public void CalculateNextLine()
        {
            priorRowNumber = currentRowNumber;
            currentRowNumber++;
            if (currentRowNumber == currentKeyboard.Lines.Count())
            {
                currentRowNumber = 0;
            }
            currentLine = currentKeyboard.Lines.Items[currentRowNumber];
            InvokeCallBack();
        }

        public void CalculatePriorButton()
        {
            priorColumnNumber = currentColumnNumber;
            currentColumnNumber--;
            if (currentColumnNumber < 0)
            {
                currentColumnNumber = currentLine.Buttons.Count() - 1;
            }
            InvokeCallBack();
        }

        public void CalculatePriorLine()
        {
            priorRowNumber = currentRowNumber;
            currentRowNumber--;
            if (currentRowNumber < 0)
            {
                currentRowNumber = currentKeyboard.Lines.Count() - 1;
            }
            currentLine = currentKeyboard.Lines.Items[currentRowNumber];
            InvokeCallBack();
        }

        public void DoAction()
        {
            OpenCapKeyboardButton bt = GetCurrentButton();
            if (keyboardEngine != null)
            {
                keyboardEngine.DoAction(bt);
            }
            if (bt != null)
            {
                if (bt.Action != null)
                {
                    bt.Action.Execute(this);
                }
                else
                {
                    InvokeCallBack();
                }
            }
        }


        public void SensorDoAction(SensorState state)
        {
            if (scanType == EngineScanType.ScanAuto)
            {
                DoNextAction();
            }
        }

        public void DoNextAction()
        {
            switch (currentState)
            {
                case EngineState.LineDown:
                    currentState = EngineState.ColumnRight;
                    break;
                case EngineState.ColumnRight:
                    currentState = EngineState.DoAction;
                    DoAction();
                    currentState = EngineState.LineDown;
                    ResetColumn();
                    break;
                default:
                    break;
            }
        }

        public void ResetColumn()
        {
            currentColumnNumber = 0;
        }

        public OpenCapKeyboardButton GetCurrentButton()
        {
            return currentKeyboard.Lines.Items[currentRowNumber].Buttons.Items[currentColumnNumber] as OpenCapKeyboardButton;
        }

        public OpenCapKeyboardLine CurrentLine()
        {
            return currentLine;
        }


        public void Start()
        {
            if (openCapConfig.GetScanType() == EngineScanType.ScanAuto)
            {
                scanType = EngineScanType.ScanAuto;
            }
            else
            {
                scanType = EngineScanType.ScanManual;
            }

            currentKeyboard = openCapConfig.GetCurrentKeyboard();
            
            IOpenCapSensor s = sensorManager.Find(openCapConfig.GetActiveSensor());
            s.DoCallBack(this, CallSensorAction);
            if (s != null)
            {
                s.Start();
            }

        }

    }

}