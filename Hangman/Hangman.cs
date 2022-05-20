using System;
using System.Windows.Forms;

namespace Hangman
{
    public partial class FrmHangman : Form
    {
        public FrmHangman()
        {
            InitializeComponent();
        }

        // Declaring, initializing, and instantiating new BodyParts object
        // Populates Body Parts
        private BodyParts bp = new BodyParts();

        // Declaring, initializing, and instantiating WordBank object
        // Populates contents of Word Bank
        private WordBank wb = new WordBank();

        // Declaring GamePlay class data member
        private GamePlay gp;

        // Stores the value for the selected answer
        // Initialized to 1 to initialize word selection in WordBank class
        private string theWord = "1";

        /// <summary>
        /// Hangman Form Load Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HangmanFrm_LoadEventHandler(object sender, EventArgs e)
        {
            // Setting answer label to false before label manipulation
            lblGeneratedWrd.Visible = false;

            // Hiding guessed letters label before manipulation
            lblGuessed.Visible = false;

            // Generating random answer
            theWord = wb.ChooseWord(theWord.Length);

            // Instantiating GamePlay class
            gp = new GamePlay(theWord.Length);

            // Setting answer label to number of chars from answer word
            lblGeneratedWrd.Text = "";
            for(int i = 0; i < theWord.Length; i++)
            {
                lblGeneratedWrd.Text += "_ ";
            }
            // Setting answer label visibility to true after label is manipulated
            lblGeneratedWrd.Visible = true;

            // Initializing and displaying guessed letters label
            lblGuessed.Text = "";
            lblGuessed.Visible = true;
        }

        /// <summary>
        /// Guess Letter Button Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGuess_ClickEventHandler(object sender, EventArgs e)
        {
            // Confirms user input to be a singular letter
            if(char.TryParse(txtLttrGuess.Text, out char lttrGuess))
            {

            }
            // Alerts user to input a singular letter
            else
            {
                MessageBox.Show("ERROR: Please enter a letter");
                return;
            }

            // Initializing counter to handle indexes of bool List
            int cnt = 0;
            
            // Prevents repeatedly guessed letters
            if (gp.GuessLetters.Contains(lttrGuess))
            {
                MessageBox.Show("You have already guessed the letter " + lttrGuess);
                return;
            }

            // Confirming user input matches at least one letter from the answer
            else if (gp.Guess(lttrGuess, theWord))
            {
                // Reinitializing label to empty string for repopulation
                lblGeneratedWrd.Text = "";

                // Appending current guess to guessed letters label
                lblGuessed.Text += txtLttrGuess.Text.ToUpper() + ", ";

                // Reinitializing counter for answer label manipulation
                cnt = 0;
                foreach(bool one in gp.Matched)
                {
                    if (one)
                        lblGeneratedWrd.Text += theWord[cnt];
                    else
                        lblGeneratedWrd.Text += "_ ";
                    cnt++;
                }

                // Win assertion
                if (!gp.Win())
                    return;

                // Win event alert
                MessageBox.Show("Congratulations! You have correctly guessed Hangman. The word was " + theWord.ToUpper() + "\n\nClick the New Word button for a different word\nClick the Exit button to leave the game");
                return;
            }
            // User input does not match any letters from the answer
            else
                // Appending current guess to guessed letters label
                lblGuessed.Text += txtLttrGuess.Text.ToUpper() + ", ";                

            // True on final attempt
            bool isDone = bp.HangNext();

            // Adds updated body part to ListBox
            lstbxWordBank.Items.Add(bp.LastHung());

            // Lose event alert after final attempt
            if (isDone)
            {
                MessageBox.Show("You've exceeded the alloted number of chances, the word was " + theWord.ToUpper());
                MessageBox.Show("Click on the New Word button to try again or the Exit button to leave the game");
                return;
            } 
        }

        private void BtnNewWord_ClickEventHandler(object sender, EventArgs e)
        {
            // Reinitializing Body Part attributes
            bp.NewWord();

            // Clearing list of Body Parts
            lstbxWordBank.Items.Clear();

            // Setting answer label to false before label manipulation
            lblGeneratedWrd.Visible = false;

            // Hiding guessed letters label before manipulation
            lblGuessed.Visible = false;

            // Generating random answer
            theWord = wb.ChooseWord(theWord.Length);

            // Reinitializing guessed letters and matches
            gp.NewWord(theWord.Length);

            // Reinitializing answer and guessed letter labels to empty strings for update
            lblGeneratedWrd.Text = "";
            lblGuessed.Text = "";

            // Setting answer label to number of chars from answer word
            for (int i = 0; i < theWord.Length; i++)
            {
                lblGeneratedWrd.Text += "_ ";
            }

            // Setting answer and guessed letter labels visibility to true after label manipulation
            lblGeneratedWrd.Visible = true;
            lblGuessed.Visible = true;
        }

        /// <summary>
        /// Terminates program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_ClickEventHandler(object sender, EventArgs e)
        {
            this.Close();
            return;
        }
    }
}
