using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class BabyGiant : Monster
    {
        //Fields

        //Props
        public bool Maneuverable { get; set; }

        //CTORS/Construstors
        public BabyGiant(int maxLife, string name, int hitChance, int block, int maxDamage, int minDamage, string description, bool maneuverable) : base(name, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            Maneuverable = maneuverable;
        }

        public BabyGiant()
        {
            Name = "Baby Giant";
            MaxLife = 20;
            Life = 20;
            MaxDamage = 5;
            MinDamage = 1;
            HitChance = 60;
            Block = 3;
            Description = "Smaller versions of Atlas! Some are extremely hard to hit!";
            Maneuverable = true;
        }
        //Methods
        public override string ToString()
        {
            return base.ToString() + $"\nManeuverable: {Maneuverable}";
        }

        public override int CalcHitChance()
        {
            if (Maneuverable)
            {
                HitChance += 10;
            }
            return HitChance;
        }
    }
}
