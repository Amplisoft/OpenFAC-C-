using System.Collections.Generic;

namespace OpenFAC.Library
{

    public interface IOpenCapPredictor
    {
        void Predict(string metaWord);
        LinkedList<string> GetListWords();
        void Add(string word);
    }
}


