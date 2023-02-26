using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonLibrary
{
    internal class BabyDragon : Monster
        {
            public bool HasScales { get; set; }


            public BabyDragon(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description, bool hasScales) :
                base(name, hitChance, block, maxLife, maxDamage, minDamage, description)
            {
                HasScales = hasScales;
            }

            public BabyDragon()
            {
                Name = "Norbert";
                MaxLife = 20;
                Life = 20;
                MaxDamage = 5;
                MinDamage = 1;
                HitChance = 60;
                Block = 10;
                Description = "He looks so cute!  Until he eats you alive.  Be especially careful if he has scales!";
                HasScales = false;
            }


            public override string ToString()
            {
                return base.ToString() + ($"\nHas Scales?: {HasScales}");
            }

            public override int CalcBlock()
            {
                int calculatedBlock = Block;

                if (HasScales)
                {
                    calculatedBlock += 10;
                }

                return calculatedBlock;
            }
        }
    }
