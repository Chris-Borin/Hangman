using System.Collections.Generic;

namespace Hangman
{
    internal class BodyParts
    {
        public int AttemptsRemain { get; private set; }
        public string CurrentBodyPart { get; private set; }
        public string NextBodyPart { get; private set; }
        private int CurrentBodyIndex { get; set; }
        public List<string> AllBody { get; private set; }

        /// <summary>
        /// BodyParts Parameterized Constructor
        /// Initializes list of strings for body parts
        /// Populates all body parts
        /// Current and Next Body Part initialized
        /// Remaining Attempts initialized
        /// </summary>
        /// <param name="numAttempts"></param>
        public BodyParts()
        {
            AllBody = new List<string>();
            AllBody.Add("None");
            AllBody.Add("Head");
            AllBody.Add("Torso");
            AllBody.Add("Left Arm");
            AllBody.Add("Right Arm");
            AllBody.Add("Left Leg");
            AllBody.Add("Right Leg");
        }

        /// <summary>
        /// Decrements Number of Remaining Attempts
        /// </summary>
        public void AttemptUpdate()
        {
            AttemptsRemain--;
        }

        /// <summary>
        /// Increments CurrentBodyIndex
        /// Updates Current and Next Body Part by default
        /// Updates Current Body Part and sets Next Body Part if user is on last attempt of game
        /// </summary>
        public void BodyPartsUpdate()
        {
            CurrentBodyIndex++;
            AttemptsRemain--;
            if (AllBody.Count == CurrentBodyIndex + 1)
            {
                CurrentBodyPart = NextBodyPart;
                NextBodyPart = "Last Chance";
            }
            else
            {
                CurrentBodyPart = AllBody[CurrentBodyIndex];
                NextBodyPart = AllBody[CurrentBodyIndex + 1];
            }
        }

        /// <summary>
        /// Current and Next Body Part initialized
        /// Remaining Attempts initialized
        /// </summary>
        public void NewWord()
        {
            CurrentBodyIndex = 0;
            CurrentBodyPart = AllBody[CurrentBodyIndex];
            NextBodyPart = AllBody[CurrentBodyIndex + 1];
            AttemptsRemain = 6;
        }
    }
}
