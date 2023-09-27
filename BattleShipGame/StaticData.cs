using BattleShipGame.models;
using System.Collections.Generic;
using System.ComponentModel;

namespace BattleShipGame
{
    public static class StaticData
    {
        public static List<VesselInControlPanel> Formation { get; set; } = null;
        public static List<VesselInControlPanel> EnemyFormation { get; set; } = null;
        public static bool LoadFormationForm { get; set; } = false;
        public static bool LoadGameForm { get; set; } = false;
        public static bool EnemyTurn { get; set; } = false;
        /*public static bool LoadShootEnemyShipForm { get; set; } = false;*/
    }
}
