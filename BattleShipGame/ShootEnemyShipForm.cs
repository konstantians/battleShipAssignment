using BattleShipGame.models;
using BattleShipGame.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace BattleShipGame
{
    public partial class ShootEnemyShipForm : Form
    {
        private List<Panel> tilePanels = new List<Panel>();
        private SoundPlayer SoundPlayer = new SoundPlayer();
        public ShootEnemyShipForm()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.DoubleBuffered = true;
        }

        private void minizeButton_Click(object sender, EventArgs e)
        {
            SoundPlayer.Stream = Resources.buttonClickSound;
            SoundPlayer.Play();
            this.Hide();
        }

        struct TilePanelAttributes
        {
            public int PanelId { get; set; }
            public bool IsHit { get; set; }
        }

        private void coolAnimationTimer_Tick(object sender, EventArgs e)
        {
            if (this.Width < 696 && this.Height < 448)
            {
                // Gradually increase the size of the form
                this.Width += 62; // Adjust the step size as needed
                this.Height += 31; // Adjust the step size as needed
            }
            else
            {
                // Stop the timer when the form is maximized
                coolAnimationTimer.Stop();
                createTheTilePanels();
            }
        }

        private void ShootEnemyShipForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(200, 200);
        }

        private void createTheTilePanels()
        {
            int startingLocationForX = 221;
            int startingLocationForY = 100;
            int count = 1;
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    Panel panel = new Panel();
                    panel.Name = $"panelTile{count}";
                    panel.BackColor = Color.LightBlue;
                    panel.Size = new Size(16, 18);
                    panel.Location = new Point(startingLocationForX, startingLocationForY);

                    TilePanelAttributes panelAttributes = new TilePanelAttributes();
                    panelAttributes.PanelId = j + i * 14;
                    panelAttributes.IsHit = false;
                    panel.Tag = panelAttributes;
                    panel.BackgroundImageLayout = ImageLayout.Stretch;
                    //panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.BackColor = Color.Transparent;
                    tilePanels.Add(panel);
                    this.Controls.Add(panel);

                    panel.MouseEnter += TilePanel_MouseEnter;
                    panel.MouseLeave += TilePanel_MouseLeave;
                    panel.Click += TilePanel_Click;

                    if (j < 8)
                        startingLocationForX += 18;
                    else
                        startingLocationForX += 19;
                    count++;

                }
                startingLocationForX = 221;
                startingLocationForY += 21;
            }
        }

        // Define the MouseHover event handler
        private void TilePanel_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            TilePanelAttributes tilePanelAttributes = (TilePanelAttributes)panel.Tag;
            if (!tilePanelAttributes.IsHit)
                panel.BackColor = Color.White;
        }

        private void TilePanel_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            TilePanelAttributes tilePanelAttributes = (TilePanelAttributes)panel.Tag;
            if (!tilePanelAttributes.IsHit)
                panel.BackColor = Color.Transparent;
        }

        // Define the Click event handler
        private void TilePanel_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            TilePanelAttributes tilePanelAttributes = (TilePanelAttributes)panel.Tag;
            if (tilePanelAttributes.IsHit)
                return;

            tilePanelAttributes.IsHit = true;
            panel.Tag = tilePanelAttributes;
            panel.BackColor = Color.Transparent;
            StaticData.EnemyTilePanelId = tilePanelAttributes.PanelId;
            foreach (Vessel vessel in StaticData.EnemyFormation)
            {
                if (vessel.PanelsItOccupies.Contains(tilePanelAttributes.PanelId))
                {
                    vessel.TilesLeft -= 1;
                    panel.BackgroundImage = vessel.TilesLeft != 0 ? Resources.tileBackgroundHit : Resources.tileBackgroundShipSunked;
                    if (vessel.TilesLeft == 0)
                        setTilesForDestructedShip(vessel);
                    StaticData.EnemyWasDestroyed = vessel.TilesLeft == 0;
                    StaticData.EnemyWasHit = true;
                    StaticData.EnemyTurn = true;
                    this.Hide();
                    return;
                }
            }
            panel.BackgroundImage = Resources.tileBackgroundMiss;
            StaticData.EnemyWasDestroyed = false;
            StaticData.EnemyWasHit = false;
            StaticData.EnemyTurn = true;
            this.Hide();
            // Your click event code here
            // You can access panel.Tag to get the associated attributes
        }

        private void setTilesForDestructedShip(Vessel vessel)
        {
            foreach (int panelId in vessel.PanelsItOccupies)
            {
                tilePanels[panelId].BackgroundImage = Resources.tileBackgroundShipSunked;
            }
            foreach (int panelId in vessel.NeighboursItOccupies)
            {
                TilePanelAttributes tilePanelAttributes = (TilePanelAttributes)tilePanels[panelId].Tag;
                tilePanelAttributes.IsHit = true;
                tilePanels[panelId].Tag = tilePanelAttributes;
                tilePanels[panelId].BackgroundImage = Resources.tileBackgroundMiss;
            }
        }
    }
}
