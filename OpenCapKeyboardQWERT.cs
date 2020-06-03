
namespace OpenFAC.Library
{

    public class OpenCapKeyboardQWERT : OpenCapKeyboard
    {
        private IOpenCapPredictor predictor;
        public new void DoAction(OpenCapKeyboardButton button)
        {

        }
        public OpenCapKeyboardQWERT()
        {
        }

        public static IOpenCapKeyboard Create()
        {
            return new OpenCapKeyboardQWERT();
        }

    }
}