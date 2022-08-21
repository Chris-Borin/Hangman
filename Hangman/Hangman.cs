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

        // Declaring and initializing BodyParts object
        private BodyParts bp;

        // Declaring, initializing, and instantiating WordBank object
        // Populates contents of Word Bank
        private WordBank wb = new WordBank();

        // Declaring GamePlay class data member
        private GamePlay gp;

        // Stores the value for the selected answer
        // Initialized to empty string for initializing word selection in WordBank class
        private string theWord = "";

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
            gp = new GamePlay(theWord);

            // Instantiating BodyParts class
            bp = new BodyParts();

            // Setting answer label to number of chars from answer word
            lblGeneratedWrd.Text = gp.DisplayState();

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
            if (!char.TryParse(txtLttrGuess.Text, out char lttrGuess))
            {
                // Alerts user to input a singular letter
                MessageBox.Show("ERROR: Please enter a letter");
                return;
            }

            // Determining guess result
            // Executes based on result value
            switch (gp.Guess(lttrGuess))
            {
                // Guessed letter is a match
                case GuessResult.match:

                    // Confirming final attempt by incrementing Body Part index
                    if (!bp.HangNext())
                    {
                        // Lose event message
                        MessageBox.Show(string.Concat(gp.losePrompt, gp.prePrompt) + theWord.ToUpper() + gp.prompt);
                        return;
                    }

                    // Decrements Body Part index if not final attempt
                    bp.Hint();

                    // Reinitializing label to empty string for repopulation
                    lblGeneratedWrd.Text = gp.DisplayState();

                    // Appending current guess to guessed letters label
                    lblGuessed.Text += txtLttrGuess.Text.ToUpper() + ", ";
                    
                    // Confirming win output
                    if (gp.Guess(lttrGuess) == GuessResult.win)
                        break;
                    else
                        return;

                // Guessed letter is not a match
                case GuessResult.noMatch:

                    // Confirms conclusion of game
                    if (bp.HangNext())
                    {
                        // Adds updated Body Part to ListBox
                        lstbxWordBank.Items.Add(bp.LastHung());

                        // Appending current guess to guessed letters label
                        lblGuessed.Text += txtLttrGuess.Text.ToUpper() + ", ";
                    }

                    // Confirms for final attempt by incrementing Body Part index
                    if (!bp.HangNext())
                    {
                        // Lose event message
                        MessageBox.Show(string.Concat(gp.losePrompt, gp.prePrompt) + theWord.ToUpper() + gp.prompt);
                        return;
                    }

                    // Decrements Body Part index after checking for final attempt
                    bp.Hint();
                    return;

                // Current guessed letter has previously been attempted
                case GuessResult.duplicate:
                    MessageBox.Show("You have already guessed the letter " + lttrGuess);
                    return;
            }

            // Win event message
            MessageBox.Show(string.Concat(gp.winPrompt, gp.prePrompt) + theWord.ToUpper() + gp.prompt.Substring(0, 88));
            return;
        }

        /// <summary>
        /// New Word button Click Event Handler
        /// Generates a new answer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewWord_ClickEventHandler(object sender, EventArgs e)
        {
            // Reinitializing labels and answer
            HangmanFrm_LoadEventHandler(sender, e);

            // Clearing list of Body Parts
            lstbxWordBank.Items.Clear();
        }

        /// <summary>
        /// Exit button Click Event Handler
        /// Terminates program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_ClickEventHandler(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        /// <summary>
        /// Hint button Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHint_ClickEventHandler(object sender, EventArgs e)
        {
            // Needing more than 2 remaining letters doesn't work with strawberry when remaining letter is r

            // Confirms end of game
            if (!bp.HangNext())
                BtnNewWord_ClickEventHandler(sender, e);

            // Decrements Body Part index if not end of game
            else
                bp.Hint();

            // Determines hint availability
            string hint = gp.Hint(bp);

            // If more than 1 char, it is a MessageBox
            if (hint.Length > 1)
            {
                MessageBox.Show(hint);
                return;
            }

            // Adds updated body part to ListBox
            else
            {
                lblGuessed.Text += hint.ToUpper() + ", ";
                lstbxWordBank.Items.Add(bp.LastHung());
            }

            // Reinitializing answer label for manipulation
            lblGeneratedWrd.Visible = false;
            lblGeneratedWrd.Text = gp.DisplayState();

            // Displaying answer label
            lblGeneratedWrd.Visible = true;
        }
    }
}