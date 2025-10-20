using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLayersOfWar
{
    internal class Final_Boss : Enemy
    {
        private static Random rng = new Random();
        private int turnCounter = 0;

        public Final_Boss() : base("Draconfruit, the Decayed Tyrant", 125, 15)
        {

        }

        public override void Attack(Player player)
        {
            turnCounter++;

            // Every 3rd turn, use special attack
            if (turnCounter % 3 == 0)
            {
                UseSummonAttack(player);
            }
            else
            {
                Console.WriteLine($"{Name} breathes corrupted flame! You take {Damage} damage!");
                player.Health -= Damage;
            }
        }

        private void UseSummonAttack(Player player)
        {
            int numberOfMinis = rng.Next(2, 5); // 2 to 4 mini-Draconfruits
            string[] taunts = {
               "They are the seeds of your end!",
               "You can't squash them all!",
               "Even my rotten spawn are stronger than you!",
               "They rot together, they fight together!",
               "A fruit never falls far from corruption!"
            };

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"\n{Name} lets out a rotten screech!");
            Console.WriteLine($"{numberOfMinis} tiny Draconfruits burst from his core and swarm you!");
            Console.WriteLine($"\"{taunts[rng.Next(taunts.Length)]}\"");  // Random taunt
            Console.ResetColor();

            int totalMiniDamage = numberOfMinis * 2;
            Console.WriteLine($"Each bites for 2 damage — you take {totalMiniDamage} total damage!");

            player.Health -= totalMiniDamage;
        }

    }
}


