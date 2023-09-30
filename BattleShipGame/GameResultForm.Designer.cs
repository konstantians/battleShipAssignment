namespace BattleShipGame
{
    partial class GameResultForm
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
            this.victoryAndDefeatLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.playAgainButton = new BattleShipGame.CustomControls.CustomButton();
            this.exitButton = new BattleShipGame.CustomControls.CustomButton();
            this.SuspendLayout();
            // 
            // victoryAndDefeatLabel
            // 
            this.victoryAndDefeatLabel.AutoSize = true;
            this.victoryAndDefeatLabel.BackColor = System.Drawing.Color.Transparent;
            this.victoryAndDefeatLabel.Font = new System.Drawing.Font("Stencil", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.victoryAndDefeatLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.victoryAndDefeatLabel.Location = new System.Drawing.Point(91, 21);
            this.victoryAndDefeatLabel.Name = "victoryAndDefeatLabel";
            this.victoryAndDefeatLabel.Size = new System.Drawing.Size(129, 34);
            this.victoryAndDefeatLabel.TabIndex = 0;
            this.victoryAndDefeatLabel.Text = "Defeat!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Do You Want To Play Again?";
            // 
            // playAgainButton
            // 
            this.playAgainButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.playAgainButton.BackColor = System.Drawing.Color.Transparent;
            this.playAgainButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.playAgainButton.BackgroundImage = global::BattleShipGame.Properties.Resources.yesButtonImage;
            this.playAgainButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playAgainButton.BorderColor = System.Drawing.Color.Green;
            this.playAgainButton.BorderRadius = 0;
            this.playAgainButton.BorderSize = 1;
            this.playAgainButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playAgainButton.FlatAppearance.BorderSize = 0;
            this.playAgainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playAgainButton.ForeColor = System.Drawing.Color.White;
            this.playAgainButton.Location = new System.Drawing.Point(50, 115);
            this.playAgainButton.Name = "playAgainButton";
            this.playAgainButton.Size = new System.Drawing.Size(70, 60);
            this.playAgainButton.TabIndex = 7;
            this.playAgainButton.TextColor = System.Drawing.Color.White;
            this.playAgainButton.UseVisualStyleBackColor = false;
            this.playAgainButton.Click += new System.EventHandler(this.playAgainButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.exitButton.BackgroundImage = global::BattleShipGame.Properties.Resources.exitButtonImage;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitButton.BorderColor = System.Drawing.Color.Green;
            this.exitButton.BorderRadius = 0;
            this.exitButton.BorderSize = 1;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(180, 115);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(70, 60);
            this.exitButton.TabIndex = 6;
            this.exitButton.TextColor = System.Drawing.Color.White;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // GameResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BattleShipGame.Properties.Resources.controlPanelBackGroundImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.playAgainButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.victoryAndDefeatLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameResultForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label victoryAndDefeatLabel;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomButton exitButton;
        private CustomControls.CustomButton playAgainButton;
    }
}