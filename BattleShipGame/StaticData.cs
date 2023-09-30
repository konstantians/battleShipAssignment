using BattleShipGame.models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace BattleShipGame
{
    public static class StaticData
    {
        public static List<Vessel> Formation { get; set; } = new List<Vessel>();
        public static List<Vessel> EnemyFormation { get; set; } = new List<Vessel>();
        public static bool LoadFormationForm { get; set; } = false;
        public static bool LoadGameForm { get; set; } = false;
        public static bool EnemyTurn { get; set; } = false;
        public static int EnemyTilePanelId { get; set; } = -1;
        public static bool EnemyWasHit { get; set; } = false;
        public static bool EnemyWasDestroyed { get; set; } = false;
    }
}
