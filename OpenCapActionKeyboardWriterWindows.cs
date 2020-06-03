using System.Windows.Forms;

namespace OpenFAC.Library
{

    public class OpenCapActionKeyboardWriterWindows : IOpenCapAction
    {

        public void Execute(IOpenCapEngine Engine)
        {
            OpenCapEngine eg = (OpenCapEngine)(Engine);
            OpenCapKeyboardButton bt = eg.GetCurrentButton();
            string str = bt.Text;
            SendKeys.SendWait(str);
        }

        public static IOpenCapAction Create()
        {
            return new OpenCapActionKeyboardWriterWindows();
        }

    }
}