namespace Hangman
{
    partial class FrmHangman
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHangman));
            this.prgrssBarWrd = new System.Windows.Forms.ProgressBar();
            this.txtLttrGuess = new System.Windows.Forms.TextBox();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.lblGeneratedWrd = new System.Windows.Forms.Label();
            this.btnGuessLttr = new System.Windows.Forms.Button();
            this.gvHangman = new System.Windows.Forms.DataGridView();
            this.lblProgressBar = new System.Windows.Forms.Label();
            this.lblGuessLttrs = new System.Windows.Forms.Label();
            this.lblGuessed = new System.Windows.Forms.Label();
            this.gvWordBank = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvHangman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWordBank)).BeginInit();
            this.SuspendLayout();
            // 
            // prgrssBarWrd
            // 
            this.prgrssBarWrd.BackColor = System.Drawing.Color.White;
            this.prgrssBarWrd.ForeColor = System.Drawing.SystemColors.GrayText;
            this.prgrssBarWrd.Location = new System.Drawing.Point(216, 79);
            this.prgrssBarWrd.Name = "prgrssBarWrd";
            this.prgrssBarWrd.Size = new System.Drawing.Size(805, 34);
            this.prgrssBarWrd.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgrssBarWrd.TabIndex = 0;
            // 
            // txtLttrGuess
            // 
            this.txtLttrGuess.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLttrGuess.Location = new System.Drawing.Point(694, 247);
            this.txtLttrGuess.Name = "txtLttrGuess";
            this.txtLttrGuess.Size = new System.Drawing.Size(327, 39);
            this.txtLttrGuess.TabIndex = 2;
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrompt.Location = new System.Drawing.Point(631, 172);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(441, 32);
            this.lblPrompt.TabIndex = 4;
            this.lblPrompt.Text = "Enter the Letter you would like to Guess";
            // 
            // lblGeneratedWrd
            // 
            this.lblGeneratedWrd.AutoSize = true;
            this.lblGeneratedWrd.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGeneratedWrd.Location = new System.Drawing.Point(588, 546);
            this.lblGeneratedWrd.Name = "lblGeneratedWrd";
            this.lblGeneratedWrd.Size = new System.Drawing.Size(315, 54);
            this.lblGeneratedWrd.TabIndex = 5;
            this.lblGeneratedWrd.Text = "Generated Word";
            this.lblGeneratedWrd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGuessLttr
            // 
            this.btnGuessLttr.AutoSize = true;
            this.btnGuessLttr.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGuessLttr.Location = new System.Drawing.Point(752, 309);
            this.btnGuessLttr.Name = "btnGuessLttr";
            this.btnGuessLttr.Size = new System.Drawing.Size(206, 55);
            this.btnGuessLttr.TabIndex = 6;
            this.btnGuessLttr.Text = "Guess Letter";
            this.btnGuessLttr.UseVisualStyleBackColor = true;
            this.btnGuessLttr.Click += new System.EventHandler(this.BtnGuess_ClickEventHandler);
            // 
            // gvHangman
            // 
            this.gvHangman.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvHangman.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gvHangman.Location = new System.Drawing.Point(588, 399);
            this.gvHangman.Name = "gvHangman";
            this.gvHangman.RowHeadersWidth = 62;
            this.gvHangman.RowTemplate.Height = 33;
            this.gvHangman.Size = new System.Drawing.Size(530, 106);
            this.gvHangman.TabIndex = 7;
            // 
            // lblProgressBar
            // 
            this.lblProgressBar.AutoSize = true;
            this.lblProgressBar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProgressBar.Location = new System.Drawing.Point(487, 36);
            this.lblProgressBar.Name = "lblProgressBar";
            this.lblProgressBar.Size = new System.Drawing.Size(260, 30);
            this.lblProgressBar.TabIndex = 8;
            this.lblProgressBar.Text = "Correctly Guessed Letters";
            // 
            // lblGuessLttrs
            // 
            this.lblGuessLttrs.AutoSize = true;
            this.lblGuessLttrs.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGuessLttrs.Location = new System.Drawing.Point(35, 648);
            this.lblGuessLttrs.Name = "lblGuessLttrs";
            this.lblGuessLttrs.Size = new System.Drawing.Size(227, 38);
            this.lblGuessLttrs.TabIndex = 9;
            this.lblGuessLttrs.Text = "Guessed Letters: ";
            this.lblGuessLttrs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGuessed
            // 
            this.lblGuessed.AutoSize = true;
            this.lblGuessed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGuessed.Location = new System.Drawing.Point(268, 653);
            this.lblGuessed.Name = "lblGuessed";
            this.lblGuessed.Size = new System.Drawing.Size(72, 32);
            this.lblGuessed.TabIndex = 10;
            this.lblGuessed.Text = "blank";
            this.lblGuessed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvWordBank
            // 
            this.gvWordBank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvWordBank.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gvWordBank.Location = new System.Drawing.Point(121, 172);
            this.gvWordBank.Name = "gvWordBank";
            this.gvWordBank.RowHeadersWidth = 62;
            this.gvWordBank.RowTemplate.Height = 33;
            this.gvWordBank.Size = new System.Drawing.Size(239, 443);
            this.gvWordBank.TabIndex = 11;
            // 
            // FrmHangman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 719);
            this.Controls.Add(this.gvWordBank);
            this.Controls.Add(this.lblGuessed);
            this.Controls.Add(this.lblGuessLttrs);
            this.Controls.Add(this.lblProgressBar);
            this.Controls.Add(this.gvHangman);
            this.Controls.Add(this.btnGuessLttr);
            this.Controls.Add(this.lblGeneratedWrd);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.txtLttrGuess);
            this.Controls.Add(this.prgrssBarWrd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmHangman";
            this.Text = "Hangman";
            this.Load += new System.EventHandler(this.HangmanFrm_LoadEventHandler);
            ((System.ComponentModel.ISupportInitialize)(this.gvHangman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWordBank)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgrssBarWrd;
        private System.Windows.Forms.TextBox txtLttrGuess;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.Label lblGeneratedWrd;
        private System.Windows.Forms.Button btnGuessLttr;
        private System.Windows.Forms.DataGridView gvHangman;
        private System.Windows.Forms.Label lblProgressBar;
        private System.Windows.Forms.Label lblGuessLttrs;
        private System.Windows.Forms.Label lblGuessed;
        private System.Windows.Forms.DataGridView gvWordBank;
    }
}
