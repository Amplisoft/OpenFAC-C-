
namespace OpenFAC.Library
{

    public enum EngineScanType
    {
        ScanAuto,
        ScanManual
    }


    public interface IOpenCapConfig
    {
        OpenCapKeyboardManager GetKeyboardManager();
        OpenCapKeyboard GetCurrentKeyboard();
        EngineScanType GetScanType();
        string GetActiveSensor();
    }
}

