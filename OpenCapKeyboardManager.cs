using System.Collections.Generic;

namespace OpenFAC.Library
{

    public class OpenCapKeyboardManager
    {

        private SortedDictionary<string, IOpenCapKeyboard> keyboardList = new SortedDictionary<string, IOpenCapKeyboard>();

        public void Add(string keyboardName, IOpenCapKeyboard IKeyboard)
        {
            keyboardList.Add(keyboardName, IKeyboard);
        }

        public SortedDictionary<string, IOpenCapKeyboard> List()
        {
            return keyboardList;
        }

        public IOpenCapKeyboard Find(string keyboardName)
        {
            IOpenCapKeyboard keyboard;

            if (keyboardList.TryGetValue(keyboardName, out keyboard))
            {
                return keyboard;
            }

            keyboard = OpenCapKeyboardFactory<IOpenCapKeyboard>.Create(keyboardName);

            if (keyboard != null)
            {
                Add(keyboardName, keyboard);
            }
            return keyboard;
        }
    }
}