using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipGame.models
{
    public class VesselInControlPanel : Vessel
    {
        public bool IsBeingPicked { get; set; }
        public bool IsPlaced { get; set; }
    }
}
