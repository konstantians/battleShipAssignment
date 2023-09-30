using BattleShipGame.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace BattleShipGame
{
    public partial class GameResultForm : Form
    {
        private SoundPlayer SoundPlayer = new SoundPlayer();
        public GameResultForm(bool playerWon)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ControlBox = false;
            victoryAndDefeatLabel.Text = playerWon ? "VICTORY!" : "DEFEAT!";
            victoryAndDefeatLabel.Location = playerWon ? new Point(84, 21) : new Point(91, 21);
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            SoundPlayer.Stream = Resources.buttonClickSound;
            SoundPlayer.Play();
            //close all expect from the menu bar
            for (int i = Application.OpenForms.Count - 1; i >= 1; i--)
                Application.OpenForms[i].Close();
            StaticData.LoadFormationForm = true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            SoundPlayer.Stream = Resources.buttonClickSound;
            SoundPlayer.Play();
            //application count = 4;
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                Application.OpenForms[i].Close();
        }
    }
}
