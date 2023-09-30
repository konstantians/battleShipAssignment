using BattleShipGame.models;
using BattleShipGame.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace BattleShipGame
{
    public partial class FormationForm : Form
    {
        private VesselInControlPanel aircraftCarrierDetails = new VesselInControlPanel();
        private VesselInControlPanel battleShipDetails = new VesselInControlPanel();
        private VesselInControlPanel destroyerDetails = new VesselInControlPanel();
        private VesselInControlPanel frigateDetails = new VesselInControlPanel();
        private VesselInControlPanel submarineDetails = new VesselInControlPanel();
        private VesselInControlPanel corvetteDetails = new VesselInControlPanel();
        private List<VesselInControlPanel> allVessels = new List<VesselInControlPanel>(); 
        private VesselInControlPanel lastPickedShip = null;
        private SoundPlayer SoundPlayer = new SoundPlayer();
        private List<Panel> tilePanels = new List<Panel>();

        struct TilePanelAttributes
        {
            public int PanelId { get; set; }
            public bool IsFilled { get; set; }
            public int OccupiedCount { get; set; }
        }

        public FormationForm()
        {
            InitializeComponent();
            aircraftCarrierDetails.VesselName = "aircraftCarrier";
            aircraftCarrierDetails.VesselSize = 5;
            aircraftCarrierDetails.TilesLeft = 10;
            allVessels.Add(aircraftCarrierDetails);
            battleShipDetails.VesselName = "battleShip";
            battleShipDetails.VesselSize = 6;
            battleShipDetails.TilesLeft = 6;
            allVessels.Add(battleShipDetails);
            destroyerDetails.VesselName = "destroyer";
            destroyerDetails.VesselSize = 5;
            destroyerDetails.TilesLeft = 5;
            allVessels.Add(destroyerDetails);
            frigateDetails.VesselName = "frigate";
            frigateDetails.VesselSize = 4;
            frigateDetails.TilesLeft = 4;
            allVessels.Add(frigateDetails);
            submarineDetails.VesselName = "submarine";
            submarineDetails.VesselSize = 4;
            submarineDetails.TilesLeft = 4;
            allVessels.Add(submarineDetails);
            corvetteDetails.VesselName = "corvette";
            corvetteDetails.VesselSize = 3;
            corvetteDetails.TilesLeft = 3;
            allVessels.Add(corvetteDetails);
            this.ControlBox = false;
            this.DoubleBuffered = true;
            createTheTilePanels();
        }

        private void createTheTilePanels()
        {
            int startingLocationForX = 290;
            int startingLocationForY = 128;
            int count = 1;
            for (int i = 0; i < 14; i++)
            {
                for(int j = 0; j < 14; j++)
                {
                    Panel panel = new Panel();
                    panel.Name = $"panelTile{count}";
                    panel.BackColor = Color.Transparent;
                    panel.Size = new Size(23, 24);
                    panel.Location = new Point(startingLocationForX, startingLocationForY);
                    
                    TilePanelAttributes panelAttributes = new TilePanelAttributes();
                    panelAttributes.PanelId = j + i * 14;
                    panelAttributes.IsFilled = false;
                    panel.Tag= panelAttributes;
                    panel.BackgroundImageLayout = ImageLayout.Stretch;

                    tilePanels.Add(panel);
                    this.Controls.Add(panel);
                    if (j <= 9)
                        startingLocationForX += 24;
                    else
                        startingLocationForX += 25;
                    count++;
                
                }
                startingLocationForX = 290;
                if (i <= 6)
                    startingLocationForY += 26;
                else
                    startingLocationForY += 27;
            }
        }

        private void aircraftCarrierPictureBox_Click(object sender, EventArgs e)
        {
            if (aircraftCarrierDetails.IsBeingPicked || aircraftCarrierDetails.IsPlaced)
                return;

            aircraftCarrierDetails.MovingPictureBox = pictureBoxClickHelper(sender, aircraftCarrierDetails.MovingPictureBox);

            aircraftCarrierDetails.MovingPictureBox.MouseUp += AircraftCarrierMovingPictureBox_MouseUp;
            aircraftCarrierDetails.MovingPictureBox.BackgroundImage = Resources.aircraftCarrier;
            aircraftCarrierDetails.IsBeingPicked = true;
            
            aircraftCarrierPictureBox.BackgroundImage = Resources.aircraftCarrierShape;
            lastPickedShip = aircraftCarrierDetails;    
        }

        private void battleShipPictureBox_Click(object sender, EventArgs e)
        {
            if (battleShipDetails.IsBeingPicked || battleShipDetails.IsPlaced)
                return;

            battleShipDetails.MovingPictureBox = pictureBoxClickHelper(sender, battleShipDetails.MovingPictureBox);

            battleShipDetails.MovingPictureBox.MouseUp += BattleShipMovingPictureBox_MouseUp;
            battleShipDetails.MovingPictureBox.BackgroundImage = Resources.battleShip;
            battleShipDetails.IsBeingPicked = true;

            battleShipPictureBox.BackgroundImage = Resources.battleShipShape;
            lastPickedShip = battleShipDetails;
        }

        private void destroyerPictureBox_Click(object sender, EventArgs e)
        {
            if (destroyerDetails.IsBeingPicked || destroyerDetails.IsPlaced)
                return;

            destroyerDetails.MovingPictureBox = pictureBoxClickHelper(sender, destroyerDetails.MovingPictureBox);

            destroyerDetails.MovingPictureBox.MouseUp += DestroyerMovingPictureBox_MouseUp;
            destroyerDetails.MovingPictureBox.BackgroundImage = Resources.destroyer;
            destroyerDetails.IsBeingPicked = true;

            destroyerPictureBox.BackgroundImage = Resources.destroyerShape;
            lastPickedShip = destroyerDetails;
        }

        private void frigatePictureBox_Click(object sender, EventArgs e)
        {
            if (frigateDetails.IsBeingPicked || frigateDetails.IsPlaced)
                return;

            frigateDetails.MovingPictureBox = pictureBoxClickHelper(sender, frigateDetails.MovingPictureBox);

            frigateDetails.MovingPictureBox.MouseUp += FrigateMovingPictureBox_MouseUp;
            frigateDetails.MovingPictureBox.BackgroundImage = Resources.frigate;
            frigateDetails.IsBeingPicked = true;

            frigatePictureBox.BackgroundImage = Resources.frigateShape;
            lastPickedShip = frigateDetails;
        }

        private void submarinePictureBox_Click(object sender, EventArgs e)
        {
            if (submarineDetails.IsBeingPicked || submarineDetails.IsPlaced)
                return;

            submarineDetails.MovingPictureBox = pictureBoxClickHelper(sender, submarineDetails.MovingPictureBox);

            submarineDetails.MovingPictureBox.MouseUp += SubmarineMovingPictureBox_MouseUp;
            submarineDetails.MovingPictureBox.BackgroundImage = Resources.submarine;
            submarineDetails.IsBeingPicked = true;

            submarinePictureBox.BackgroundImage = Resources.submarineShape;
            lastPickedShip = submarineDetails;
        }

        private void corvettePictureBox_Click(object sender, EventArgs e)
        {
            if (corvetteDetails.IsBeingPicked || corvetteDetails.IsPlaced)
                return;

            corvetteDetails.MovingPictureBox = pictureBoxClickHelper(sender, corvetteDetails.MovingPictureBox);

            corvetteDetails.MovingPictureBox.MouseUp += CorvetteMovingPictureBox_MouseUp;
            corvetteDetails.MovingPictureBox.BackgroundImage = Resources.corvette;
            corvetteDetails.IsBeingPicked = true;

            corvettePictureBox.BackgroundImage = Resources.corvetteShape;
            lastPickedShip = corvetteDetails;
        }

        private PictureBox pictureBoxClickHelper(object sender, PictureBox movingPicture)
        {
            movingPicture = new PictureBox();
            movingPicture.BackColor = Color.Transparent;
            movingPicture.Size = ((PictureBox)sender).Size;
            movingPicture.Location = ((PictureBox)sender).Location;
            movingPicture.BackgroundImageLayout = ImageLayout.Stretch;

            this.Controls.Add(movingPicture);
            movingPicture.BringToFront();


            reverseShipButton.Visible = true;
            return movingPicture;
        }

        private void AircraftCarrierMovingPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            aircraftCarrierDetails = movingPictureHelper(aircraftCarrierDetails);
            if(!aircraftCarrierDetails.IsBeingPicked & !aircraftCarrierDetails.IsPlaced)
                aircraftCarrierPictureBox.BackgroundImage = Resources.aircraftCarrierWithGreenSkin;
        }

        private void BattleShipMovingPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            battleShipDetails = movingPictureHelper(battleShipDetails);
            if (!battleShipDetails.IsBeingPicked & !battleShipDetails.IsPlaced)
                battleShipPictureBox.BackgroundImage = Resources.battleShipWithGreenSkin;
        }

        private void DestroyerMovingPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            destroyerDetails = movingPictureHelper(destroyerDetails);
            if (!destroyerDetails.IsBeingPicked & !destroyerDetails.IsPlaced)
                destroyerPictureBox.BackgroundImage = Resources.destroyerWithGreenSKin;
        }

        private void FrigateMovingPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            frigateDetails = movingPictureHelper(frigateDetails);
            if (!frigateDetails.IsBeingPicked & !frigateDetails.IsPlaced)
                frigatePictureBox.BackgroundImage = Resources.frigateWithGreenSkin;
        }

        private void SubmarineMovingPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            submarineDetails = movingPictureHelper(submarineDetails);
            if (!submarineDetails.IsBeingPicked & !submarineDetails.IsPlaced)
                submarinePictureBox.BackgroundImage = Resources.submarineWithGreenSkin;
        }

        private void CorvetteMovingPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            corvetteDetails = movingPictureHelper(corvetteDetails);
            if (!corvetteDetails.IsBeingPicked & !corvetteDetails.IsPlaced)
                corvettePictureBox.BackgroundImage = Resources.corvetteWithGreenSkin;
        }

        private VesselInControlPanel movingPictureHelper(VesselInControlPanel vesselDetails)
        {
            //case where the moving picture was placed and the user wants to move it somewhere else
            if (!vesselDetails.IsBeingPicked)
            {
                vesselDetails.IsBeingPicked = true;
                vesselDetails.IsPlaced = false;
                resetVesselPanels(vesselDetails);
                lastPickedShip = vesselDetails;
                reverseShipButton.Visible = true;
                return vesselDetails;
            }

            //search if the user clicked on a valid location
            Point cursorLocation = this.PointToClient(Cursor.Position);
            cursorLocation.Offset(-10, -10);
            vesselDetails.MovingPictureBox.Location = cursorLocation;
            foreach (Panel panel in tilePanels)
            {
                //if it is not inside that then continue to the next panel
                if (!IsCursorInsidePanel(cursorLocation, panel))
                    continue;

                //if the panel is filled then reset the moving picture
                if (checkIfFilledAndIfItHasCollisions(panel, vesselDetails))
                {
                    vesselDetails = resetVesselDetails(vesselDetails);
                    panel.BackColor = Color.Transparent;
                    return vesselDetails;
                }

                //otherwise set the picture..
                vesselDetails.IsBeingPicked = false;
                vesselDetails.IsPlaced = true;
                setUpVesselMovingPictureLocation(vesselDetails, panel);
                panel.BackColor = Color.Transparent;
                fillPanels(vesselDetails,panel);
                return vesselDetails;
            }

            //if not reset moving picture
            vesselDetails = resetVesselDetails(vesselDetails);
            
            return vesselDetails;
        }

        private bool checkIfFilledAndIfItHasCollisions(Panel panel, VesselInControlPanel vesselDetails)
        {
            //if the panel is filled then reset the moving picture
            TilePanelAttributes tilePanelAttributes = (TilePanelAttributes)panel.Tag;
            if ((tilePanelAttributes.PanelId + (vesselDetails.VesselSize - 1) * 14 >= 196 && !vesselDetails.IsHorizontallyAligned) ||
                ((tilePanelAttributes.PanelId % 14) + vesselDetails.VesselSize >= 14 && vesselDetails.IsHorizontallyAligned) ||
                (tilePanelAttributes.PanelId % 14 == 13 && !vesselDetails.IsHorizontallyAligned && vesselDetails.VesselName == "aircraftCarrier"))
            {
                return true;
            }

            if (checkIfFilledAndIfItHasCollisionsHelper(tilePanelAttributes.PanelId, vesselDetails))
                return true;

            if (vesselDetails.VesselName == "aircraftCarrier" && !vesselDetails.IsHorizontallyAligned
                && checkIfFilledAndIfItHasCollisionsHelper(tilePanelAttributes.PanelId + 1, vesselDetails))
                return true;

            if (vesselDetails.VesselName == "aircraftCarrier" && vesselDetails.IsHorizontallyAligned
                && checkIfFilledAndIfItHasCollisionsHelper(tilePanelAttributes.PanelId + 14, vesselDetails))
                return true;

            return false;
        }

        private bool checkIfFilledAndIfItHasCollisionsHelper(int panelId, VesselInControlPanel vesselDetails)
        {
            if (panelId >= 196)
                return true;

            TilePanelAttributes tilePanelAttributes = (TilePanelAttributes)tilePanels[panelId].Tag;
            if (vesselDetails.IsHorizontallyAligned)
            {
                for (int i = tilePanelAttributes.PanelId; i < tilePanelAttributes.PanelId + vesselDetails.VesselSize; i++)
                {
                    TilePanelAttributes tempTileAttributes = (TilePanelAttributes)tilePanels[i].Tag;
                    if (tempTileAttributes.IsFilled)
                        return true;
                }
            }
            else if (!vesselDetails.IsHorizontallyAligned)
            {
                for (int i = tilePanelAttributes.PanelId; i < tilePanelAttributes.PanelId + vesselDetails.VesselSize * 14; i += 14)
                {
                    TilePanelAttributes tempTileAttributes = (TilePanelAttributes)tilePanels[i].Tag;
                    if (tempTileAttributes.IsFilled)
                        return true;
                }
            }
            return false;
        }

        private void fillPanels(VesselInControlPanel vesselDetails, Panel startingPanel)
        {
            TilePanelAttributes startingTileAttributes = (TilePanelAttributes)startingPanel.Tag;
            fillPanelsHelperMethod(startingTileAttributes.PanelId, vesselDetails);
            
            if(vesselDetails.VesselName == "aircraftCarrier" && !vesselDetails.IsHorizontallyAligned)
                fillPanelsHelperMethod(startingTileAttributes.PanelId + 1, vesselDetails);


            if (vesselDetails.VesselName == "aircraftCarrier" && vesselDetails.IsHorizontallyAligned)
                fillPanelsHelperMethod(startingTileAttributes.PanelId + 14, vesselDetails);

            fillNeighbours(vesselDetails);
        }

        private void fillPanelsHelperMethod(int panelId, VesselInControlPanel vesselDetails)
        {
            TilePanelAttributes startingTileAttributes = (TilePanelAttributes)tilePanels[panelId].Tag;
            if (vesselDetails.IsHorizontallyAligned)
            {
                for (int i = startingTileAttributes.PanelId; i < startingTileAttributes.PanelId + vesselDetails.VesselSize; i++)
                {
                    TilePanelAttributes TileAttributes = (TilePanelAttributes)tilePanels[i].Tag;
                    TileAttributes.IsFilled = true;
                    tilePanels[i].Tag = TileAttributes;
                    vesselDetails.PanelsItOccupies.Add(i);
                }

                return;
            }

            for (int i = startingTileAttributes.PanelId; i < startingTileAttributes.PanelId + vesselDetails.VesselSize * 14; i += 14)
            {
                TilePanelAttributes TileAttributes = (TilePanelAttributes)tilePanels[i].Tag;
                TileAttributes.IsFilled = true;
                tilePanels[i].Tag = TileAttributes;
                vesselDetails.PanelsItOccupies.Add(i);
            }
        }

        private void fillNeighbours(VesselInControlPanel vesselDetails)
        {
            
            foreach (int Id in vesselDetails.PanelsItOccupies)
            {
                int[] neighboursPanelIds = { Id - 15, Id - 14, Id - 13, Id - 1, Id + 1, Id + 13, Id + 14, Id + 15};
                for(int i = 0; i < neighboursPanelIds.Length; i++)
                {
                    if(neighboursPanelIds[i] < 0 || neighboursPanelIds[i] >= 196 ||
                       vesselDetails.PanelsItOccupies.Contains(neighboursPanelIds[i]))
                        continue; 

                    //this is for the left neighbour panels if they are out of the map/they do not exist
                    if ((i == 0 || i == 3 || i == 5) && neighboursPanelIds[i] % 14 == 13)
                        continue;

                    //this is for the right neighbour panels if they are out of the map/they do not exist
                    if ((i == 2 || i == 4 || i == 7) && neighboursPanelIds[i] % 14 == 0)
                        continue;

                    vesselDetails.NeighboursItOccupies.Add(neighboursPanelIds[i]);
                    TilePanelAttributes tilePanelAttributes = (TilePanelAttributes)tilePanels[neighboursPanelIds[i]].Tag;
                    tilePanelAttributes.OccupiedCount += 1;
                    tilePanelAttributes.IsFilled = true;
                    tilePanels[neighboursPanelIds[i]].Tag = tilePanelAttributes;
                    tilePanels[neighboursPanelIds[i]].BackgroundImage = Resources.occupiedAreaTile;
                }
            }
        }

        private void resetVesselPanels(VesselInControlPanel vesselDetails)
        {
            foreach(int panelId in vesselDetails.PanelsItOccupies)
            {
                TilePanelAttributes TileAttributes = (TilePanelAttributes)tilePanels[panelId].Tag;
                TileAttributes.IsFilled = false;
                tilePanels[panelId].Tag = TileAttributes;
            }

            foreach (int panelId in vesselDetails.NeighboursItOccupies)
            {
                TilePanelAttributes TileAttributes = (TilePanelAttributes)tilePanels[panelId].Tag;
                TileAttributes.OccupiedCount -= 1;
                if (TileAttributes.OccupiedCount == 0)
                {
                    TileAttributes.IsFilled = false;
                    tilePanels[panelId].BackgroundImage = null;
                }
                tilePanels[panelId].Tag = TileAttributes;
            }

            vesselDetails.PanelsItOccupies.Clear();
            vesselDetails.NeighboursItOccupies.Clear();
        }


        private void vesselPickedUpdateTimer_Tick(object sender, EventArgs e)
        {
            vesselPickedTimerHelper(aircraftCarrierDetails);
            vesselPickedTimerHelper(battleShipDetails);
            vesselPickedTimerHelper(destroyerDetails);
            vesselPickedTimerHelper(frigateDetails);
            vesselPickedTimerHelper(submarineDetails);
            vesselPickedTimerHelper(corvetteDetails);
        }

        private void vesselPickedTimerHelper(VesselInControlPanel vesselDetails)
        {
            if (vesselDetails.IsBeingPicked)
            {
                Point cursorLocation = this.PointToClient(Cursor.Position);
                cursorLocation.Offset(-10, -10);
                vesselDetails.MovingPictureBox.Location = cursorLocation;

                tilePanels.ForEach(panel =>
                {
                    if (IsCursorInsidePanel(cursorLocation, panel))
                    {
                        panel.BackColor = Color.Gray;
                    }
                    //otherwise check if the backcolor is gray and act accordingly
                    else if (panel.BackColor == Color.Gray)
                    {
                        panel.BackColor = Color.Transparent;
                    }
                });
            }
        }

        private bool IsCursorInsidePanel(Point cursorPosition, Panel panel)
        {
            int panelLeft = panel.Left;
            int panelTop = panel.Top;
            int panelRight = panel.Left + panel.Width;
            int panelBottom = panel.Top + panel.Height;

            return cursorPosition.X >= panelLeft && cursorPosition.X <= panelRight
                && cursorPosition.Y >= panelTop && cursorPosition.Y <= panelBottom;
        }

        private void resetFormationButton_Click(object sender, EventArgs e)
        {
            SoundPlayer.Stream = Resources.buttonClickSound;
            SoundPlayer.Play();

            aircraftCarrierDetails = resetVesselDetails(aircraftCarrierDetails);
            battleShipDetails = resetVesselDetails(battleShipDetails);
            destroyerDetails = resetVesselDetails(destroyerDetails);
            frigateDetails = resetVesselDetails(frigateDetails);
            submarineDetails = resetVesselDetails(submarineDetails);
            corvetteDetails = resetVesselDetails(corvetteDetails);

            aircraftCarrierPictureBox.BackgroundImage = Resources.aircraftCarrierWithGreenSkin;
            battleShipPictureBox.BackgroundImage = Resources.battleShipWithGreenSkin;
            destroyerPictureBox.BackgroundImage = Resources.destroyerWithGreenSKin;
            frigatePictureBox.BackgroundImage = Resources.frigateWithGreenSkin;
            submarinePictureBox.BackgroundImage = Resources.submarineWithGreenSkin;
            corvettePictureBox.BackgroundImage = Resources.corvetteWithGreenSkin;
        }

        private VesselInControlPanel resetVesselDetails(VesselInControlPanel vesselDetails)
        {
            vesselDetails.IsBeingPicked = false;
            vesselDetails.IsPlaced = false;
            vesselDetails.IsHorizontallyAligned = false;

            resetVesselPanels(vesselDetails);
            
            if (vesselDetails.MovingPictureBox != null)
            {
                vesselDetails.MovingPictureBox.Dispose();
                vesselDetails.MovingPictureBox = null;
            }

            lastPickedShip = null;
            reverseShipButton.Visible = false;
            return vesselDetails;
        }

        private void autoCompleteFormationButton_Click(object sender, EventArgs e)
        {
            if (aircraftCarrierDetails.IsPlaced || battleShipDetails.IsPlaced || destroyerDetails.IsPlaced ||
                frigateDetails.IsPlaced || submarineDetails.IsPlaced || corvetteDetails.IsPlaced)
                resetFormationButton_Click(new object(), new EventArgs());
            else
            {
                SoundPlayer.Stream = Resources.buttonClickSound;
                SoundPlayer.Play();
            }

            Random random = new Random();

            List<int> availablePositions = Enumerable.Range(0, 197).ToList();

            foreach (VesselInControlPanel vessel in allVessels)
            {
                int chosenStartingPanelId;
                int orientationResult;
                do
                {
                    chosenStartingPanelId = random.Next(availablePositions.Count);
                    //vertical = 0, horizontal = 1
                    orientationResult = random.Next(2);
                    vessel.IsHorizontallyAligned = orientationResult == 0 ? false : true;
                }
                while (checkIfFilledAndIfItHasCollisions(tilePanels[chosenStartingPanelId], vessel));
                vessel.IsBeingPicked = false;
                vessel.IsPlaced = true;
                vessel.MovingPictureBox = new PictureBox();
                vessel.MovingPictureBox.BackColor = Color.Transparent;
                vessel.MovingPictureBox.BackgroundImageLayout = ImageLayout.Stretch;

                setUpVesselMovingPictureLocation(vessel, tilePanels[chosenStartingPanelId]);

                switch (vessel.VesselName)
                {
                    case "aircraftCarrier":
                        vessel.MovingPictureBox.MouseUp += AircraftCarrierMovingPictureBox_MouseUp;
                        aircraftCarrierDetails.MovingPictureBox.BackgroundImage = vessel.IsHorizontallyAligned ?
                            Resources.aircraftCarrierHorizontal : Resources.aircraftCarrier;
                        aircraftCarrierDetails.MovingPictureBox.Size = aircraftCarrierPictureBox.Size;
                        aircraftCarrierPictureBox.BackgroundImage = Resources.aircraftCarrierShape;
                        break;
                    case "battleShip":
                        vessel.MovingPictureBox.MouseUp += BattleShipMovingPictureBox_MouseUp;
                        battleShipDetails.MovingPictureBox.BackgroundImage = vessel.IsHorizontallyAligned ? 
                            Resources.battleShipHorizontal : Resources.battleShip;
                        battleShipDetails.MovingPictureBox.Size = battleShipPictureBox.Size;
                        battleShipPictureBox.BackgroundImage = Resources.battleShipShape;
                        break;
                    case "destroyer":
                        vessel.MovingPictureBox.MouseUp += DestroyerMovingPictureBox_MouseUp;
                        destroyerDetails.MovingPictureBox.BackgroundImage = vessel.IsHorizontallyAligned ? 
                           Resources.destroyerHorizontal : Resources.destroyer;
                        destroyerDetails.MovingPictureBox.Size = destroyerPictureBox.Size;
                        destroyerPictureBox.BackgroundImage = Resources.destroyerShape;
                        break;
                    case "frigate":
                        vessel.MovingPictureBox.MouseUp += FrigateMovingPictureBox_MouseUp;
                        frigateDetails.MovingPictureBox.BackgroundImage = vessel.IsHorizontallyAligned ? 
                            Resources.frigateHorizontal : Resources.frigate;
                        frigateDetails.MovingPictureBox.Size = frigatePictureBox.Size;
                        frigatePictureBox.BackgroundImage = Resources.frigateShape;
                        break;
                    case "submarine":
                        vessel.MovingPictureBox.MouseUp += SubmarineMovingPictureBox_MouseUp;
                        submarineDetails.MovingPictureBox.BackgroundImage = vessel.IsHorizontallyAligned ? 
                           Resources.submarineHorizontal : Resources.submarine;
                        submarineDetails.MovingPictureBox.Size = submarinePictureBox.Size;
                        submarinePictureBox.BackgroundImage = Resources.submarineShape;
                        break;
                    case "corvette":
                        vessel.MovingPictureBox.MouseUp += CorvetteMovingPictureBox_MouseUp;
                        corvetteDetails.MovingPictureBox.BackgroundImage = vessel.IsHorizontallyAligned ? 
                           Resources.corvetteHorizontal : Resources.corvette;
                        corvetteDetails.MovingPictureBox.Size = corvettePictureBox.Size;
                        corvettePictureBox.BackgroundImage = Resources.corvetteShape;
                        break;
                }
                this.Controls.Add(vessel.MovingPictureBox);
                vessel.MovingPictureBox.BringToFront();

                fillPanels(vessel, tilePanels[chosenStartingPanelId]);

                //used to reverse the image height and width if the image is set horizontal
                if (vessel.IsHorizontallyAligned)
                    swapWidthAndHeightOfPicture(vessel);


                foreach (int PanelId in vessel.PanelsItOccupies)
                    availablePositions.Remove(PanelId);

                foreach (int PanelId in vessel.NeighboursItOccupies)
                    availablePositions.Remove(PanelId);
            }
        }

        private void reverseShipButton_Click(object sender, EventArgs e)
        {
            SoundPlayer.Stream = Resources.buttonClickSound;
            SoundPlayer.Play();

            if (lastPickedShip.IsHorizontallyAligned)
            {
                reverseShipHelperMethod(false);
                return;
            }
            reverseShipHelperMethod(true);
        }

        private void reverseShipHelperMethod(bool turnHorizontal)
        {
            if (turnHorizontal)
                lastPickedShip.IsHorizontallyAligned = true;
            else
                lastPickedShip.IsHorizontallyAligned = false;

            Panel startingPanel = tilePanels[lastPickedShip.PanelsItOccupies[0]];
            resetVesselPanels(lastPickedShip);
            //if there are collisions reset the vessel
            if (checkIfFilledAndIfItHasCollisions(startingPanel, lastPickedShip))
            {
                switch (lastPickedShip.VesselName)
                {
                    case "aircraftCarrier":
                        aircraftCarrierPictureBox.BackgroundImage = Resources.aircraftCarrierWithGreenSkin;
                        break;
                    case "battleShip":
                        battleShipPictureBox.BackgroundImage = Resources.battleShipWithGreenSkin;
                        break;
                    case "destroyer":
                        destroyerPictureBox.BackgroundImage = Resources.destroyerWithGreenSKin;
                        break;
                    case "frigate":
                        frigatePictureBox.BackgroundImage = Resources.frigateWithGreenSkin;
                        break;
                    case "submarine":
                        submarinePictureBox.BackgroundImage = Resources.submarineWithGreenSkin;
                        break;
                    case "corvette":
                        corvettePictureBox.BackgroundImage = Resources.corvetteWithGreenSkin;
                        break;
                }
                resetVesselDetails(lastPickedShip);
                return;
            }

            fillPanels(lastPickedShip, startingPanel);
            setUpVesselMovingPictureLocation(lastPickedShip, tilePanels[lastPickedShip.PanelsItOccupies[0]]);

            swapWidthAndHeightOfPicture(lastPickedShip);

            if (turnHorizontal)
                switch (lastPickedShip.VesselName)
                {
                    case "aircraftCarrier":
                        lastPickedShip.MovingPictureBox.BackgroundImage = Resources.aircraftCarrierHorizontal;
                        break;
                    case "battleShip":
                        lastPickedShip.MovingPictureBox.BackgroundImage = Resources.battleShipHorizontal;
                        break;
                    case "destroyer":
                        lastPickedShip.MovingPictureBox.BackgroundImage = Resources.destroyerHorizontal;
                        break;
                    case "frigate":
                        lastPickedShip.MovingPictureBox.BackgroundImage = Resources.frigateHorizontal;
                        break;
                    case "submarine":
                        lastPickedShip.MovingPictureBox.BackgroundImage = Resources.submarineHorizontal;
                        break;
                    case "corvette":
                        lastPickedShip.MovingPictureBox.BackgroundImage = Resources.corvetteHorizontal;
                        break;
                }
            else
                switch (lastPickedShip.VesselName)
                {
                    case "aircraftCarrier":
                        lastPickedShip.MovingPictureBox.BackgroundImage = Resources.aircraftCarrier;
                        break;
                    case "battleShip":
                        lastPickedShip.MovingPictureBox.BackgroundImage = Resources.battleShip;
                        break;
                    case "destroyer":
                        lastPickedShip.MovingPictureBox.BackgroundImage = Resources.destroyer;
                        break;
                    case "frigate":
                        lastPickedShip.MovingPictureBox.BackgroundImage = Resources.frigate;
                        break;
                    case "submarine":
                        lastPickedShip.MovingPictureBox.BackgroundImage = Resources.submarine;
                        break;
                    case "corvette":
                        lastPickedShip.MovingPictureBox.BackgroundImage = Resources.corvette;
                        break;
                }
        }

        private void swapWidthAndHeightOfPicture(VesselInControlPanel vesselDetails)
        {
            int newWidth = vesselDetails.MovingPictureBox.Height;
            int newHeight = vesselDetails.MovingPictureBox.Width;
            vesselDetails.MovingPictureBox.Width = newWidth;
            vesselDetails.MovingPictureBox.Height = newHeight;
        }

        private void setUpVesselMovingPictureLocation(VesselInControlPanel vesselDetails, Panel panel)
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

        private void gameStartButton_Click(object sender, EventArgs e)
        {
            SoundPlayer.Stream = Resources.buttonClickSound;
            SoundPlayer.Play();
            aircraftCarrierDetails.MovingPictureBox.MouseUp -= AircraftCarrierMovingPictureBox_MouseUp;
            battleShipDetails.MovingPictureBox.MouseUp -= BattleShipMovingPictureBox_MouseUp;
            destroyerDetails.MovingPictureBox.MouseUp -= DestroyerMovingPictureBox_MouseUp;
            frigateDetails.MovingPictureBox.MouseUp -= FrigateMovingPictureBox_MouseUp;
            submarineDetails.MovingPictureBox.MouseUp -= SubmarineMovingPictureBox_MouseUp;
            corvetteDetails.MovingPictureBox.MouseUp -= CorvetteMovingPictureBox_MouseUp;
            foreach (VesselInControlPanel vesselInControl in allVessels)
                StaticData.Formation.Add(new Vessel(vesselInControl));
            

            List<VesselInControlPanel> enemyVessels = new List<VesselInControlPanel>();
            VesselInControlPanel enemyAircraftCarrierDetails = new VesselInControlPanel();
            enemyAircraftCarrierDetails.VesselName = "aircraftCarrier";
            enemyAircraftCarrierDetails.VesselSize = 5;
            enemyAircraftCarrierDetails.TilesLeft = 10;
            enemyVessels.Add(enemyAircraftCarrierDetails);
            VesselInControlPanel enemyBattleShipDetails = new VesselInControlPanel();
            enemyBattleShipDetails.VesselName = "battleShip";
            enemyBattleShipDetails.VesselSize = 6;
            enemyBattleShipDetails.TilesLeft = 6;
            enemyVessels.Add(enemyBattleShipDetails);
            VesselInControlPanel enemyDestroyerDetails = new VesselInControlPanel();
            enemyDestroyerDetails.VesselName = "destroyer";
            enemyDestroyerDetails.VesselSize = 5;
            enemyDestroyerDetails.TilesLeft = 5;
            enemyVessels.Add(enemyDestroyerDetails);
            VesselInControlPanel enemyFrigateDetails = new VesselInControlPanel();
            enemyFrigateDetails.VesselName = "frigate";
            enemyFrigateDetails.VesselSize = 4;
            enemyFrigateDetails.TilesLeft = 4;
            enemyVessels.Add(enemyFrigateDetails);
            VesselInControlPanel enemySubmarineDetails = new VesselInControlPanel();
            enemySubmarineDetails.VesselName = "submarine";
            enemySubmarineDetails.VesselSize = 4;
            enemySubmarineDetails.TilesLeft = 4;
            enemyVessels.Add(enemySubmarineDetails);
            VesselInControlPanel enemyCorvetteDetails = new VesselInControlPanel();
            enemyCorvetteDetails.VesselName = "corvette";
            enemyCorvetteDetails.VesselSize = 3;
            enemyCorvetteDetails.TilesLeft = 3;
            enemyVessels.Add(enemyCorvetteDetails);

            tilePanels.ForEach(panel => {
                TilePanelAttributes tilePanelAttributes = (TilePanelAttributes)panel.Tag;
                tilePanelAttributes.IsFilled = false;
                tilePanelAttributes.OccupiedCount = 0;
                panel.Tag = tilePanelAttributes;
            });

            //set the enemy formation
            Random random = new Random();
            List<int> availablePositions = Enumerable.Range(0, 197).ToList();
            foreach (VesselInControlPanel vessel in enemyVessels)
            {
                int chosenStartingPanelId;
                int orientationResult;
                do
                {
                    chosenStartingPanelId = random.Next(availablePositions.Count);
                    //vertical = 0, horizontal = 1
                    orientationResult = random.Next(2);
                    vessel.IsHorizontallyAligned = orientationResult == 0 ? false : true;
                }
                while (checkIfFilledAndIfItHasCollisions(tilePanels[chosenStartingPanelId], vessel));
                vessel.MovingPictureBox = new PictureBox();
                vessel.MovingPictureBox.BackColor = Color.Transparent;
                vessel.MovingPictureBox.BackgroundImageLayout = ImageLayout.Stretch;

                switch (vessel.VesselName)
                {
                    case "aircraftCarrier":
                        enemyAircraftCarrierDetails.MovingPictureBox.BackgroundImage = vessel.IsHorizontallyAligned ?
                            Resources.aircraftCarrierHorizontal : Resources.aircraftCarrier;
                        enemyAircraftCarrierDetails.MovingPictureBox.Size = aircraftCarrierPictureBox.Size;
                        break;
                    case "battleShip":
                        enemyBattleShipDetails.MovingPictureBox.BackgroundImage = vessel.IsHorizontallyAligned ?
                            Resources.battleShipHorizontal : Resources.battleShip;
                        enemyBattleShipDetails.MovingPictureBox.Size = battleShipPictureBox.Size;
                        break;
                    case "destroyer":
                        enemyDestroyerDetails.MovingPictureBox.BackgroundImage = vessel.IsHorizontallyAligned ?
                           Resources.destroyerHorizontal : Resources.destroyer;
                        enemyDestroyerDetails.MovingPictureBox.Size = destroyerPictureBox.Size;
                        break;
                    case "frigate":
                        enemyFrigateDetails.MovingPictureBox.BackgroundImage = vessel.IsHorizontallyAligned ?
                            Resources.frigateHorizontal : Resources.frigate;
                        enemyFrigateDetails.MovingPictureBox.Size = frigatePictureBox.Size;
                        break;
                    case "submarine":
                        enemySubmarineDetails.MovingPictureBox.BackgroundImage = vessel.IsHorizontallyAligned ?
                           Resources.submarineHorizontal : Resources.submarine;
                        enemySubmarineDetails.MovingPictureBox.Size = submarinePictureBox.Size;
                        break;
                    case "corvette":
                        enemyCorvetteDetails.MovingPictureBox.BackgroundImage = vessel.IsHorizontallyAligned ?
                           Resources.corvetteHorizontal : Resources.corvette;
                        enemyCorvetteDetails.MovingPictureBox.Size = corvettePictureBox.Size;
                        break;
                }

                fillPanels(vessel, tilePanels[chosenStartingPanelId]);

                //used to reverse the image height and width if the image is set horizontal
                if (vessel.IsHorizontallyAligned)
                    swapWidthAndHeightOfPicture(vessel);

                vessel.MovingPictureBox.Visible = false;

                foreach (int PanelId in vessel.PanelsItOccupies)
                    availablePositions.Remove(PanelId);

                foreach (int PanelId in vessel.NeighboursItOccupies)
                    availablePositions.Remove(PanelId);

            }
            foreach (VesselInControlPanel vesselInControlPanel in enemyVessels)
            {
                StaticData.EnemyFormation.Add(vesselInControlPanel);
            }
            StaticData.LoadGameForm = true;
        }

        private void revealStartGameButtonTimer_Tick(object sender, EventArgs e)
        {
            if (aircraftCarrierDetails.IsPlaced && battleShipDetails.IsPlaced && destroyerDetails.IsPlaced &&
                frigateDetails.IsPlaced && submarineDetails.IsPlaced && corvetteDetails.IsPlaced)
                gameStartButton.Visible = true;
            else
                gameStartButton.Visible = false;
        }
    }
}
