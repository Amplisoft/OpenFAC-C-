using System.Collections.Generic;

namespace OpenFAC.Library
{

    public class OpenCapActionManager
    {

        private SortedDictionary<string, IOpenCapAction> actionList = new SortedDictionary<string, IOpenCapAction>();

        public void Add(string actionName, IOpenCapAction IAction)
        {
            actionList.Add(actionName, IAction);
        }

        public SortedDictionary<string, IOpenCapAction> List()
        {
            return actionList;
        }

        public IOpenCapAction Find(string actionName)
        {
            IOpenCapAction action;

            if (actionList.TryGetValue(actionName, out action))
            {
                return action;
            }

            action = OpenCapActionFactory<IOpenCapAction>.Create(actionName);

            if (action != null)
            {
                Add(actionName, action);
            }
            return action;
        }
    }

}