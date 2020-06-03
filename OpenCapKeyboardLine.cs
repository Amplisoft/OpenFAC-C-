using System.Collections.Generic;

namespace OpenFAC.Library
{
    public class OpenCapKeyboardLine
    {

        public OpenCapKeyboardLine()
        {
        }
        public List<OpenCapKeyboardLine> Items = new List<OpenCapKeyboardLine>();
        public OpenCapKeyboardLine Add()
        {
            OpenCapKeyboardLine li = new OpenCapKeyboardLine();
            Items.Add(li);
            return li;
        }
        public int Count()
        {
            return Items.Count;
        }
        public OpenCapKeyboardButton Buttons = new OpenCapKeyboardButton();
    }
}