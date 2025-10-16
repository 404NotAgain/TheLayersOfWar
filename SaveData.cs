using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLayersOfWar
{
    public class SaveData
    {
        public string WarriorName { get; set; }
        public string WiseName { get; set; }

        public int Damage { get; set; } = 5;
        public int Health { get; set; } = 25;
        public int ArmorValue { get; set; } = 0;
        public int XP { get; set; } = 0;
        public int Level { get; set; } = 1;
        public DateTime SaveTime { get; set; }
        public string CurrentWorld { get; set; } = string.Empty;

    }
}
