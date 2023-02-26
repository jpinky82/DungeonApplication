using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class BabySpider : Monster
    {
        //Fields

        //Props

        public bool HasCamo { get; set; }

        //CTORS/Construstors

        public BabySpider(int maxLife, string name, int hitChance, int block, int maxDamage, int minDamage, string description, bool hasCamo) : base(name, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            HasCamo = hasCamo;
        }

        public BabySpider()
        {
            Name = "Baby Shelob";
            MaxLife = 20;
            Life = 20;
            MaxDamage = 5;
            MinDamage = 1;
            HitChance = 60;
            Block = 3;
            Description = "Shelob's Minions! Some are translucent and camouflage easily!";
            HasCamo = true;
        }

        //Methods

        public override string ToString()
        {
            return base.ToString() + $"\nCamouflage: {HasCamo}";
        }

        public override int CalcBlock()
        {
            if (HasCamo)
            {
                Block += 10;
            }
            
            return Block;
        }

    }
}
