using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLayersOfWar
{
    internal class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Damage { get; set; }

        public Enemy(string name, int health, int damage) 
        {
            Name = name;
            MaxHealth = health;   // MaxHealth korrekt setzen
            Health = MaxHealth;   // Health immer auf Startwert setzen
            Damage = damage;
        }

        public void ResetHealth()
        {
            Health = MaxHealth;
        }

        public virtual void Attack(Player player) 
        {
            Console.WriteLine($"{Name} is attacking and rips off {Damage} of your Layers");
            player.Health -= Damage;
        
        }
    } 
}
