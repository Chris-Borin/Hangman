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
            WordsList = new List<string>();
            WordsList.Add("water");
            WordsList.Add("ice");
            WordsList.Add("food");
            WordsList.Add("juice");
            WordsList.Add("coke");
            WordsList.Add("sugar");
            WordsList.Add("apple");
            WordsList.Add("banana");
            WordsList.Add("avocado");
            WordsList.Add("blueberry");
            WordsList.Add("strawberry");
            WordsList.Add("grapes");
        }

        /// <summary>
        /// Allocates randomly chosen answer
        /// </summary>
        /// <param name="word"></param>
        public void ChosenWord(string word)
        {
            Word = word;
        }
    }
}
