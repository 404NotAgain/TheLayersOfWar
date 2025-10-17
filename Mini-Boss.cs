using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLayersOfWar
{
    internal class Mini_Boss : Enemy
    {
        public Mini_Boss(string name) : base(name, 30, 8) 
        {
        
        }

        public override void Attack(Player player)
        {
            Console.WriteLine($"{Name} (Mini-Boss) is attacking you swiftly with its special move!");
            base.Attack(player);
        }

    }
}
