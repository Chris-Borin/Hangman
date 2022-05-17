using System.Collections.Generic;

namespace Hangman
{
    internal class WordBank
    {
        public string Word { get; private set; }
        public List<string> WordsList { get; private set; }

        /// <summary>
        /// WordBank Parameterized Constructor
        /// Sets parameter data to property data for corresponding WordBank object
        /// </summary>
        /// <param name="inputWrd"></param>
        public WordBank()
        {
            wordsList = new List<string>();
        }

        /// <summary>
        /// Helper Function for addWord()
        /// Sends its parameter as an argument
        /// </summary>
        /// <param name="word"></param>
        public void NewWord(string word)
        {
            AddWord(word);
        }

        /// <summary>
        /// Adds parameter data to WordList
        /// </summary>
        /// <param name="word"></param>
        private void AddWord(string word)
        {
            wordsList.Add(word);
        }

        /// <summary>
        /// Helper method for theWord()
        /// </summary>
        /// <param name="word"></param>
        public void ChosenWord(string word)
        {
            TheWord(word);
        }

        /// <summary>
        /// Allocates randomly chosen answer
        /// </summary>
        /// <param name="word"></param>
        private void TheWord(string word)
        {
            Word = word;
        }
    }
}
