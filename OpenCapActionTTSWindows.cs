using System.Speech;
using System.Speech.Synthesis; 

namespace OpenFAC.Library
{

    public class OpenCapActionTTSWindows : IOpenCapAction
    {


        public OpenCapActionTTSWindows()
        {
        }

        public void Dispose()
        {
        }

        public void Speak(string text)
        {
            SpeechSynthesizer reader = new SpeechSynthesizer();
            reader.SpeakAsync(text);

        }


        public void Execute(IOpenCapEngine Engine)
        {
            OpenCapEngine eg = (OpenCapEngine)(Engine);
            OpenCapKeyboardButton bt = eg.GetCurrentButton();
            string str = bt.Text;
            Speak(str);
        }

        public void Free()
        {
            if (this != null)
                this.Dispose();
        }

        public static IOpenCapAction Create()
        {
            return new OpenCapActionTTSWindows();
        }


    }
}