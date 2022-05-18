using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hangman
{
    public partial class FrmHangman : Form
    {
        public FrmHangman()
        {
            InitializeComponent();
        }

        // Declaring and initializing list of BodyParts objects
        private List<BodyParts> prompts = new List<BodyParts>();

        // Declaring and initializing list of bools
        private List<bool> match = new List<bool>();

        // Stores all letters which have been attempted
        private string guessLetters = "";

        // Declaring, initializing, and instantiating new BodyParts object
        // Populates Body Parts
        private BodyParts bp = new BodyParts();

        // Declaring, initializing, and instantiating WordBank object
        // Populates contents of Word Bank
        private WordBank wb = new WordBank();

        /// <summary>
        /// Hangman Form Load Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HangmanFrm_LoadEventHandler(object sender, EventArgs e)
        {
            // Initializing Body Parts attributes
            bp.NewWord();

            // Setting answer label to false before label manipulation
            lblGeneratedWrd.Visible = false;

            // Hiding guessed letters label before manipulation
            lblGuessed.Visible = false;

            // Displaying contents of Word Bank with numerical order
            for(int i = 0; i < wb.WordsList.Count; i++)
            {
                lstbxWordBank.Items.Add(i+1 + ". " + wb.WordsList[i]);
            }

            // Generating random answer
            Random rand = new Random();
            int generatedWrd = rand.Next(wb.WordsList.Count);
            string displayWrd = wb.WordsList[generatedWrd];
            wb.ChosenWord(displayWrd);

            // Initializing length of progress bar
            prgrssBarWrd.Maximum = wb.Word.Length;
            
            // Initializing Data Source of Grid View
            prompts.Add(bp);

            // Setting answer label to number of chars from answer word
            lblGeneratedWrd.Text = "";
            for(int i = 0; i < wb.Word.Length; i++)
            {
                lblGeneratedWrd.Text += "_ ";
            }
            // Setting answer label visibility to true after label is manipulated
            lblGeneratedWrd.Visible = true;

            // Binding DataSource of Hangman Grid View to prompts List
            gvHangman.DataSource = prompts;

            // Manipulating header text of Grid View for UX
            gvHangman.Columns[0].HeaderText = "Attempts Remaining";
            gvHangman.Columns[1].HeaderText = "Current Body Part";
            gvHangman.Columns[2].HeaderText = "Next Body Part";

            // Allocating List of bools for letter assertions
            foreach (char word in wb.Word)
            {
                match.Add(false);
            }

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

            // Confirming user input matches at least one letter from the answer
            if (wb.Word.Contains(txtLttrGuess.Text) && !guessLetters.Contains(txtLttrGuess.Text))
            {
                // Reinitializing label to empty string for repopulation
                lblGeneratedWrd.Text = "";

                guessLetters += txtLttrGuess.Text;
                lblGuessed.Text += txtLttrGuess.Text.ToUpper() + ", ";

                // Keeps track of which letters have been already guessed
                foreach (char word in wb.Word)
                {
                    if(word == lttrGuess)
                    {
                        match[cnt] = true;
                        // Incrementing progress bar based on number of correctly guessed letters
                        if(bp.AttemptsRemain > -1)
                            prgrssBarWrd.Value++;
                    }
                    // Incrementing counter to account for List of bools indexes
                    cnt++;
                }

                // Reinitializing counter for answer label manipulation
                cnt = 0;
                foreach(bool one in match)
                {
                    if (one)
                        lblGeneratedWrd.Text += wb.Word[cnt];
                    else
                        lblGeneratedWrd.Text += "_ ";
                    cnt++;
                }

                // Win assertion
                foreach (bool two in match)
                {
                    if (two)
                        continue;
                    else
                        return;
                }
                // Win event alert
                MessageBox.Show("Congratulations! You have correctly guessed Hangman. The word was " + wb.Word.ToUpper());
                this.Close();
                return;
            }

            // Prevents repeatedly guessed letters
            else if (guessLetters.Contains(txtLttrGuess.Text))
            {
                MessageBox.Show("You have already guessed the letter " + txtLttrGuess.Text);
                return;
            }

            // User input does not match any letters from the answer
            else
            {
                guessLetters += txtLttrGuess.Text;
                lblGuessed.Text += txtLttrGuess.Text.ToUpper() + ", ";

                // Updates body parts and remaining attempts based on remaining attempts
                if (bp.AttemptsRemain > 0)
                    bp.BodyPartsUpdate();
                else
                    bp.AttemptUpdate();
            }

            // Reinitializing Data Source of Grid View
            gvHangman.DataSource = null;
            gvHangman.DataSource = prompts;

            // Manipulating header text of Grid View for UX
            gvHangman.Columns[0].HeaderText = "Attempts Remaining";
            gvHangman.Columns[1].HeaderText = "Current Body Part";
            gvHangman.Columns[2].HeaderText = "Next Body Part";

            // Number of attempts exceeded
            // Outputs alert message
            // Closes form
            if (bp.AttemptsRemain == -1)
            {
                // Lose event alert
                MessageBox.Show("You've exceeded the alloted number of chances, the word was " + wb.Word.ToUpper());
                this.Close();
                return;
            }
        }

        private void BtnNewWord_ClickEventHandler(object sender, EventArgs e)
        {
            // Reinitializing label of guessed letters
            guessLetters = "";

            // Setting answer label to false before label manipulation
            lblGeneratedWrd.Visible = false;

            // Hiding guessed letters label before manipulation
            lblGuessed.Visible = false;

            // Generating random answer
            Random rand = new Random();
            int generatedWrd = rand.Next(wb.WordsList.Count);
            string displayWrd = wb.WordsList[generatedWrd];
            wb.ChosenWord(displayWrd);

            // Setting answer label to number of chars from answer word
            lblGeneratedWrd.Text = "";
            lblGuessed.Text = "";
            for (int i = 0; i < wb.Word.Length; i++)
            {
                lblGeneratedWrd.Text += "_ ";
            }
            // Setting answer label visibility to true after label is manipulated
            lblGeneratedWrd.Visible = true;
            lblGuessed.Visible = true;

            // Reinitializing Data Source of Grid View
            gvHangman.DataSource = null;
            gvHangman.DataSource = prompts;

            // Manipulating header text of Grid View for UX
            gvHangman.Columns[0].HeaderText = "Attempts Remaining";
            gvHangman.Columns[1].HeaderText = "Current Body Part";
            gvHangman.Columns[2].HeaderText = "Next Body Part";

            // Reinitializing progress bar value
            prgrssBarWrd.Value = 0;

            // Reinitializing List of bools for letter assertions
            match.Clear();
            foreach (char word in wb.Word)
            {
                match.Add(false);
            }

            // Reinitializing Body Part attributes
            bp.NewWord();
        }
    }
}
