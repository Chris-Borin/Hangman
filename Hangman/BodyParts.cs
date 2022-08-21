using System.Collections.Generic;

namespace Hangman
{
    internal class BodyParts
    {
        private int CurrentBodyIndex { get; set; }
        private List<string> AllBody { get; set; }

        /// <summary>
        /// BodyParts Parameterized Constructor
        /// Constructor initializes and populates AllBody
        /// Initializes index of inital body part
        /// </summary>
        /// <param name="numAttempts"></param>
        public BodyParts()
        {
            AllBody = new List<string>();
            AllBody.Add("None");
            AllBody.Add("               Head");
            AllBody.Add("               Torso");
            AllBody.Add("Left Arm");
            AllBody.Add("                     Right Arm");
            AllBody.Add("Left Leg");
            AllBody.Add("                     Right Leg");
            CurrentBodyIndex = 0;
        }

        /// <summary>
        /// Body part index increments
        /// Returns true on last attempt
        /// </summary>
        /// <returns></returns>
        public bool HangNext()
        {
            CurrentBodyIndex++;
            return CurrentBodyIndex <= AllBody.Count - 1;
        }

        /// <summary>
        /// Returns current body part index
        /// </summary>
        /// <returns></returns>
        public string LastHung()
        {
            return AllBody[CurrentBodyIndex];
        }

        /// <summary>
        /// Decrements when no more body parts are available
        /// </summary>
        public void Hint()
        {
            CurrentBodyIndex--;
        }
    }
}
