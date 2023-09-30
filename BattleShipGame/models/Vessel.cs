using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipGame.models
{
    public class Vessel
    {
        public string VesselName { get; set; }
        public int VesselSize { get; set; }
        public bool IsHorizontallyAligned { get; set; }
        public List<int> PanelsItOccupies { get; set; } = new List<int>();
        public List<int> NeighboursItOccupies { get; set; } = new List<int>();
        public PictureBox MovingPictureBox { get; set; } = null;
        public int TilesLeft { get; set; }

        public Vessel(){}

        public Vessel(VesselInControlPanel vesselInControlPanel)
        {
            VesselName = vesselInControlPanel.VesselName;
            VesselSize = vesselInControlPanel.VesselSize;
            TilesLeft = vesselInControlPanel.TilesLeft;
            IsHorizontallyAligned = vesselInControlPanel.IsHorizontallyAligned;
            PanelsItOccupies = vesselInControlPanel.PanelsItOccupies;
            NeighboursItOccupies = vesselInControlPanel.NeighboursItOccupies;
            MovingPictureBox = vesselInControlPanel.MovingPictureBox;
        }
    }
}
