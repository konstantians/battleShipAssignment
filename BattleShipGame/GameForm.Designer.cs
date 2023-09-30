namespace BattleShipGame
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.backroungImageChangerTimer = new System.Windows.Forms.Timer(this.components);
            this.mySmallShipsPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.myBigShipsPanel = new System.Windows.Forms.Panel();
            this.enemySmallShipsPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.enemyBigShipsPanel = new System.Windows.Forms.Panel();
            this.showShootingFormButton = new BattleShipGame.CustomControls.CustomButton();
            this.cheatButton = new BattleShipGame.CustomControls.CustomButton();
            this.checkIfShootingFormIsMinizedTimer = new System.Windows.Forms.Timer(this.components);
            this.playerAnimationAndEnemyTurnTimer = new System.Windows.Forms.Timer(this.components);
            this.staticEffectsTimer = new System.Windows.Forms.Timer(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.winnerTimer = new System.Windows.Forms.Timer(this.components);
            this.mySmallShipsPanel.SuspendLayout();
            this.enemySmallShipsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // backroungImageChangerTimer
            // 
            this.backroungImageChangerTimer.Tick += new System.EventHandler(this.backroungImageChangerTimer_Tick);
            // 
            // mySmallShipsPanel
            // 
            this.mySmallShipsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mySmallShipsPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mySmallShipsPanel.BackgroundImage")));
            this.mySmallShipsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mySmallShipsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mySmallShipsPanel.Controls.Add(this.label1);
            this.mySmallShipsPanel.Location = new System.Drawing.Point(-1, 370);
            this.mySmallShipsPanel.Name = "mySmallShipsPanel";
            this.mySmallShipsPanel.Size = new System.Drawing.Size(212, 190);
            this.mySmallShipsPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(26, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your Fleet Status";
            // 
            // myBigShipsPanel
            // 
            this.myBigShipsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.myBigShipsPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("myBigShipsPanel.BackgroundImage")));
            this.myBigShipsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.myBigShipsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myBigShipsPanel.Location = new System.Drawing.Point(210, 400);
            this.myBigShipsPanel.Name = "myBigShipsPanel";
            this.myBigShipsPanel.Size = new System.Drawing.Size(211, 160);
            this.myBigShipsPanel.TabIndex = 2;
            // 
            // enemySmallShipsPanel
            // 
            this.enemySmallShipsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.enemySmallShipsPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("enemySmallShipsPanel.BackgroundImage")));
            this.enemySmallShipsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.enemySmallShipsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.enemySmallShipsPanel.Controls.Add(this.label2);
            this.enemySmallShipsPanel.Location = new System.Drawing.Point(708, 370);
            this.enemySmallShipsPanel.Name = "enemySmallShipsPanel";
            this.enemySmallShipsPanel.Size = new System.Drawing.Size(212, 190);
            this.enemySmallShipsPanel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(26, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enemy Fleet Status";
            // 
            // enemyBigShipsPanel
            // 
            this.enemyBigShipsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.enemyBigShipsPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("enemyBigShipsPanel.BackgroundImage")));
            this.enemyBigShipsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.enemyBigShipsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.enemyBigShipsPanel.Location = new System.Drawing.Point(497, 400);
            this.enemyBigShipsPanel.Name = "enemyBigShipsPanel";
            this.enemyBigShipsPanel.Size = new System.Drawing.Size(212, 160);
            this.enemyBigShipsPanel.TabIndex = 4;
            // 
            // showShootingFormButton
            // 
            this.showShootingFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showShootingFormButton.BackColor = System.Drawing.Color.Transparent;
            this.showShootingFormButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.showShootingFormButton.BackgroundImage = global::BattleShipGame.Properties.Resources.playButtonImage;
            this.showShootingFormButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.showShootingFormButton.BorderColor = System.Drawing.Color.Gray;
            this.showShootingFormButton.BorderRadius = 0;
            this.showShootingFormButton.BorderSize = 2;
            this.showShootingFormButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showShootingFormButton.FlatAppearance.BorderSize = 0;
            this.showShootingFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showShootingFormButton.ForeColor = System.Drawing.Color.White;
            this.showShootingFormButton.Location = new System.Drawing.Point(209, 370);
            this.showShootingFormButton.Name = "showShootingFormButton";
            this.showShootingFormButton.Size = new System.Drawing.Size(39, 31);
            this.showShootingFormButton.TabIndex = 5;
            this.showShootingFormButton.TextColor = System.Drawing.Color.White;
            this.showShootingFormButton.UseVisualStyleBackColor = false;
            this.showShootingFormButton.Visible = false;
            this.showShootingFormButton.Click += new System.EventHandler(this.showShootingFormButton_Click);
            // 
            // cheatButton
            // 
            this.cheatButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cheatButton.BackColor = System.Drawing.Color.Transparent;
            this.cheatButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.cheatButton.BackgroundImage = global::BattleShipGame.Properties.Resources.cheatButton;
            this.cheatButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cheatButton.BorderColor = System.Drawing.Color.Gray;
            this.cheatButton.BorderRadius = 0;
            this.cheatButton.BorderSize = 2;
            this.cheatButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cheatButton.FlatAppearance.BorderSize = 0;
            this.cheatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cheatButton.ForeColor = System.Drawing.Color.White;
            this.cheatButton.Location = new System.Drawing.Point(245, 370);
            this.cheatButton.Name = "cheatButton";
            this.cheatButton.Size = new System.Drawing.Size(39, 31);
            this.cheatButton.TabIndex = 6;
            this.cheatButton.TextColor = System.Drawing.Color.White;
            this.cheatButton.UseVisualStyleBackColor = false;
            this.cheatButton.Click += new System.EventHandler(this.cheatButton_Click);
            // 
            // checkIfShootingFormIsMinizedTimer
            // 
            this.checkIfShootingFormIsMinizedTimer.Enabled = true;
            this.checkIfShootingFormIsMinizedTimer.Tick += new System.EventHandler(this.checkIfShootingFormIsMinizedTimer_Tick);
            // 
            // playerAnimationAndEnemyTurnTimer
            // 
            this.playerAnimationAndEnemyTurnTimer.Enabled = true;
            this.playerAnimationAndEnemyTurnTimer.Interval = 25;
            this.playerAnimationAndEnemyTurnTimer.Tick += new System.EventHandler(this.enemyTurnCheckerTimer_Tick);
            // 
            // staticEffectsTimer
            // 
            this.staticEffectsTimer.Enabled = true;
            this.staticEffectsTimer.Tick += new System.EventHandler(this.staticEffectsTimer_Tick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImage = global::BattleShipGame.Properties.Resources.airplane;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel5.Location = new System.Drawing.Point(-55, 230);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(57, 37);
            this.panel5.TabIndex = 7;
            // 
            // winnerTimer
            // 
            this.winnerTimer.Enabled = true;
            this.winnerTimer.Interval = 25;
            this.winnerTimer.Tick += new System.EventHandler(this.winnerTimer_Tick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BattleShipGame.Properties.Resources.surface0;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(920, 560);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.cheatButton);
            this.Controls.Add(this.showShootingFormButton);
            this.Controls.Add(this.enemyBigShipsPanel);
            this.Controls.Add(this.enemySmallShipsPanel);
            this.Controls.Add(this.myBigShipsPanel);
            this.Controls.Add(this.mySmallShipsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.mySmallShipsPanel.ResumeLayout(false);
            this.mySmallShipsPanel.PerformLayout();
            this.enemySmallShipsPanel.ResumeLayout(false);
            this.enemySmallShipsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer backroungImageChangerTimer;
        private System.Windows.Forms.Panel mySmallShipsPanel;
        private System.Windows.Forms.Panel myBigShipsPanel;
        private System.Windows.Forms.Panel enemySmallShipsPanel;
        private System.Windows.Forms.Panel enemyBigShipsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomButton showShootingFormButton;
        private CustomControls.CustomButton cheatButton;
        private System.Windows.Forms.Timer checkIfShootingFormIsMinizedTimer;
        private System.Windows.Forms.Timer playerAnimationAndEnemyTurnTimer;
        private System.Windows.Forms.Timer staticEffectsTimer;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Timer winnerTimer;
    }
}