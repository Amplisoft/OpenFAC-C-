
namespace OpenFAC.Library
{

    public class OpenCapKeyboardT9 : OpenCapKeyboard
    {
        private IOpenCapPredictor predictor;

        public OpenCapKeyboardT9()
        {
        }

        public void Dispose()
        {
        }

        public new void DoAction(OpenCapKeyboardButton button)
        {

        }

        public static IOpenCapKeyboard Create()
        {
            return new OpenCapKeyboardT9();
        }

    }
}
