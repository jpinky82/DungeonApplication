using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class WhiteWalker : Monster
    {
        public bool HasArmour { get; set; }


        public WhiteWalker(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description, bool hasArmour) : 
            base(name, hitChance, block, maxLife, maxDamage, minDamage, description)
        {
            HasArmour = hasArmour;
        }

        public WhiteWalker()
        {
            Name = "Icey";
            MaxLife = 20;
            Life = 20;
            MaxDamage = 5;
            MinDamage = 1;
            HitChance = 60;
            Block = 3;
            Description = "A lieutenant of the Night King, Some have armour and are a bit harder to kill!";
            HasArmour = false;
        }


        public override string ToString()
        {
            return base.ToString() + ($"\nHas Armour?: {HasArmour}");
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (HasArmour)
            {
                calculatedBlock += 10;
            }

            return calculatedBlock;
        }
    }
}
