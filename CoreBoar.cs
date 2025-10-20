using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TheLayersOfWar
{
    internal class CoreBoar : Mini_Boss
    {
        private static Random rng = new Random();
        public CoreBoar() : base("Core-Boar")
        {
            Health = 40;
            Damage = 9;
        }

        public override void Attack(Player player)
        {
            Console.WriteLine($"{Name} charges at you and crushes your layers and does {Damage} damage!");
            player.Health -= Damage;

            // 25% chance to stun the player
            if (rng.NextDouble() < 0.25)
            {
                player.IsStunned = true;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You are stunned and will miss your next turn!");
                Console.ResetColor();
            }
        }
    }
}
