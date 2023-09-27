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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.showShootingFormButton = new BattleShipGame.CustomControls.CustomButton();
            this.cheatButton = new BattleShipGame.CustomControls.CustomButton();
            this.checkIfShootingFormIsMinizedTimer = new System.Windows.Forms.Timer(this.components);
            this.enemyTurnCheckerTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // backroungImageChangerTimer
            // 
            this.backroungImageChangerTimer.Enabled = true;
            this.backroungImageChangerTimer.Tick += new System.EventHandler(this.backroungImageChangerTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackgroundImage = global::BattleShipGame.Properties.Resources.myFleetPanelSmallerShips;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 370);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 190);
            this.panel1.TabIndex = 0;
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
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(210, 400);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(211, 160);
            this.panel3.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackgroundImage = global::BattleShipGame.Properties.Resources.enemyFleetPanelSmallerShips;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(708, 370);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 190);
            this.panel2.TabIndex = 3;
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
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackgroundImage = global::BattleShipGame.Properties.Resources.enemyFleetPanelBigShips;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(497, 400);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(212, 160);
            this.panel4.TabIndex = 4;
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
            // enemyTurnCheckerTimer
            // 
            this.enemyTurnCheckerTimer.Enabled = true;
            this.enemyTurnCheckerTimer.Tick += new System.EventHandler(this.enemyTurnCheckerTimer_Tick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BattleShipGame.Properties.Resources.surface0;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(920, 560);
            this.Controls.Add(this.cheatButton);
            this.Controls.Add(this.showShootingFormButton);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer backroungImageChangerTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomButton showShootingFormButton;
        private CustomControls.CustomButton cheatButton;
        private System.Windows.Forms.Timer checkIfShootingFormIsMinizedTimer;
        private System.Windows.Forms.Timer enemyTurnCheckerTimer;
    }
}