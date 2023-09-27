namespace BattleShipGame
{
    partial class GameEntryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonTimer = new System.Windows.Forms.Timer(this.components);
            this.startGameButton = new BattleShipGame.CustomControls.CustomButton();
            this.SuspendLayout();
            // 
            // buttonTimer
            // 
            this.buttonTimer.Enabled = true;
            this.buttonTimer.Tick += new System.EventHandler(this.buttonTimer_Tick);
            // 
            // startGameButton
            // 
            this.startGameButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startGameButton.BackColor = System.Drawing.Color.Transparent;
            this.startGameButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.startGameButton.BackgroundImage = global::BattleShipGame.Properties.Resources.playButtonImage;
            this.startGameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startGameButton.BorderColor = System.Drawing.Color.Green;
            this.startGameButton.BorderRadius = 0;
            this.startGameButton.BorderSize = 0;
            this.startGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startGameButton.FlatAppearance.BorderSize = 0;
            this.startGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startGameButton.ForeColor = System.Drawing.Color.White;
            this.startGameButton.Location = new System.Drawing.Point(410, 350);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(95, 95);
            this.startGameButton.TabIndex = 6;
            this.startGameButton.TextColor = System.Drawing.Color.White;
            this.startGameButton.UseVisualStyleBackColor = false;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // GameEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.BackgroundImage = global::BattleShipGame.Properties.Resources.gameStartingMenuImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(920, 560);
            this.Controls.Add(this.startGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.CustomButton startGameButton;
        private System.Windows.Forms.Timer buttonTimer;
    }
}