using System.Collections.Generic;

namespace Hangman
{
    public enum GuessResult
    {
        match,
        noMatch,
        win,
        lose,
        duplicate
    }

    /// <summary>
    /// Tracks matching characters with answer key
    /// Tracks previously guessed letters
    /// </summary>
    internal class GamePlay
    {
        private List<char> GuessLetters { get; set; }
        private List<bool> Matched { get; set; }
        private string Word { get; set; }

        /// <summary>
        /// GamePlay Parameterized Constructor
        /// Constructor initializes properties
        /// Matched initialized to false based on length of answer
        /// </summary>
        /// <param name="wordLen"></param>
        public GamePlay(string word)
        {
            Matched = new List<bool>();
            GuessLetters = new List<char>();
            for (int i = 0; i < word.Length; i++)
            {
                Matched.Add(false);
            }
            Word = word;
        }

        /// <summary>
        /// Determines if guessed letter is a criteria from the answer
        /// Adds current letter to GuessedLetters
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public GuessResult Guess(char letter)
        {
            if (Win())
                return GuessResult.win;
            else if(GuessLetters.Contains(letter))
                return GuessResult.duplicate;
            else if (Word.Contains(letter))
            {
                GuessLetters.Add(letter);
                int cnt = 0;
                foreach(char c in Word)
                {
                    if (c == letter)
                        Matched[cnt] = true;
                    cnt++;
                }
                return GuessResult.match;
            }
            else
            {
                GuessLetters.Add(letter);
                return GuessResult.noMatch;
            }
        }
        public string Hint()
        {
            // Initializing counter for minimum letters remaining requirement
            int win = 0;

            // Assertion ensures more than one or more letters to be guessed remain
            foreach (bool one in Matched)
            {
                // 2 minimum remaining letters required for a hint
                if (one)
                    win++;

                // Internally exits once only final letter to answer remains
                if (win >= Matched.Count - 1)
                    return "More than two remaining letters are required for a hint\n\nSORRY";
            }

            // Setting hint index to true
            int index = 0;
            while (Matched[index])
            {
                index++;
            }
            Matched[index] = true;

            // Adding hint to guessed letters
            char subtle = Word[index];
            GuessLetters.Add(subtle);

            // Appending hint to guessed letters label
            string letter = string.Format("{0}", subtle);
            

            // Setting all indexes matching hint to true
            // Used for repeated letters
            index = 0;
            foreach (char let in Word)
            {
                if (let == subtle)
                    Matched[index] = true;
                index++;
            }

            // Returns hint or message needing more available guesses
            return letter;
        }
        public string DisplayState()
        {
            string manip = "";
            int cnt = 0;
            foreach (bool one in Matched)
            {
                if (one)
                    manip += Word[cnt];
                else
                    manip += "_ ";
                cnt++;
            }
            return manip;
        }

        /// <summary>
        /// Confirms user guessed all required letters
        /// </summary>
        /// <returns></returns>
        private bool Win()
        {
            foreach(bool one in Matched)
            {
                if (!one)
                    return false;
            }
            return true;
        }
    }
}