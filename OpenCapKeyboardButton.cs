using System.Collections.Generic;

namespace OpenFAC.Library
{

    public class OpenCapKeyboardButton
    {
        public List<OpenCapKeyboardButton> Items = new List<OpenCapKeyboardButton>();
        public OpenCapKeyboardButton Add()
        {
            OpenCapKeyboardButton bt = new OpenCapKeyboardButton();
            Items.Add(bt);
            return bt;
        }
        public int Count()
        {
            return Items.Count;
        }
        public string Caption;
        public string Text;
        public IOpenCapAction Action;
        public OpenCapKeyboardButton()
        {
        }
    }
}
