using BattleShipGame.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace BattleShipGame
{
    public partial class MenuBarForm : Form
    {
        private bool isDragging = false;
        private int xOffset;
        private int yOffset;
        private Form activeForm = null;
        private bool isDefaultWindowSize = true;
        private bool isAudioOn = true;
        private SoundPlayer soundPlayerButtonClick = new SoundPlayer();

        public MenuBarForm()
        {
            InitializeComponent();
            openChildForm(new GameEntryForm());
            this.DoubleBuffered = true;

            // Load and play the audio file from resources.
            string resourcePath = @"C:\Users\Konstantinos\source\repos\BattleShipGame Solution\BattleShipGame\AudioResources\mainSoundTrack.wav";

            /*mainWindowPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(mainWindowPlayer_PlayStateChange);*/
            mainWindowPlayer.URL = resourcePath;
            //mainWindowPlayer.settings.playCount = 9999;
            mainWindowPlayer.Ctlcontrols.play();
        }

        // Magic to make the windowPlayer loop
        /*private void mainWindowPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            // 8 represents MediaEnded state
            if (e.newState == 8) 
            {
                // Restart playback from the beginning
                mainWindowPlayer.Ctlcontrols.currentPosition = 0;
                mainWindowPlayer.Ctlcontrols.play();
            }
        }*/


        private void MainForm_Load(object sender, EventArgs e)
        {
            // Handle mouse down on the custom title bar panel.
            menuBarPanel.MouseDown += (s, args) =>
            {
                isDragging = true;
                xOffset = args.X;
                yOffset = args.Y;
            };

            // Handle mouse up.
            menuBarPanel.MouseUp += (s, args) =>
            {
                isDragging = false;
            };

            // Handle mouse move to move the form when dragging.
            menuBarPanel.MouseMove += (s, args) =>
            {
                if (isDragging)
                {
                    Point newLocation = this.PointToScreen(new Point(args.X, args.Y));
                    this.Location = new Point(newLocation.X - xOffset, newLocation.Y - yOffset);
                }
            };
        }

        private void openChildForm(Form childForm)
        {
            /*if (activeForm != null && activeForm.UnsavedChangesDetected())
                return;
            if (activeForm != null)
                activeForm.Close();*/

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childFormPanel.Controls.Add(childForm);
            childFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            mainWindowPlayer.Ctlcontrols.stop();
            this.Close();
        }

        private void windowSizeControlButton_Click(object sender, EventArgs e)
        {
            playClickButtonSound();
            if (isDefaultWindowSize)
            {
                this.WindowState = FormWindowState.Maximized;
                windowSizeControlButton.BackgroundImage = Resources.defaultSizeButton;
                isDefaultWindowSize = false;
                return;
            }
            this.WindowState = FormWindowState.Normal;
            windowSizeControlButton.BackgroundImage = Resources.fullScreenButton;
            isDefaultWindowSize = true;
        }

        private void minizeButton_Click(object sender, EventArgs e)
        {
            playClickButtonSound();
            this.WindowState = FormWindowState.Minimized;
        }

        private void audioButton_Click(object sender, EventArgs e)
        {
            playClickButtonSound();
            if (isAudioOn)
            {
                mainWindowPlayer.Ctlcontrols.stop();
                audioButton.BackgroundImage = Resources.audioOffImage;
                isAudioOn = false;
                return;
            }
            mainWindowPlayer.Ctlcontrols.play();
            audioButton.BackgroundImage = Resources.audioOnImage;
            isAudioOn = true;
        }

        private void playClickButtonSound()
        {
            soundPlayerButtonClick.Stream = Resources.buttonClickSound;
            soundPlayerButtonClick.Play();
        }

        private void checkForChangesTimer_Tick(object sender, EventArgs e)
        {
            if (StaticData.LoadFormationForm)
            {
                StaticData.LoadFormationForm = false;
                openChildForm(new FormationForm());
            }
            else if (StaticData.LoadGameForm)
            {
                StaticData.LoadGameForm = false;
                openChildForm(new GameForm());
            }
        }
    }
}
