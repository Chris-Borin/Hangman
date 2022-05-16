using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class FrmHangman : Form
    {
        public FrmHangman()
        {
            InitializeComponent();
        }

        // Declaring and initializing list of WordBank objects
        List<WordBank> words = new List<WordBank>();

        // Declaring and initializing list of BodyParts objects
        List<BodyParts> prompts = new List<BodyParts>();

        // Declaring and initializing list of bools
        List<bool> match = new List<bool>();

        // Stores randomly chosen answer
        string theWord;

        // Stores updated answer label
        string guessing;

        // Stores number of remaining attempts
        int attempts;

        // Stores all letters which have been attempted
        string guessLetters = "";

        // Declaring, initializing, and instantiating new BodyParts object with an integer argument
        // Argument is hard coded with the number of attempts available
        // 6 is the number of body parts/attempts
        BodyParts bp = new BodyParts(6);

        /// <summary>
        /// Hangman Form Load Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HangmanFrm_LoadEventHandler(object sender, EventArgs e)
        {
            // Setting answer label to false before label manipulation
            lblGeneratedWrd.Visible = false;
            attempts = bp.AttemptsRemain;

            lblGuessed.Visible = false;

            // Initializing word bank
            words.Add(new WordBank("stiiizy"));
            words.Add(new WordBank("bong"));
            words.Add(new WordBank("pipe"));
            words.Add(new WordBank("grinder"));
            words.Add(new WordBank("lighter"));
            words.Add(new WordBank("weed"));
            words.Add(new WordBank("bud"));
            words.Add(new WordBank("joint"));
            words.Add(new WordBank("dab"));
            words.Add(new WordBank("preroll"));

            // Generating random answer
            Random rand = new Random();
            int generatedWrd = rand.Next(words.Count);
            string displayWrd = words[generatedWrd].Word;
            theWord = displayWrd;

            // Initializing length of progress bar
            prgrssBarWrd.Maximum = displayWrd.Length;
            
            // Initializing Data Source of Grid View
            prompts.Add(bp);

            // Setting answer label to number of chars from answer word
            lblGeneratedWrd.Text = "";
            for(int i = 0; i < displayWrd.Length; i++)
            {
                lblGeneratedWrd.Text += "_ ";
            }
            // Setting answer label visibility to true after label is manipulated
            lblGeneratedWrd.Visible = true;

            // Binding DataSource of Hangman Grid View to prompts List
            gvHangman.DataSource = prompts;

            // Manipulating header text of Grid View for UX
            foreach(DataGridViewColumn column in gvHangman.Columns)
            {
                switch (column.Index)
                {
                    case 0:
                        column.HeaderText = "Attempts Remaining";
                        break;
                    case 1:
                        column.HeaderText = "Current Body Part";
                        break;
                    case 2:
                        column.HeaderText = "Next Body Part";
                        break;
                    case 3:
                        column.Visible = false;
                        break;
                }
            }

            // Allocating List of bools for letter assertions
            foreach (char word in theWord)
            {
                match.Add(false);
            }

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
            if (theWord.Contains(txtLttrGuess.Text) && !guessLetters.Contains(txtLttrGuess.Text))
            {
                // guessing used to store updated answer label
                guessing = lblGeneratedWrd.Text;
                // Reinitializing label to empty string for repopulation
                lblGeneratedWrd.Text = "";

                guessLetters += txtLttrGuess.Text;
                lblGuessed.Text += txtLttrGuess.Text.ToUpper() + ", ";

                // Keeps track of which letters have been already guessed
                foreach (char word in theWord)
                {
                    if(word == lttrGuess)
                    {
                        match[cnt] = true;
                        // Incrementing progress bar based on number of correctly guessed letters
                        if(attempts > -1)
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
                        lblGeneratedWrd.Text += theWord[cnt];
                    else
                        lblGeneratedWrd.Text += "_ ";
                    cnt++;
                }
                // Updating answer label for next comparison
                guessing = lblGeneratedWrd.Text;

                // Win assertion
                foreach (bool two in match)
                {
                    if (two)
                        continue;
                    else
                        return;
                }
                // Win event alert
                MessageBox.Show("Congratulations! You have correctly guessed Hangman. The word was " + theWord.ToUpper());
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
                attempts--;

                // Updates body parts and remaining attempts
                // Only updates if remaining attempts > -1 to avoid out of bounds exception
                // with body parts for user's last attempt
                if(attempts > -1)
                {
                    bp.AttemptsRemain = attempts;
                    bp.BodyPartsUpdate();
                }
            }

            // Reinitializing Data Source of Grid View
            gvHangman.DataSource = null;
            gvHangman.DataSource = prompts;

            // Manipulating header text of Grid View for UX
            foreach (DataGridViewColumn column in gvHangman.Columns)
            {
                switch (column.Index)
                {
                    case 0:
                        column.HeaderText = "Attempts Remaining";
                        break;
                    case 1:
                        column.HeaderText = "Current Body Part";
                        break;
                    case 2:
                        column.HeaderText = "Next Body Part";
                        break;
                    case 3:
                        column.Visible = false;
                        break;
                }
            }
            // Number of attempts exceeded
            // Outputs alert message
            // Closes form
            if (attempts == -1)
            {
                // Lose event alert
                MessageBox.Show("You've exceeded the alloted number of chances, the word was " + theWord.ToUpper());
                this.Close();
                return;
            }
        }
    }
}
