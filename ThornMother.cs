using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TheLayersOfWar
{
    internal class ThornMother : Mini_Boss
    {
        private bool hasHealed = false;
        private const int MaxHealth = 45;

        public ThornMother() : base("Thorn Mother")
        {
            Health = 65;
            Damage = 15;
        }

        public override void Attack(Player player)
        {
            if (!hasHealed && Health <= MaxHealth * 0.35)
            {
                hasHealed = true;
                int healAmount = MaxHealth - Health; // heals fully
                Health = MaxHealth;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Name} retreats into her vines and regrows! She heals {healAmount} HP.");
                Console.ResetColor();
            }

            Console.WriteLine($"{Name} lashes out with razor vines! You take {Damage} damage.");
            player.Health -= Damage;    
        }
    }
}
