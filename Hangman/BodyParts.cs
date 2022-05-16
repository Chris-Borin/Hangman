using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class BodyParts
    {
        public int AttemptsRemain { get; set; }
        public string CurrentBodyPart { get; set; }
        public string NextBodyPart { get; set; }
        public int CurrentBodyIndex { get; set; }
        public List<string> AllBody { get; set; }

        /// <summary>
        /// BodyParts Parameterized Constructor
        /// PopulateBody() called
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
        /// Increments CurrentBodyIndex
        /// Updates Current and Next Body Part by default
        /// Updates Current Body Part and sets Next Body Part if user is on last attempt of game
        /// </summary>
        public void BodyPartsUpdate()
        {
            CurrentBodyIndex++;
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
        public void PopulateBody()
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
