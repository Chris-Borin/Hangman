using System.Collections.Generic;

namespace Hangman
{
    /// <summary>
    /// Tracks matching characters with answer key
    /// Tracks previously guessed letters
    /// </summary>
    internal class GamePlay
    {
        public List<char> GuessLetters { get; private set; }
        public List<bool> Matched { get; private set; }
        
        /// <summary>
        /// GamePlay Parameterized Constructor
        /// Constructor initializes properties
        /// Matched initialized to false based on length of answer
        /// </summary>
        /// <param name="wordLen"></param>
        public GamePlay(int wordLen)
        {
            Matched = new List<bool>();
            GuessLetters = new List<char>();
            for(int i = 0; i < wordLen; i++)
            {
                Matched.Add(false);
            }
        }

        /// <summary>
        /// Determines if guessed letter is a criteria from the answer
        /// Adds current letter to GuessedLetters
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Guess(char letter, string word)
        {
            if (word.Contains(letter))
            {
                GuessLetters.Add(letter);
                int cnt = 0;
                foreach(char c in word)
                {
                    if (c == letter)
                    {
                        Matched[cnt] = true;
                    }
                    cnt++;
                }
                return true;
            }
            else
                GuessLetters.Add(letter);
            return false;
        }

        /// <summary>
        /// Empties Matched and GuessLetters elements
        /// Reinitializes all indexes of Matched to false based on length of answer
        /// </summary>
        /// <param name="newWord"></param>
        public void NewWord(int newWord)
        {
            Matched.Clear();
            for (int i = 0; i < newWord; i++)
            {
                Matched.Add(false);
            }
            GuessLetters.Clear();
        }

        /// <summary>
        /// Confirms user guessed all required letters
        /// </summary>
        /// <returns></returns>
        public bool Win()
        {
            foreach(bool one in Matched)
            {
                if (one)
                    continue;
                else
                    return false;
            }
            return true;
        }
    }
    public enum GuessResult
    {
        guessTrue,
        guessFalse,
        guessSame
    }
}