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
        private bool cheatIsOn = false;
        private bool enemyCheatIsOn = false;

        private int showInitialShootEnemyShipForm = 0;
        private int backgroundImageCount = 0;

        private List<Panel> myFleetTilePanels = new List<Panel>();
        private List<Panel> enemyFleetTilePanels = new List<Panel>();
        private ShootEnemyShipForm shootEnemyShipForm;
        private List<int> availableHitPositionsForEnemy = new List<int>();
        private PictureBox projectileImage;
        
        private List<FireTile> fireTiles = new List<FireTile>();

        private PictureBox hitImage;
        private int hitCounter = 0;

        private int panelChosenByEnemy = -1;
        private bool wasFriendlyShipHit = false;
        private bool wasFriendlyShipSunk = false;

        private bool friendlyProjectileAnimationOver = false;
        private bool friendlyHitAnimationOver = false;
        private bool enemyCalculationOver = false;
        private bool enemyProjectileAnimationOver = false;
        private bool enemyHitAnimationOver = false;

        private List<string> friendlySunkShips = new List<string>();
        private List<string> enemySunkShips = new List<string>();

        private Random random = new Random();
        private string winner = "";
        private PictureBox[] finalAirplanes = new PictureBox[3];
        private bool wasInstanciated = false; 

        struct TilePanelAttributes
        {
            public int PanelId { get; set; }
            public bool IsHit { get; set; }
        }

        class FireTile
        {
            public int PanelId { get; set; }
            public int FireImageCounter{ get; set; }
            public PictureBox FirePicture { get; set; }
            public bool IsEnemy { get; set; }
        }

        public GameForm()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.DoubleBuffered = true;
            cheatButton.Location = new Point(209, 370);
            createTheTilePanels(31, 11);
            createTheTilePanels(521, 11);
            //
            
            setFormation(StaticData.Formation, true);
            setFormation(StaticData.EnemyFormation, false);

            if (!enemyCheatIsOn)
                availableHitPositionsForEnemy = Enumerable.Range(0, 196).ToList();
            else
                StaticData.Formation.ForEach(vessel => vessel.PanelsItOccupies.ForEach(
                    panel => availableHitPositionsForEnemy.Add(panel)));
        }

        private void backroungImageChangerTimer_Tick(object sender, EventArgs e)
        {
            string prefix = "surface";
            // Construct the resource name based on the prefix and index
            string resourceName = $"{prefix}{backgroundImageCount}";

            // Retrieve the image from the resources
            this.BackgroundImage = (Image)Resources.ResourceManager.GetObject(resourceName);
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
                    //panel.BackgroundImage = Resources.tileBackgroundMiss; 

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
            SoundPlayer.Stream = Resources.buttonClickSound;
            SoundPlayer.Play();
            cheatIsOn = cheatIsOn ? false : true;
            if (cheatIsOn)
            {
                StaticData.EnemyFormation.ForEach(vessel => vessel.MovingPictureBox.Visible = true);
                fireTiles.FindAll(fireTile => fireTile.IsEnemy).ForEach(fireTile => fireTile.FirePicture.Visible = true);
                return;
            }
            StaticData.EnemyFormation.ForEach(vessel => vessel.MovingPictureBox.Visible = false);
            fireTiles.FindAll(fireTile => fireTile.IsEnemy).ForEach(fireTile => fireTile.FirePicture.Visible = false);
        }

        private void checkIfShootingFormIsMinizedTimer_Tick(object sender, EventArgs e)
        {       

            if (showInitialShootEnemyShipForm == 25)
            {
                shootEnemyShipForm = new ShootEnemyShipForm();

                shootEnemyShipForm.Show();
                showInitialShootEnemyShipForm += 1;
                //backroungImageChangerTimer.Enabled = false;
            }
            else if (showInitialShootEnemyShipForm < 25)
            {
                showInitialShootEnemyShipForm += 1;
            }
            else if (shootEnemyShipForm != null && shootEnemyShipForm.Visible == false && !StaticData.EnemyTurn)
            {
                showShootingFormButton.Visible = true;
                cheatButton.Location = new Point(245, 374);
            }
            else
            {
                showShootingFormButton.Visible = false;
                cheatButton.Location = new Point(209, 374);
            }
        }

        private void showShootingFormButton_Click(object sender, EventArgs e)
        {
            SoundPlayer.Stream = Resources.buttonClickSound;
            SoundPlayer.Play();
            shootEnemyShipForm.Show();
        }

        private void enemyTurnCheckerTimer_Tick(object sender, EventArgs e)
        {
            if (!StaticData.EnemyTurn || winner != "")
                return;

            if (!friendlyProjectileAnimationOver && !friendlyHitAnimationOver && !enemyCalculationOver && !enemyProjectileAnimationOver && !enemyHitAnimationOver)
            {
                projectileHelperMethod(true);
            }
            else if (friendlyProjectileAnimationOver && !friendlyHitAnimationOver && !enemyCalculationOver && !enemyProjectileAnimationOver && !enemyHitAnimationOver)
            {
                hitHelperMethod(true);
            }
            else if (friendlyProjectileAnimationOver && friendlyHitAnimationOver && !enemyCalculationOver && !enemyProjectileAnimationOver && !enemyHitAnimationOver)
            {
                int chosenPanelId;
                if (!enemyCheatIsOn)
                {
                    int panelIdIndex = random.Next(availableHitPositionsForEnemy.Count);
                    chosenPanelId = availableHitPositionsForEnemy[panelIdIndex];
                }
                else
                    chosenPanelId = availableHitPositionsForEnemy[0];

                Panel panel = myFleetTilePanels[chosenPanelId];
                TilePanelAttributes tilePanelAttributes = (TilePanelAttributes)panel.Tag;

                tilePanelAttributes.IsHit = true;
                bool isHit = false;
                panelChosenByEnemy = tilePanelAttributes.PanelId;
                foreach (Vessel vessel in StaticData.Formation)
                {
                    if (vessel.PanelsItOccupies.Contains(tilePanelAttributes.PanelId))
                    {
                        vessel.TilesLeft -= 1;
                        isHit = true;
                        wasFriendlyShipHit = true;
                        if(vessel.TilesLeft == 0)
                            wasFriendlyShipSunk = true;
                        break;
                    }
                }
                if (!isHit)
                    wasFriendlyShipHit = false;

                availableHitPositionsForEnemy.Remove(chosenPanelId);
                enemyCalculationOver = true;
                return;
            }
            else if (friendlyProjectileAnimationOver && friendlyHitAnimationOver && enemyCalculationOver && !enemyProjectileAnimationOver && !enemyHitAnimationOver)
            {
                projectileHelperMethod(false);
            }
            else if (friendlyProjectileAnimationOver && friendlyHitAnimationOver && enemyCalculationOver && enemyProjectileAnimationOver && !enemyHitAnimationOver)
            {
                hitHelperMethod(false);
                if (StaticData.Formation.Count == 0)
                    winner = "AI";
            }
            else
            {
                friendlyProjectileAnimationOver = false;
                friendlyHitAnimationOver = false;
                enemyCalculationOver = false;
                enemyProjectileAnimationOver = false;
                enemyHitAnimationOver = false;
                wasFriendlyShipSunk = false;
                StaticData.EnemyTurn = false;
                shootEnemyShipForm.Show();
            }
        }

        private void projectileHelperMethod(bool isFriendly)
        {
            if (projectileImage == null)
            {
                int weaponChoice = random.Next(3);
                projectileImage = new PictureBox();
                projectileImage.BackgroundImageLayout = ImageLayout.Stretch;
                projectileImage.BackColor = Color.Transparent;
                int yOffset = 5;
                //airplane
                if (weaponChoice == 0)
                {
                    projectileImage.Size = new Size(57, 37);
                    projectileImage.Location = isFriendly ? new Point(-55, enemyFleetTilePanels[StaticData.EnemyTilePanelId].Location.Y -yOffset - 1) : 
                        new Point(970, myFleetTilePanels[panelChosenByEnemy].Location.Y - yOffset - 1);
                    projectileImage.BackgroundImage = isFriendly ? Resources.airplane : Resources.enemyAirplane;
                    SoundPlayer.Stream = Resources.airstrikeSound;
                    SoundPlayer.Play();
                }
                //everything else
                else
                {
                    projectileImage.Size = new Size(40, 15);
                    projectileImage.Location = isFriendly ? new Point(410, enemyFleetTilePanels[StaticData.EnemyTilePanelId].Location.Y + yOffset) : 
                        new Point(610, myFleetTilePanels[panelChosenByEnemy].Location.Y + yOffset);
                    if(isFriendly)
                        projectileImage.BackgroundImage = weaponChoice == 2 ? Resources.torpedo : Resources.missile;
                    else
                        projectileImage.BackgroundImage = weaponChoice == 2 ? Resources.enemyTorpedo : Resources.enemyMissisle;
                    SoundPlayer.Stream = weaponChoice == 2 ? Resources.missisleTorpedoSound : Resources.missisleLaunchSound;
                    SoundPlayer.Play();
                }
                this.Controls.Add(projectileImage);
                projectileImage.BringToFront();
                //backroungImageChangerTimer.Enabled = false;
                return;
            }
            if (isFriendly && projectileImage.Location.X < enemyFleetTilePanels[StaticData.EnemyTilePanelId].Location.X)
            {
                projectileImage.Location = new Point(projectileImage.Location.X + 10, projectileImage.Location.Y);
                return;
            }
            if (!isFriendly && projectileImage.Location.X > myFleetTilePanels[panelChosenByEnemy].Location.X)
            {
                projectileImage.Location = new Point(projectileImage.Location.X - 10, projectileImage.Location.Y);
                return;
            }

            projectileImage.Dispose();
            this.Controls.Remove(projectileImage);
            projectileImage = null;
            //backroungImageChangerTimer.Enabled = true;
            if (isFriendly)
                friendlyProjectileAnimationOver = true;
            else
                enemyProjectileAnimationOver = true;
        }

        private void hitHelperMethod(bool causedByFriendly)
        {
            if (hitImage == null)
            {
                hitImage = new PictureBox();
                hitImage.BackgroundImageLayout = ImageLayout.Stretch;
                hitImage.BackColor = Color.Transparent;

                hitImage.Size = new Size(45, 45);
                if(causedByFriendly && StaticData.EnemyWasDestroyed)
                {
                    setUpShipExplosionPictureAndResults(true, StaticData.EnemyTilePanelId);
                }
                else if (causedByFriendly)
                {
                    hitImage.Location = new Point(enemyFleetTilePanels[StaticData.EnemyTilePanelId].Location.X - 10, enemyFleetTilePanels[StaticData.EnemyTilePanelId].Location.Y - 10);
                    SoundPlayer.Stream = StaticData.EnemyWasHit ? Resources.missisleExplosionSound : Resources.missisleMissSound;
                }
                else if (!causedByFriendly && wasFriendlyShipSunk)
                {
                    setUpShipExplosionPictureAndResults(false, panelChosenByEnemy);
                }
                else
                {
                    hitImage.Location = new Point(myFleetTilePanels[panelChosenByEnemy].Location.X - 10, myFleetTilePanels[panelChosenByEnemy].Location.Y - 10);
                    SoundPlayer.Stream = wasFriendlyShipHit ? Resources.missisleExplosionSound : Resources.missisleMissSound;
                }
                SoundPlayer.Play();

                this.Controls.Add(hitImage);
                hitImage.BringToFront();

                //backroungImageChangerTimer.Enabled = false;
                return;
            }

            //29
            if (hitCounter < 35)
            {
                string resourceName = "";
                if(causedByFriendly && StaticData.EnemyWasDestroyed)
                    resourceName = $"finalExplosion{hitCounter}";
                else if (causedByFriendly)
                    resourceName = StaticData.EnemyWasHit ? $"MissisleExplosion{hitCounter}" : $"MissisleWater{hitCounter}";
                else
                    resourceName = wasFriendlyShipHit ? $"MissisleExplosion{hitCounter}" : $"MissisleWater{hitCounter}";
                hitImage.BackgroundImage = (Image)Resources.ResourceManager.GetObject(resourceName);
                hitCounter++;
                return;
            }


            if (causedByFriendly)
            {
                enemyFleetTilePanels[StaticData.EnemyTilePanelId].BackgroundImage = StaticData.EnemyWasHit ? Resources.destroyedTile : Resources.hitTile;
                if (!StaticData.EnemyWasHit)
                    enemyFleetTilePanels[StaticData.EnemyTilePanelId].BringToFront();
                if (StaticData.EnemyWasHit && !StaticData.EnemyWasDestroyed)
                    createFire(new Point(enemyFleetTilePanels[StaticData.EnemyTilePanelId].Location.X + 2, enemyFleetTilePanels[StaticData.EnemyTilePanelId].Location.Y + 1), 
                        true, StaticData.EnemyTilePanelId);
            }
            else if(!causedByFriendly)
            {
                myFleetTilePanels[panelChosenByEnemy].BackgroundImage = wasFriendlyShipHit ? Resources.destroyedTile : Resources.hitTile;
                if (!wasFriendlyShipHit)
                    myFleetTilePanels[panelChosenByEnemy].BringToFront();
                if (wasFriendlyShipHit && !wasFriendlyShipSunk)
                    createFire(new Point(myFleetTilePanels[panelChosenByEnemy].Location.X + 2, myFleetTilePanels[panelChosenByEnemy].Location.Y + 1),
                        false, panelChosenByEnemy);
            }

            hitCounter = 0;
            hitImage.Dispose();
            this.Controls.Remove(hitImage);
            hitImage = null;
            if (causedByFriendly)
                friendlyHitAnimationOver = true;
            else
                enemyHitAnimationOver = true;
            //backroungImageChangerTimer.Enabled = true;

            //check for the winner
            if (StaticData.EnemyFormation.Count == 0)
                winner = "player";
            else if (StaticData.Formation.Count == 0)
                winner = "AI";
        }

        private void setUpShipExplosionPictureAndResults(bool causedByFriendly, int panelId)
        {
            List<Vessel> vessels = causedByFriendly ? StaticData.EnemyFormation : StaticData.Formation; 
            foreach (Vessel vessel in vessels)
            {
                if (vessel.PanelsItOccupies.Contains(panelId))
                {
                    hitImage.Size = vessel.MovingPictureBox.Size;
                    hitImage.Location = vessel.MovingPictureBox.Location;
                    foreach (int neighbourPanelId in vessel.NeighboursItOccupies)
                    {
                        if (causedByFriendly)
                        {
                            enemyFleetTilePanels[neighbourPanelId].BackgroundImage = Resources.hitTile;
                            enemyFleetTilePanels[neighbourPanelId].BringToFront();
                        }
                        else
                        {
                            myFleetTilePanels[neighbourPanelId].BackgroundImage = Resources.hitTile;
                            myFleetTilePanels[neighbourPanelId].BringToFront();
                            availableHitPositionsForEnemy.Remove(neighbourPanelId);
                        }
                            
                    }
                        
                    for (int i = fireTiles.Count - 1; i >= 0; i--)
                    {
                        if (vessel.PanelsItOccupies.Contains(fireTiles[i].PanelId) && fireTiles[i].IsEnemy == causedByFriendly)
                        {
                            fireTiles[i].FirePicture.Dispose();
                            this.Controls.Remove(fireTiles[i].FirePicture);
                            fireTiles[i].FirePicture = null;
                            fireTiles.Remove(fireTiles[i]);
                        }
                    }

                    if (causedByFriendly)
                        enemySunkShips.Add(vessel.VesselName);
                    else
                        friendlySunkShips.Add(vessel.VesselName);
                    updateControlPanelImage(vessel.VesselSize < 5, causedByFriendly);
                    
                    vessel.MovingPictureBox.Dispose();
                    vessel.MovingPictureBox = null;
                    this.Controls.Remove(vessel.MovingPictureBox);
                    break;
                }
            }

            if (causedByFriendly)
                StaticData.EnemyFormation.Remove(StaticData.EnemyFormation.Find(vessel => vessel.PanelsItOccupies.Contains(StaticData.EnemyTilePanelId)));
            else
                StaticData.Formation.Remove(StaticData.Formation.Find(vessel => vessel.PanelsItOccupies.Contains(panelChosenByEnemy)));
            SoundPlayer.Stream = Resources.missisleSinkSound;
        }

        private void createFire(Point location, bool causedByFriendly, int panelId)
        {
            PictureBox firePictureBox = new PictureBox();
            firePictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            firePictureBox.BackColor = Color.Transparent;

            firePictureBox.Size = new Size(21, 21);
            firePictureBox.Location = location;
            if(!cheatIsOn)
                firePictureBox.Visible = !causedByFriendly;

            FireTile fireTile = new FireTile();
            fireTile.FirePicture = firePictureBox;
            fireTile.PanelId = panelId;
            fireTile.FireImageCounter = 1;
            fireTile.IsEnemy = causedByFriendly;

            fireTiles.Add(fireTile);

            this.Controls.Add(firePictureBox);
            firePictureBox.BringToFront();
        }

        private void staticEffectsTimer_Tick(object sender, EventArgs e)
        {
            string resourceName;
            for(int i = 0; i < fireTiles.Count; i++)
            {
                resourceName = $"fire{fireTiles[i].FireImageCounter}";
                fireTiles[i].FirePicture.BackgroundImage = (Image)Resources.ResourceManager.GetObject(resourceName);
                fireTiles[i].FireImageCounter = fireTiles[i].FireImageCounter + 1;
                if (fireTiles[i].FireImageCounter > 30)
                    fireTiles[i].FireImageCounter = 1;
            }
        }

        private void updateControlPanelImage(bool wasSmallShip, bool causedByFriendly)
        {
            if(wasSmallShip && causedByFriendly)
            {
                if (!enemySunkShips.Contains("frigate") && !enemySunkShips.Contains("submarine") && enemySunkShips.Contains("corvette"))
                    enemySmallShipsPanel.BackgroundImage = Resources.enemyFleetCorvetteSunk;
                else if (!enemySunkShips.Contains("frigate") && enemySunkShips.Contains("submarine") && !enemySunkShips.Contains("corvette"))
                    enemySmallShipsPanel.BackgroundImage = Resources.enemyFleetSubmarineSunk;
                else if (!enemySunkShips.Contains("frigate") && enemySunkShips.Contains("submarine") && enemySunkShips.Contains("corvette"))
                    enemySmallShipsPanel.BackgroundImage = Resources.enemyFleetSubmarine_CorvetteSunk;
                else if (enemySunkShips.Contains("frigate") && !enemySunkShips.Contains("submarine") && !enemySunkShips.Contains("corvette"))
                    enemySmallShipsPanel.BackgroundImage = Resources.enemyFleetFrigateSunk;
                else if (enemySunkShips.Contains("frigate") && !enemySunkShips.Contains("submarine") && enemySunkShips.Contains("corvette"))
                    enemySmallShipsPanel.BackgroundImage = Resources.enemyFleetCorvette_FrigateSunk;
                else if (enemySunkShips.Contains("frigate") && enemySunkShips.Contains("submarine") && !enemySunkShips.Contains("corvette"))
                    enemySmallShipsPanel.BackgroundImage = Resources.enemyFleetSubmarine_FrigateSunk;
                else if (enemySunkShips.Contains("frigate") && enemySunkShips.Contains("submarine") && enemySunkShips.Contains("corvette"))
                    enemySmallShipsPanel.BackgroundImage = Resources.enemyFleetSubmarine_Corvette_FrigateSunk;
            }
            if (!wasSmallShip && causedByFriendly)
            {
                if (!enemySunkShips.Contains("aircraftCarrier") && !enemySunkShips.Contains("battleShip") && enemySunkShips.Contains("destroyer"))
                    enemyBigShipsPanel.BackgroundImage = Resources.enemyFleetDestroyerSunk;
                else if (!enemySunkShips.Contains("aircraftCarrier") && enemySunkShips.Contains("battleShip") && !enemySunkShips.Contains("destroyer"))
                    enemyBigShipsPanel.BackgroundImage = Resources.enemyFleetBattleShipSunk;
                else if (!enemySunkShips.Contains("aircraftCarrier") && enemySunkShips.Contains("battleShip") && enemySunkShips.Contains("destroyer"))
                    enemyBigShipsPanel.BackgroundImage = Resources.enemyFleetBattleShip_DestroyerSunk;
                else if (enemySunkShips.Contains("aircraftCarrier") && !enemySunkShips.Contains("battleShip") && !enemySunkShips.Contains("destroyer"))
                    enemyBigShipsPanel.BackgroundImage = Resources.enemyFleetAircraftCarrierSunk;
                else if (enemySunkShips.Contains("aircraftCarrier") && !enemySunkShips.Contains("battleShip") && enemySunkShips.Contains("destroyer"))
                    enemyBigShipsPanel.BackgroundImage = Resources.enemyFleetAircraftCarrier_BattleDestroyerSunk;
                else if (enemySunkShips.Contains("aircraftCarrier") && enemySunkShips.Contains("battleShip") && !enemySunkShips.Contains("destroyer"))
                    enemyBigShipsPanel.BackgroundImage = Resources.enemyFleetAircraftCarrier_BattleShipSunk;
                else if (enemySunkShips.Contains("aircraftCarrier") && enemySunkShips.Contains("battleShip") && enemySunkShips.Contains("destroyer"))
                    enemyBigShipsPanel.BackgroundImage = Resources.enemyFleetAircraftCarrier_BattleShip_DestroyerSunk;
            }
            if (wasSmallShip && !causedByFriendly)
            {
                if (!friendlySunkShips.Contains("frigate") && !friendlySunkShips.Contains("submarine") && friendlySunkShips.Contains("corvette"))
                    mySmallShipsPanel.BackgroundImage = Resources.myFleetCorvetteSunk;
                else if (!friendlySunkShips.Contains("frigate") && friendlySunkShips.Contains("submarine") && !friendlySunkShips.Contains("corvette"))
                    mySmallShipsPanel.BackgroundImage = Resources.myFleetSubmarineSunk;
                else if (!friendlySunkShips.Contains("frigate") && friendlySunkShips.Contains("submarine") && friendlySunkShips.Contains("corvette"))
                    mySmallShipsPanel.BackgroundImage = Resources.myFleetSubmarine_CorvetteSunk;
                else if (friendlySunkShips.Contains("frigate") && !friendlySunkShips.Contains("submarine") && !friendlySunkShips.Contains("corvette"))
                    mySmallShipsPanel.BackgroundImage = Resources.myFleetFrigateSunk;
                else if (friendlySunkShips.Contains("frigate") && !friendlySunkShips.Contains("submarine") && friendlySunkShips.Contains("corvette"))
                    mySmallShipsPanel.BackgroundImage = Resources.myFleetCorvette_FrigateSunk;
                else if (friendlySunkShips.Contains("frigate") && friendlySunkShips.Contains("submarine") && !friendlySunkShips.Contains("corvette"))
                    mySmallShipsPanel.BackgroundImage = Resources.myFleetSubmarine_FrigateSunk;
                else if (friendlySunkShips.Contains("frigate") && friendlySunkShips.Contains("submarine") && friendlySunkShips.Contains("corvette"))
                    mySmallShipsPanel.BackgroundImage = Resources.myFleetSubmarine_Corvette_FrigateSunk;
            }
            if (!wasSmallShip && !causedByFriendly)
            {
                if (!friendlySunkShips.Contains("aircraftCarrier") && !friendlySunkShips.Contains("battleShip") && friendlySunkShips.Contains("destroyer"))
                    myBigShipsPanel.BackgroundImage = Resources.myFleetDestroyerSunk;
                else if (!friendlySunkShips.Contains("aircraftCarrier") && friendlySunkShips.Contains("battleShip") && !friendlySunkShips.Contains("destroyer"))
                    myBigShipsPanel.BackgroundImage = Resources.myFleetBattleShipSunk;
                else if (!friendlySunkShips.Contains("aircraftCarrier") && friendlySunkShips.Contains("battleShip") && friendlySunkShips.Contains("destroyer"))
                    myBigShipsPanel.BackgroundImage = Resources.myFleetBattleShip_DestroyerSunk;
                else if (friendlySunkShips.Contains("aircraftCarrier") && !friendlySunkShips.Contains("battleShip") && !friendlySunkShips.Contains("destroyer"))
                    myBigShipsPanel.BackgroundImage = Resources.myFleetAircraftCarrierSunk;
                else if (friendlySunkShips.Contains("aircraftCarrier") && !friendlySunkShips.Contains("battleShip") && friendlySunkShips.Contains("destroyer"))
                    myBigShipsPanel.BackgroundImage = Resources.myFleetAircraftCarrier_BattleDestroyerSunk;
                else if (friendlySunkShips.Contains("aircraftCarrier") && friendlySunkShips.Contains("battleShip") && !friendlySunkShips.Contains("destroyer"))
                    myBigShipsPanel.BackgroundImage = Resources.myFleetAircraftCarrier_BattleShipSunk;
                else if (friendlySunkShips.Contains("aircraftCarrier") && friendlySunkShips.Contains("battleShip") && friendlySunkShips.Contains("destroyer"))
                    myBigShipsPanel.BackgroundImage = Resources.myFleetAircraftCarrier_BattleShip_DestroyerSunk;
            }
        }

        private void winnerTimer_Tick(object sender, EventArgs e)
        {
            if (winner == "")
                return;

            if(winner == "player" && !wasInstanciated)
            {
                int yLocation = 40;
                for(int i = 0; i < 3; i++)
                {

                    finalAirplanes[i] = new PictureBox();
                    finalAirplanes[i].Location = new Point(i == 1 ? -55 : -275, yLocation);
                    finalAirplanes[i].Size = new Size(57, 37);
                    finalAirplanes[i].BackgroundImageLayout = ImageLayout.Stretch;
                    finalAirplanes[i].BackColor = Color.Transparent;
                    finalAirplanes[i].BackgroundImage = Resources.airplane;
                    this.Controls.Add(finalAirplanes[i]);
                    finalAirplanes[i].BringToFront();
                    yLocation += 135;
                }

                SoundPlayer.Stream = Resources.airstrikeSound;
                SoundPlayer.Play();

                wasInstanciated = true;
            }
            else if(winner == "player" && wasInstanciated)
            {
                for(int i = 0; i < 3; i++)
                    finalAirplanes[i].Location = new Point(finalAirplanes[i].Location.X + 10, finalAirplanes[i].Location.Y);
            
                if(finalAirplanes[2].Location.X >= 980)
                {
                    for (int i = 0; i < 3; i++) { 
                        finalAirplanes[i].Dispose();
                        this.Controls.Remove(finalAirplanes[i]);
                        finalAirplanes[i] = null;
                    }

                    this.Enabled = false;
                    playerAnimationAndEnemyTurnTimer.Enabled = false;
                    winnerTimer.Enabled = false;
                    clearStaticData();

                    GameResultForm gameResultForm = new GameResultForm(true);
                    gameResultForm.Show();
                }
            }
            else if (winner == "AI" && !wasInstanciated)
            {
                int yLocation = 40;
                for (int i = 0; i < 3; i++)
                {

                    finalAirplanes[i] = new PictureBox();
                    finalAirplanes[i].Location = new Point(i == 1 ? 975 : 1250, yLocation);
                    finalAirplanes[i].Size = new Size(57, 37);
                    finalAirplanes[i].BackgroundImageLayout = ImageLayout.Stretch;
                    finalAirplanes[i].BackColor = Color.Transparent;
                    finalAirplanes[i].BackgroundImage = Resources.enemyAirplane;
                    this.Controls.Add(finalAirplanes[i]);
                    finalAirplanes[i].BringToFront();
                    yLocation += 135;
                }

                SoundPlayer.Stream = Resources.airstrikeSound;
                SoundPlayer.Play();

                wasInstanciated = true;
            }
            else if (winner == "AI" && wasInstanciated)
            {
                for (int i = 0; i < 3; i++)
                    finalAirplanes[i].Location = new Point(finalAirplanes[i].Location.X - 10, finalAirplanes[i].Location.Y);

                if (finalAirplanes[2].Location.X <= -55)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        finalAirplanes[i].Dispose();
                        this.Controls.Remove(finalAirplanes[i]);
                        finalAirplanes[i] = null;
                    }

                    this.Enabled = false;
                    playerAnimationAndEnemyTurnTimer.Enabled = false;
                    winnerTimer.Enabled = false;
                    clearStaticData();

                    SoundPlayer.Stream = Resources.gameOverSound;
                    SoundPlayer.Play();
                    GameResultForm gameResultForm = new GameResultForm(false);
                    gameResultForm.Show();
                }
            }
        }

        private void clearStaticData()
        {
            StaticData.Formation = new List<Vessel>();
            StaticData.EnemyFormation = new List<Vessel>();
            StaticData.EnemyTurn = false;
            StaticData.EnemyTilePanelId = -1;
            StaticData.EnemyWasHit = false;
            StaticData.EnemyWasDestroyed = false;
        }
    }
}
