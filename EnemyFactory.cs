using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLayersOfWar
{
    internal class EnemyFactory
    {
        public static List<Enemy> GetEnemiesForLevel(string world, int level)
        {
            if (world == "Cave of whispers")
                return new List<Enemy>(); // Final boss is handled separately

            if (level == 3)
            {
                if (world == "Ruins of Layeria")
                    return new List<Enemy> { new CoreBoar() };

                if (world == "Bitterroot Forest")
                    return new List<Enemy> { new ThornMother() };
            }

            if (world == "Ruins of Layeria")
                return GetRuinsEnemies(level);

            if (world == "Bitterroot Forest")
                return GetBitterrootEnemies(level);

            return new List<Enemy> { new Enemy("Unknown Creature", 10, 2) };
        }

        private static List<Enemy> GetRuinsEnemies(int level)
        {
            return level switch
            {
                1 => new List<Enemy>
                {
                    new Enemy("Cucumber Rider", 15, 4),
                    new Enemy("Root Goblin", 12, 3)
                },
                2 => new List<Enemy>
                {
                    new Enemy("Pepper Sentinel", 18, 5),
                    new Enemy("Red Beet Rebel", 16, 4),
                    new Enemy("Shallot Sneaker", 10, 2)
                },
                _ => new List<Enemy>()
            };
        }

        private static List<Enemy> GetBitterrootEnemies(int level)
        {
            return level switch
            {
                1 => new List<Enemy>
                {
                    new Enemy("Spore Wolf", 16, 4),
                    new Enemy("Mushroom Warrior", 14, 3)
                },
                2 => new List<Enemy>
                {
                    new Enemy("Thorn Runner", 20, 5),
                    new Enemy("Bitter Wraith", 12, 6),
                    new Enemy("Bark Howler", 14, 3)
                },
                _ => new List<Enemy>()
            };
        }
    }
}

