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
        // Initialized as populated string to initialize word selection in WordBank class
        private string theWord = "1234567890";

        // True once game has been concluded
        private bool end = false;

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
            if(!char.TryParse(txtLttrGuess.Text, out char lttrGuess))
            {
                // Alerts user to input a singular letter
                MessageBox.Show("ERROR: Please enter a letter");
                return;
            }

            // Initializing and instantiating GuessResult object
            GuessResult guessResult = new GuessResult();

            // Determining guess result
            guessResult = gp.Guess(lttrGuess);

            // Used to determine final attempt
            bool last = false;

            // Executes based on guessResult value
            switch (guessResult)
            {
                // Guessed letter is a match
                case GuessResult.match:

                    // Confirms game has not concluded
                    if (end)
                        break;

                    // Reinitializing label to empty string for repopulation
                    lblGeneratedWrd.Text = gp.DisplayState();

                    // Appending current guess to guessed letters label
                    lblGuessed.Text += txtLttrGuess.Text.ToUpper() + ", ";
                    break;

                // Guessed letter is not a match
                case GuessResult.noMatch:

                    // Confirms game has not concluded
                    if (end)
                        break;

                    // True on final attempt
                    last = bp.HangNext();

                    // Final attempt has been reached
                    if (last)
                    {
                        end = true;
                        lstbxWordBank.Items.Add(bp.LastHung());
                        MessageBox.Show("Number of alotted attempts exceeded. The word was " + theWord.ToUpper() + "\n\nClick the New Word button for a different word\nClick the Exit button to leave the game\nClick on the Hint button to reveal a letter on your next word");
                        
                        // Appending current guess to guessed letters label
                        lblGuessed.Text += txtLttrGuess.Text.ToUpper() + ", ";
                        return;
                    }
                    // Adds updated body part to ListBox
                    lstbxWordBank.Items.Add(bp.LastHung());

                    // Appending current guess to guessed letters label
                    lblGuessed.Text += txtLttrGuess.Text.ToUpper() + ", ";
                    break;

                // Guessed letter has previously been attempted
                case GuessResult.duplicate:
                    
                    // Confirms game has not concluded
                    if (end)
                        break;
                    MessageBox.Show("You have already guessed the letter " + lttrGuess);
                    break;
            }

            // Prevents user input during a finished game
            if (end)
            {
                MessageBox.Show("Number of alotted attempts exceeded. The word was " + theWord.ToUpper() + "\n\nClick the New Word button for a different word\nClick the Exit button to leave the game\nClick on the Hint button to reveal a letter on your next word");
                return;
            }

            // Result of guess reinitialized to confirm win status
            guessResult = gp.Guess(lttrGuess);

            // Win message
            if (guessResult == GuessResult.win)
            {
                MessageBox.Show("Congratulations! You have correctly guessed Hangman. The word was " + theWord.ToUpper() + "\n\nClick the New Word button for a different word\nClick the Exit button to leave the game\nClick on the Hint button to reveal a letter on your next word");
                return;
            }
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

            // Reinitializing end of game to false
            end = false;

            // Reinitializing Body Part attributes
            bp.NewWord();

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

            // Determines hint availability
            string hint = gp.Hint(end, bp);
            
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