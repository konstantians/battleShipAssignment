using BattleShipGame.Properties;
using System;
using System.Media;
using System.Windows.Forms;

namespace BattleShipGame
{
    public partial class GameEntryForm : Form
    {
        private SoundPlayer SoundPlayer = new SoundPlayer();
        private bool buttonSizeShouldIncrease = true;
        public GameEntryForm()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.DoubleBuffered = true;
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            SoundPlayer.Stream = Resources.buttonClickSound;
            SoundPlayer.Play();
            StaticData.LoadFormationForm = true;
        }

        private void buttonTimer_Tick(object sender, EventArgs e)
        {
            if (buttonSizeShouldIncrease)
            {
                startGameButton.Width += 2;
                startGameButton.Height += 2;
                startGameButton.Left--;
                startGameButton.Top--;
                if (startGameButton.Width > 105 && startGameButton.Height > 105)
                    buttonSizeShouldIncrease = false;
            }
            else
            {
                startGameButton.Width -= 2;
                startGameButton.Height -= 2;
                startGameButton.Left++;
                startGameButton.Top++;
                if (startGameButton.Width < 95 && startGameButton.Height < 95)
                    buttonSizeShouldIncrease = true;
            }
        }
    }
}
