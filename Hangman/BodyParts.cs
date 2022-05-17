using System.Collections.Generic;

namespace Hangman
{
    internal class BodyParts
    {
        public int AttemptsRemain { get; private set; }
        public string CurrentBodyPart { get; private set; }
        public string NextBodyPart { get; private set; }
        private int CurrentBodyIndex { get; set; }
        private List<string> AllBody { get; set; }

        /// <summary>
        /// BodyParts Parameterized Constructor
        /// PopulateBody() Helper
        /// Current and Next Body Part initialized
        /// Remaining Attempts initialized
        /// </summary>
        /// <param name="numAttempts"></param>
        public BodyParts(int numAttempts)
        {
            CurrentBodyIndex = 0;
            PopulateBody();
            CurrentBodyPart = AllBody[CurrentBodyIndex];
            NextBodyPart = AllBody[CurrentBodyIndex + 1];
            AttemptsRemain = numAttempts;
        }

        /// <summary>
        /// UpdateAttempt() Helper
        /// </summary>
        public void AttemptHelp()
        {
            UpdateAttempt();
        }

        /// <summary>
        /// Decrements Number of Remaining Attempts
        /// </summary>
        private void UpdateAttempt()
        {
            AttemptsRemain--;
        }

        /// <summary>
        /// BodyPartsUpdate() Helper
        /// </summary>
        public void Update()
        {
            BodyPartsUpdate();
        }

        /// <summary>
        /// Increments CurrentBodyIndex
        /// Updates Current and Next Body Part by default
        /// Updates Current Body Part and sets Next Body Part if user is on last attempt of game
        /// </summary>
        private void BodyPartsUpdate()
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
        /// Initializes list of strings for body parts
        /// Populates all body parts
        /// </summary>
        private void PopulateBody()
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
    }
}
