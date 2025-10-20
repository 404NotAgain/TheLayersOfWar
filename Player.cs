using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLayersOfWar
{
    internal class Player
    {
        public string WarriorName { get; set; }
        public string WiseName { get; set; }

        public int Damage { get; set; } = 5;
        public int Health { get; set; }
        public int MaxHealth { get; set; } = 25;

        public int XP { get; set; } = 0;
        public int Level { get; set; } = 1;

        public bool IsStunned { get; set; } = false;


        public DateTime SaveTime { get; set; }
        public string CurrentWorld { get; set; } = string.Empty;

        public void Heal() 
        {
            int healAmount = 10;
            int preHeal = Health;

            Health += healAmount;
            if (Health > MaxHealth)
                Health = MaxHealth;

            int actualHealed = Health - preHeal;
            Console.WriteLine($"\nYou cried out loud, your tears felt sorry for you and healed you by {actualHealed} HP!");
        }

        public void XPGain(int amount)
        {
            XP += amount;
            Console.WriteLine($"\nYou peeled back {amount} XP layers!");

            int levelsGained = 0;

            while (XP >= 10)
            {
                XP -= 10;
                Level++;
                levelsGained++;

                MaxHealth += 2; // Now scaling MaxHealth
                Health = MaxHealth; // Full heal on level-up?
                Damage += 1;

                Console.WriteLine($"You’ve sliced through to Level {Level}! (+2 Max HP, +1 Damage)");
                Thread.Sleep(800);
            }

            if (levelsGained > 1)
            {
                Console.WriteLine($"\nIncredible! You’ve leveled up {levelsGained} times — you’re the *root* of all strength now!");
            }
            else if (levelsGained == 1)
            {
                Console.WriteLine("\nA fresh layer of power has been unlocked! Keep chopping!");
            }
            else
            {
                Console.WriteLine("\nKeep peeling back those XP layers to grow stronger!");
            }
        }


    }
}
