using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLayersOfWar
{
    internal class Final_Boss : Enemy
    {
        public Final_Boss() : base("Draconfruit, Destroyer of fields", 125, 15)
        {
        
        }

        public override void Attack(Player player) 
        {
            Console.WriteLine($"{Name} unleashes chaos fueled by his fruity fury!");
            base.Attack(player);
        
        }
    }
}
