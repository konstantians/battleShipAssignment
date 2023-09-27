using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipGame.models
{
    public class VesselInControlPanel
    {
        public string VesselName { get; set; }
        public int VesselSize { get; set; }
        public bool IsHorizontallyAligned { get; set; } 
        public List<int> PanelsItOccupies { get; set; } = new List<int>();
        public List<int> NeighboursItOccupies { get; set; } = new List<int>();
        public bool IsBeingPicked { get; set; }
        public bool IsPlaced { get; set; }
        public PictureBox MovingPictureBox { get; set; } = null;
    }
}
