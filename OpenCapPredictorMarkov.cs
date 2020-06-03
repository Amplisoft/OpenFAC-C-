using System.Collections.Generic;

namespace OpenFAC.Library
{

    public class OpenCapPredictorMarkov : IOpenCapPredictor
    {
        private LinkedList<string> wordList = new LinkedList<string>();

        public OpenCapPredictorMarkov()
        {
        }
        public void Dispose()
        {
        }
        public void Predict(string metaWord)
        {

        }
        public LinkedList<string> GetListWords()
        {
            return wordList;
        }
        public void Add(string word)
        {
            wordList.AddLast(word);
        }
    }
}