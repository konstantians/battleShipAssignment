namespace BattleShipGame
{
    partial class FormationForm
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
            this.strategyPanelLabel = new System.Windows.Forms.Label();
            this.aircraftCarrierPictureBox = new System.Windows.Forms.PictureBox();
            this.battleShipPictureBox = new System.Windows.Forms.PictureBox();
            this.frigatePictureBox = new System.Windows.Forms.PictureBox();
            this.corvettePictureBox = new System.Windows.Forms.PictureBox();
            this.submarinePictureBox = new System.Windows.Forms.PictureBox();
            this.destroyerPictureBox = new System.Windows.Forms.PictureBox();
            this.vesselPickedUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.gameStartButton = new BattleShipGame.CustomControls.CustomButton();
            this.reverseShipButton = new BattleShipGame.CustomControls.CustomButton();
            this.resetFormationButton = new BattleShipGame.CustomControls.CustomButton();
            this.autoCompleteFormationButton = new BattleShipGame.CustomControls.CustomButton();
            this.revealStartGameButtonTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.aircraftCarrierPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.battleShipPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frigatePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.corvettePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.submarinePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destroyerPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // strategyPanelLabel
            // 
            this.strategyPanelLabel.AutoSize = true;
            this.strategyPanelLabel.BackColor = System.Drawing.Color.Transparent;
            this.strategyPanelLabel.Font = new System.Drawing.Font("Stencil", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyPanelLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.strategyPanelLabel.Location = new System.Drawing.Point(299, 72);
            this.strategyPanelLabel.Name = "strategyPanelLabel";
            this.strategyPanelLabel.Size = new System.Drawing.Size(323, 44);
            this.strategyPanelLabel.TabIndex = 0;
            this.strategyPanelLabel.Text = "Strategy Panel";
            // 
            // aircraftCarrierPictureBox
            // 
            this.aircraftCarrierPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.aircraftCarrierPictureBox.BackgroundImage = global::BattleShipGame.Properties.Resources.aircraftCarrierWithGreenSkin;
            this.aircraftCarrierPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.aircraftCarrierPictureBox.Location = new System.Drawing.Point(166, 373);
            this.aircraftCarrierPictureBox.Name = "aircraftCarrierPictureBox";
            this.aircraftCarrierPictureBox.Size = new System.Drawing.Size(58, 143);
            this.aircraftCarrierPictureBox.TabIndex = 6;
            this.aircraftCarrierPictureBox.TabStop = false;
            this.aircraftCarrierPictureBox.Click += new System.EventHandler(this.aircraftCarrierPictureBox_Click);
            // 
            // battleShipPictureBox
            // 
            this.battleShipPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.battleShipPictureBox.BackgroundImage = global::BattleShipGame.Properties.Resources.battleShipWithGreenSkin;
            this.battleShipPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.battleShipPictureBox.Location = new System.Drawing.Point(87, 352);
            this.battleShipPictureBox.Name = "battleShipPictureBox";
            this.battleShipPictureBox.Size = new System.Drawing.Size(46, 164);
            this.battleShipPictureBox.TabIndex = 7;
            this.battleShipPictureBox.TabStop = false;
            this.battleShipPictureBox.Click += new System.EventHandler(this.battleShipPictureBox_Click);
            // 
            // frigatePictureBox
            // 
            this.frigatePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.frigatePictureBox.BackgroundImage = global::BattleShipGame.Properties.Resources.frigateWithGreenSkin;
            this.frigatePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.frigatePictureBox.Location = new System.Drawing.Point(87, 220);
            this.frigatePictureBox.Name = "frigatePictureBox";
            this.frigatePictureBox.Size = new System.Drawing.Size(46, 121);
            this.frigatePictureBox.TabIndex = 8;
            this.frigatePictureBox.TabStop = false;
            this.frigatePictureBox.Click += new System.EventHandler(this.frigatePictureBox_Click);
            // 
            // corvettePictureBox
            // 
            this.corvettePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.corvettePictureBox.BackgroundImage = global::BattleShipGame.Properties.Resources.corvetteWithGreenSkin;
            this.corvettePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.corvettePictureBox.Location = new System.Drawing.Point(87, 94);
            this.corvettePictureBox.Name = "corvettePictureBox";
            this.corvettePictureBox.Size = new System.Drawing.Size(46, 92);
            this.corvettePictureBox.TabIndex = 9;
            this.corvettePictureBox.TabStop = false;
            this.corvettePictureBox.Click += new System.EventHandler(this.corvettePictureBox_Click);
            // 
            // submarinePictureBox
            // 
            this.submarinePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.submarinePictureBox.BackgroundImage = global::BattleShipGame.Properties.Resources.submarineWithGreenSkin;
            this.submarinePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.submarinePictureBox.Location = new System.Drawing.Point(178, 65);
            this.submarinePictureBox.Name = "submarinePictureBox";
            this.submarinePictureBox.Size = new System.Drawing.Size(46, 121);
            this.submarinePictureBox.TabIndex = 10;
            this.submarinePictureBox.TabStop = false;
            this.submarinePictureBox.Click += new System.EventHandler(this.submarinePictureBox_Click);
            // 
            // destroyerPictureBox
            // 
            this.destroyerPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.destroyerPictureBox.BackgroundImage = global::BattleShipGame.Properties.Resources.destroyerWithGreenSKin;
            this.destroyerPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.destroyerPictureBox.Location = new System.Drawing.Point(178, 198);
            this.destroyerPictureBox.Name = "destroyerPictureBox";
            this.destroyerPictureBox.Size = new System.Drawing.Size(46, 143);
            this.destroyerPictureBox.TabIndex = 11;
            this.destroyerPictureBox.TabStop = false;
            this.destroyerPictureBox.Click += new System.EventHandler(this.destroyerPictureBox_Click);
            // 
            // vesselPickedUpdateTimer
            // 
            this.vesselPickedUpdateTimer.Enabled = true;
            this.vesselPickedUpdateTimer.Interval = 10;
            this.vesselPickedUpdateTimer.Tick += new System.EventHandler(this.vesselPickedUpdateTimer_Tick);
            // 
            // gameStartButton
            // 
            this.gameStartButton.BackColor = System.Drawing.Color.Transparent;
            this.gameStartButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.gameStartButton.BackgroundImage = global::BattleShipGame.Properties.Resources.playButtonImage;
            this.gameStartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gameStartButton.BorderColor = System.Drawing.Color.Green;
            this.gameStartButton.BorderRadius = 0;
            this.gameStartButton.BorderSize = 0;
            this.gameStartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gameStartButton.FlatAppearance.BorderSize = 0;
            this.gameStartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameStartButton.ForeColor = System.Drawing.Color.White;
            this.gameStartButton.Location = new System.Drawing.Point(654, 390);
            this.gameStartButton.Name = "gameStartButton";
            this.gameStartButton.Size = new System.Drawing.Size(102, 102);
            this.gameStartButton.TabIndex = 4;
            this.gameStartButton.TextColor = System.Drawing.Color.White;
            this.gameStartButton.UseVisualStyleBackColor = false;
            this.gameStartButton.Visible = false;
            this.gameStartButton.Click += new System.EventHandler(this.gameStartButton_Click);
            // 
            // reverseShipButton
            // 
            this.reverseShipButton.BackColor = System.Drawing.Color.Transparent;
            this.reverseShipButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.reverseShipButton.BackgroundImage = global::BattleShipGame.Properties.Resources.rotateImageButton;
            this.reverseShipButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reverseShipButton.BorderColor = System.Drawing.Color.Green;
            this.reverseShipButton.BorderRadius = 0;
            this.reverseShipButton.BorderSize = 0;
            this.reverseShipButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reverseShipButton.FlatAppearance.BorderSize = 0;
            this.reverseShipButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reverseShipButton.ForeColor = System.Drawing.Color.White;
            this.reverseShipButton.Location = new System.Drawing.Point(654, 283);
            this.reverseShipButton.Name = "reverseShipButton";
            this.reverseShipButton.Size = new System.Drawing.Size(78, 78);
            this.reverseShipButton.TabIndex = 3;
            this.reverseShipButton.TextColor = System.Drawing.Color.White;
            this.reverseShipButton.UseVisualStyleBackColor = false;
            this.reverseShipButton.Visible = false;
            this.reverseShipButton.Click += new System.EventHandler(this.reverseShipButton_Click);
            // 
            // resetFormationButton
            // 
            this.resetFormationButton.BackColor = System.Drawing.Color.Transparent;
            this.resetFormationButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.resetFormationButton.BackgroundImage = global::BattleShipGame.Properties.Resources.resetFormationButton;
            this.resetFormationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.resetFormationButton.BorderColor = System.Drawing.Color.Green;
            this.resetFormationButton.BorderRadius = 0;
            this.resetFormationButton.BorderSize = 0;
            this.resetFormationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetFormationButton.FlatAppearance.BorderSize = 0;
            this.resetFormationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetFormationButton.ForeColor = System.Drawing.Color.White;
            this.resetFormationButton.Location = new System.Drawing.Point(654, 177);
            this.resetFormationButton.Name = "resetFormationButton";
            this.resetFormationButton.Size = new System.Drawing.Size(78, 78);
            this.resetFormationButton.TabIndex = 2;
            this.resetFormationButton.TextColor = System.Drawing.Color.White;
            this.resetFormationButton.UseVisualStyleBackColor = false;
            this.resetFormationButton.Click += new System.EventHandler(this.resetFormationButton_Click);
            // 
            // autoCompleteFormationButton
            // 
            this.autoCompleteFormationButton.BackColor = System.Drawing.Color.Transparent;
            this.autoCompleteFormationButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.autoCompleteFormationButton.BackgroundImage = global::BattleShipGame.Properties.Resources.setRandomFormationButton;
            this.autoCompleteFormationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.autoCompleteFormationButton.BorderColor = System.Drawing.Color.Green;
            this.autoCompleteFormationButton.BorderRadius = 0;
            this.autoCompleteFormationButton.BorderSize = 0;
            this.autoCompleteFormationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.autoCompleteFormationButton.FlatAppearance.BorderSize = 0;
            this.autoCompleteFormationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.autoCompleteFormationButton.ForeColor = System.Drawing.Color.White;
            this.autoCompleteFormationButton.Location = new System.Drawing.Point(654, 72);
            this.autoCompleteFormationButton.Name = "autoCompleteFormationButton";
            this.autoCompleteFormationButton.Size = new System.Drawing.Size(78, 78);
            this.autoCompleteFormationButton.TabIndex = 1;
            this.autoCompleteFormationButton.TextColor = System.Drawing.Color.White;
            this.autoCompleteFormationButton.UseVisualStyleBackColor = false;
            this.autoCompleteFormationButton.Click += new System.EventHandler(this.autoCompleteFormationButton_Click);
            // 
            // revealStartGameButtonTimer
            // 
            this.revealStartGameButtonTimer.Enabled = true;
            this.revealStartGameButtonTimer.Tick += new System.EventHandler(this.revealStartGameButtonTimer_Tick);
            // 
            // FormationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BattleShipGame.Properties.Resources.controlPanelBackgroundCentralMenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(920, 560);
            this.Controls.Add(this.destroyerPictureBox);
            this.Controls.Add(this.submarinePictureBox);
            this.Controls.Add(this.corvettePictureBox);
            this.Controls.Add(this.frigatePictureBox);
            this.Controls.Add(this.battleShipPictureBox);
            this.Controls.Add(this.aircraftCarrierPictureBox);
            this.Controls.Add(this.gameStartButton);
            this.Controls.Add(this.reverseShipButton);
            this.Controls.Add(this.resetFormationButton);
            this.Controls.Add(this.autoCompleteFormationButton);
            this.Controls.Add(this.strategyPanelLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormationForm";
            this.Text = "FormationForm";
            ((System.ComponentModel.ISupportInitialize)(this.aircraftCarrierPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.battleShipPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frigatePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.corvettePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.submarinePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destroyerPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label strategyPanelLabel;
        private CustomControls.CustomButton autoCompleteFormationButton;
        private CustomControls.CustomButton resetFormationButton;
        private CustomControls.CustomButton reverseShipButton;
        private CustomControls.CustomButton gameStartButton;
        private System.Windows.Forms.PictureBox aircraftCarrierPictureBox;
        private System.Windows.Forms.PictureBox battleShipPictureBox;
        private System.Windows.Forms.PictureBox frigatePictureBox;
        private System.Windows.Forms.PictureBox corvettePictureBox;
        private System.Windows.Forms.PictureBox submarinePictureBox;
        private System.Windows.Forms.PictureBox destroyerPictureBox;
        private System.Windows.Forms.Timer vesselPickedUpdateTimer;
        private System.Windows.Forms.Timer revealStartGameButtonTimer;
    }
}