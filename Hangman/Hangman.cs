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
        private bool body = false;

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
                    if (body)
                        break;

                    // Reinitializing label to empty string for repopulation
                    lblGeneratedWrd.Text = gp.DisplayState();

                    // Appending current guess to guessed letters label
                    lblGuessed.Text += txtLttrGuess.Text.ToUpper() + ", ";
                    break;

                // Guessed letter is not a match
                case GuessResult.noMatch:

                    // Confirms game has not concluded
                    if (body)
                        break;

                    // True on final attempt
                    last = bp.HangNext();

                    // Final attempt has been reached
                    if (last)
                    {
                        body = true;
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
                    if (body)
                        break;
                    MessageBox.Show("You have already guessed the letter " + lttrGuess);
                    break;
            }

            // Prevents user input during a finished game
            if (body)
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
            // Reinitializing end of game to false
            body = false;

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
            gp = new GamePlay(theWord);

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
            // Stores hint char or message needing more available guesses
            string hint = gp.Hint(body);

            // If more than 20 chars, it is a MessageBox
            if (hint.Length > 20)
            {
                MessageBox.Show(hint);
                return;
            }
            else
                lblGuessed.Text += hint.ToUpper() + ", ";

            // Adds updated body part to ListBox
            if (!bp.HangNext())
                lstbxWordBank.Items.Add(bp.LastHung());

            // Assertion ensures enough Body Parts remain for a hint
            else
            {
                bp.Hint();
                MessageBox.Show("Not enough Body Parts available for another Hint");
                return;
            }

            // Reinitializing answer label for manipulation
            lblGeneratedWrd.Visible = false;
            lblGeneratedWrd.Text = gp.DisplayState();

            // Displaying answer label
            lblGeneratedWrd.Visible = true;
        }
    }
}