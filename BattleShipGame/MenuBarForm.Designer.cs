namespace BattleShipGame
{
    partial class MenuBarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuBarForm));
            this.childFormPanel = new System.Windows.Forms.Panel();
            this.checkForChangesTimer = new System.Windows.Forms.Timer(this.components);
            this.menuBarPanel = new System.Windows.Forms.Panel();
            this.mainWindowPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.audioButton = new BattleShipGame.CustomControls.CustomButton();
            this.minizeButton = new BattleShipGame.CustomControls.CustomButton();
            this.windowSizeControlButton = new BattleShipGame.CustomControls.CustomButton();
            this.exitButton = new BattleShipGame.CustomControls.CustomButton();
            this.menuBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainWindowPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // childFormPanel
            // 
            this.childFormPanel.BackColor = System.Drawing.Color.LimeGreen;
            this.childFormPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.childFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.childFormPanel.Location = new System.Drawing.Point(0, 52);
            this.childFormPanel.MinimumSize = new System.Drawing.Size(920, 560);
            this.childFormPanel.Name = "childFormPanel";
            this.childFormPanel.Size = new System.Drawing.Size(920, 566);
            this.childFormPanel.TabIndex = 3;
            // 
            // checkForChangesTimer
            // 
            this.checkForChangesTimer.Enabled = true;
            this.checkForChangesTimer.Tick += new System.EventHandler(this.checkForChangesTimer_Tick);
            // 
            // menuBarPanel
            // 
            this.menuBarPanel.BackColor = System.Drawing.Color.Green;
            this.menuBarPanel.BackgroundImage = global::BattleShipGame.Properties.Resources.controlPanelBackGroundImage;
            this.menuBarPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuBarPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuBarPanel.Controls.Add(this.mainWindowPlayer);
            this.menuBarPanel.Controls.Add(this.audioButton);
            this.menuBarPanel.Controls.Add(this.minizeButton);
            this.menuBarPanel.Controls.Add(this.windowSizeControlButton);
            this.menuBarPanel.Controls.Add(this.exitButton);
            this.menuBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuBarPanel.Location = new System.Drawing.Point(0, 0);
            this.menuBarPanel.Name = "menuBarPanel";
            this.menuBarPanel.Size = new System.Drawing.Size(920, 52);
            this.menuBarPanel.TabIndex = 2;
            // 
            // mainWindowPlayer
            // 
            this.mainWindowPlayer.Enabled = true;
            this.mainWindowPlayer.Location = new System.Drawing.Point(3, 3);
            this.mainWindowPlayer.Name = "mainWindowPlayer";
            this.mainWindowPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainWindowPlayer.OcxState")));
            this.mainWindowPlayer.Size = new System.Drawing.Size(390, 46);
            this.mainWindowPlayer.TabIndex = 0;
            this.mainWindowPlayer.Visible = false;
            // 
            // audioButton
            // 
            this.audioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.audioButton.BackColor = System.Drawing.Color.Transparent;
            this.audioButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.audioButton.BackgroundImage = global::BattleShipGame.Properties.Resources.audioOnImage;
            this.audioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.audioButton.BorderColor = System.Drawing.Color.Green;
            this.audioButton.BorderRadius = 0;
            this.audioButton.BorderSize = 1;
            this.audioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.audioButton.FlatAppearance.BorderSize = 0;
            this.audioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.audioButton.ForeColor = System.Drawing.Color.White;
            this.audioButton.Location = new System.Drawing.Point(723, 4);
            this.audioButton.Name = "audioButton";
            this.audioButton.Size = new System.Drawing.Size(43, 43);
            this.audioButton.TabIndex = 8;
            this.audioButton.TextColor = System.Drawing.Color.White;
            this.audioButton.UseVisualStyleBackColor = false;
            this.audioButton.Click += new System.EventHandler(this.audioButton_Click);
            // 
            // minizeButton
            // 
            this.minizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minizeButton.BackColor = System.Drawing.Color.Transparent;
            this.minizeButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.minizeButton.BackgroundImage = global::BattleShipGame.Properties.Resources.minizeButtonImage;
            this.minizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.minizeButton.BorderColor = System.Drawing.Color.Green;
            this.minizeButton.BorderRadius = 0;
            this.minizeButton.BorderSize = 1;
            this.minizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minizeButton.FlatAppearance.BorderSize = 0;
            this.minizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minizeButton.ForeColor = System.Drawing.Color.White;
            this.minizeButton.Location = new System.Drawing.Point(772, 4);
            this.minizeButton.Name = "minizeButton";
            this.minizeButton.Size = new System.Drawing.Size(43, 43);
            this.minizeButton.TabIndex = 7;
            this.minizeButton.TextColor = System.Drawing.Color.White;
            this.minizeButton.UseVisualStyleBackColor = false;
            this.minizeButton.Click += new System.EventHandler(this.minizeButton_Click);
            // 
            // windowSizeControlButton
            // 
            this.windowSizeControlButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.windowSizeControlButton.BackColor = System.Drawing.Color.Transparent;
            this.windowSizeControlButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.windowSizeControlButton.BackgroundImage = global::BattleShipGame.Properties.Resources.fullScreenButton;
            this.windowSizeControlButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.windowSizeControlButton.BorderColor = System.Drawing.Color.Green;
            this.windowSizeControlButton.BorderRadius = 0;
            this.windowSizeControlButton.BorderSize = 1;
            this.windowSizeControlButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.windowSizeControlButton.FlatAppearance.BorderSize = 0;
            this.windowSizeControlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.windowSizeControlButton.ForeColor = System.Drawing.Color.White;
            this.windowSizeControlButton.Location = new System.Drawing.Point(821, 4);
            this.windowSizeControlButton.Name = "windowSizeControlButton";
            this.windowSizeControlButton.Size = new System.Drawing.Size(43, 43);
            this.windowSizeControlButton.TabIndex = 6;
            this.windowSizeControlButton.TextColor = System.Drawing.Color.White;
            this.windowSizeControlButton.UseVisualStyleBackColor = false;
            this.windowSizeControlButton.Click += new System.EventHandler(this.windowSizeControlButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.exitButton.BackgroundImage = global::BattleShipGame.Properties.Resources.exitButtonImage;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.exitButton.BorderColor = System.Drawing.Color.Green;
            this.exitButton.BorderRadius = 0;
            this.exitButton.BorderSize = 1;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(870, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(43, 43);
            this.exitButton.TabIndex = 5;
            this.exitButton.TextColor = System.Drawing.Color.White;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MenuBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 618);
            this.Controls.Add(this.childFormPanel);
            this.Controls.Add(this.menuBarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuBarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuBarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainWindowPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuBarPanel;
        private System.Windows.Forms.Panel childFormPanel;
        private CustomControls.CustomButton exitButton;
        private CustomControls.CustomButton audioButton;
        private CustomControls.CustomButton minizeButton;
        private CustomControls.CustomButton windowSizeControlButton;
        private AxWMPLib.AxWindowsMediaPlayer mainWindowPlayer;
        private System.Windows.Forms.Timer checkForChangesTimer;
    }
}