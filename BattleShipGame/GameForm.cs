using BattleShipGame.models;
using BattleShipGame.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipGame
{
    public partial class GameForm : Form
    {
        private SoundPlayer SoundPlayer = new SoundPlayer();
        bool cheatIsOn = false;

        private int showInitialShootEnemyShipForm = 0;
        private int backgroundImageCount = 0;
        private Vessel myAircraftCarrierDetails;
        private Vessel myBattleShipDetails;
        private Vessel myDestroyerDetails;
        private Vessel myFrigateDetails;
        private Vessel mySubmarineDetails;
        private Vessel myCorvetteDetails;
        
        private Vessel enemyAircraftCarrierDetails;
        private Vessel enemyBattleShipDetails;
        private Vessel enemyDestroyerDetails;
        private Vessel enemyFrigateDetails;
        private Vessel enemySubmarineDetails;
        private Vessel enemyCorvetteDetails;

        private List<Vessel> allMyVessels = new List<Vessel>();
        private List<Vessel> allEnemyVessels = new List<Vessel>();

        private List<Panel> myFleetTilePanels = new List<Panel>();
        private List<Panel> enemyFleetTilePanels = new List<Panel>();
        private ShootEnemyShipForm shootEnemyShipForm;
        private List<int> availableHitPositionsForEnemy = new List<int>();

        struct TilePanelAttributes
        {
            public int PanelId { get; set; }
            public bool IsHit { get; set; }
        }

        public GameForm()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.DoubleBuffered = true;
            createTheTilePanels(31, 11);
            createTheTilePanels(521, 11);
            //Do stuff
            myAircraftCarrierDetails = new Vessel(StaticData.Formation.Find(vessel => vessel.VesselName == "aircraftCarrier"));
            myBattleShipDetails = new Vessel(StaticData.Formation.Find(vessel => vessel.VesselName == "battleShip"));
            myDestroyerDetails = new Vessel(StaticData.Formation.Find(vessel => vessel.VesselName == "destroyer"));
            myFrigateDetails = new Vessel(StaticData.Formation.Find(vessel => vessel.VesselName == "frigate"));
            mySubmarineDetails = new Vessel(StaticData.Formation.Find(vessel => vessel.VesselName == "submarine"));
            myCorvetteDetails = new Vessel(StaticData.Formation.Find(vessel => vessel.VesselName == "corvette"));
            allMyVessels.Add(myAircraftCarrierDetails);
            allMyVessels.Add(myBattleShipDetails);
            allMyVessels.Add(myDestroyerDetails);
            allMyVessels.Add(myFrigateDetails);
            allMyVessels.Add(mySubmarineDetails);
            allMyVessels.Add(myCorvetteDetails);

            enemyAircraftCarrierDetails = new Vessel(StaticData.EnemyFormation.Find(vessel => vessel.VesselName == "aircraftCarrier"));
            enemyBattleShipDetails = new Vessel(StaticData.EnemyFormation.Find(vessel => vessel.VesselName == "battleShip"));
            enemyDestroyerDetails = new Vessel(StaticData.EnemyFormation.Find(vessel => vessel.VesselName == "destroyer"));
            enemyFrigateDetails = new Vessel(StaticData.EnemyFormation.Find(vessel => vessel.VesselName == "frigate"));
            enemySubmarineDetails = new Vessel(StaticData.EnemyFormation.Find(vessel => vessel.VesselName == "submarine"));
            enemyCorvetteDetails = new Vessel(StaticData.EnemyFormation.Find(vessel => vessel.VesselName == "corvette"));
            allEnemyVessels.Add(enemyAircraftCarrierDetails);
            allEnemyVessels.Add(enemyBattleShipDetails);
            allEnemyVessels.Add(enemyDestroyerDetails);
            allEnemyVessels.Add(enemyFrigateDetails);
            allEnemyVessels.Add(enemySubmarineDetails);
            allEnemyVessels.Add(enemyCorvetteDetails);

            //StaticData.EnemyFormation = null;
            StaticData.Formation = null;

            setFormation(allMyVessels, true);
            setFormation(allEnemyVessels, false);

            availableHitPositionsForEnemy = Enumerable.Range(0, 197).ToList();
        }

        private void backroungImageChangerTimer_Tick(object sender, EventArgs e)
        {
            if(showInitialShootEnemyShipForm == 7)
            {
                shootEnemyShipForm = new ShootEnemyShipForm();

                shootEnemyShipForm.Show();
                showInitialShootEnemyShipForm += 1;
            }
            else
            {
                showInitialShootEnemyShipForm += 1;
            }

            if (backgroundImageCount > 37)
                backgroundImageCount = 0;

            string prefix = "surface";
            // Construct the resource name based on the prefix and index
            string resourceName = $"{prefix}{backgroundImageCount}";

            // Retrieve the image from the resources
            this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(resourceName);
            backgroundImageCount++;
        }

        private void createTheTilePanels(int startingLocationForX, int startingLocationForY)
        {
            int count = 1;
            int saveStartingLocationForX = startingLocationForX;
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    Panel panel = new Panel();
                    if (saveStartingLocationForX == 31)
                        panel.Name = $"panelTile{count}";
                    else
                        panel.Name = $"enemyPanelTile{count}";
                    panel.BackColor = Color.LightBlue;
                    panel.Size = new Size(24, 23);
                    panel.Location = new Point(startingLocationForX, startingLocationForY);

                    TilePanelAttributes panelAttributes = new TilePanelAttributes();
                    panelAttributes.PanelId = j + i * 14;
                    panel.Tag = panelAttributes;
                    panel.BackgroundImageLayout = ImageLayout.Stretch;
                    panel.BorderStyle = BorderStyle.FixedSingle;

                    if (saveStartingLocationForX == 31)
                        myFleetTilePanels.Add(panel);
                    else
                        enemyFleetTilePanels.Add(panel);
                    this.Controls.Add(panel);
                    startingLocationForX += 26;
                    count++;

                }
                startingLocationForX = saveStartingLocationForX;
                startingLocationForY += 25;
            }
        }

        private void setFormation(List<Vessel> vessels, bool isMyFleet)
        {
            foreach (Vessel vessel in vessels)
            {
                int x = myFleetTilePanels.Count;
                if (isMyFleet)
                    setUpVesselMovingPictureLocation(vessel, myFleetTilePanels[vessel.PanelsItOccupies[0]]);
                else
                    setUpVesselMovingPictureLocation(vessel, enemyFleetTilePanels[vessel.PanelsItOccupies[0]]);

                this.Controls.Add(vessel.MovingPictureBox);
                vessel.MovingPictureBox.BringToFront();
            }
        }

        private void setUpVesselMovingPictureLocation(Vessel vesselDetails, Panel panel)
        {
            Point vesselLocation;
            if (vesselDetails.IsHorizontallyAligned)
                vesselLocation = vesselDetails.VesselName == "aircraftCarrier" ? new Point(panel.Location.X - 12, panel.Location.Y - 4) :
                    new Point(panel.Location.X - 10, panel.Location.Y - 12);
            else
                vesselLocation = vesselDetails.VesselName == "aircraftCarrier" ? new Point(panel.Location.X - 5, panel.Location.Y - 8) :
                    new Point(panel.Location.X - 10, panel.Location.Y - 8);
            vesselDetails.MovingPictureBox.Location = vesselLocation;
        }

        private void cheatButton_Click(object sender, EventArgs e)
        {
            cheatIsOn = cheatIsOn ? false : true;
            foreach (Vessel vessel in allEnemyVessels)
            {
                vessel.MovingPictureBox.Visible = cheatIsOn ? true : false;   
            }
        }

        private void checkIfShootingFormIsMinizedTimer_Tick(object sender, EventArgs e)
        {
            if(shootEnemyShipForm != null && shootEnemyShipForm.Visible == false)
                showShootingFormButton.Visible = true;
        }

        private void showShootingFormButton_Click(object sender, EventArgs e)
        {
            shootEnemyShipForm.Show();
        }

        private void enemyTurnCheckerTimer_Tick(object sender, EventArgs e)
        {
            if (!StaticData.EnemyTurn)
                return;

            Random random = new Random();

            int chosenPanelId = random.Next(availableHitPositionsForEnemy.Count);
            Panel panel = myFleetTilePanels[chosenPanelId];
            TilePanelAttributes tilePanelAttributes = (TilePanelAttributes)panel.Tag;

            tilePanelAttributes.IsHit = true;
            bool isHit = false;
            foreach (VesselInControlPanel vesselInControlPanel in StaticData.EnemyFormation)
            {
                Vessel vessel = new Vessel(vesselInControlPanel);
                if (vessel.PanelsItOccupies.Contains(tilePanelAttributes.PanelId))
                {
                    panel.BackgroundImage = Resources.tileBackgroundHit;
                    isHit = true;
                    panel.BringToFront();
                    break;
                }
            }
            if(!isHit)
                panel.BackgroundImage = Resources.hitTile;

            availableHitPositionsForEnemy.Remove(chosenPanelId);
            StaticData.EnemyTurn = false;
        }

        /*private void fillPanels(Vessel vessel, bool isMyFleet)
        {
            if (isMyFleet)
            {
                foreach (int panelId in vessel.PanelsItOccupies)
                {
                    TilePanelAttributes panelAttributes = (TilePanelAttributes)myFleetTilePanels[panelId].Tag;
                    panelAttributes.IsFilled = true;
                }
            }
        }*/
    }
}
