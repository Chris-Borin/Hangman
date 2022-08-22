using System;
using System.Collections.Generic;

namespace Hangman
{
    internal class WordBank
    {
        private List<string> WordsList { get; set; }

        /// <summary>
        /// WordBank Parameterized Constructor
        /// Sets parameter data into property data for corresponding WordBank object
        /// </summary>
        /// <param name="inputWrd"></param>
        public WordBank()
        {
            WordsList = new List<string>();
            WordsList.Add("water");
            WordsList.Add("cake");
            WordsList.Add("pepper");
            WordsList.Add("sodium");
            WordsList.Add("jello");
            WordsList.Add("yogurt");
            WordsList.Add("cinnamon");
            WordsList.Add("bread");
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
        /// Returns randomly chosen answer
        /// // Keeps track of which letters have been previously guessed
        /// </summary>
        /// <param name="word"></param>
        public string ChooseWord(int prev)
        {
            Random random = new Random();
            int generatedWrd = random.Next(WordsList.Count);
            while (WordsList[generatedWrd].Length == prev)
            {
                generatedWrd = random.Next(WordsList.Count);
            }
            return WordsList[generatedWrd];
        }
    }
}