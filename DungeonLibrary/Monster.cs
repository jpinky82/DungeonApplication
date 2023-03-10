using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {

        //Fields

        private int _minDamage;

        //Props

        public int MaxDamage { get; set; }
        public string Description { get; set; } = null!;
        public int MinDamage
        { 
            get { return _minDamage;} 
            set { _minDamage = value > 0 && value <= MaxDamage ? value : 0; } 
        }


        //CTORS/Construstors

        public Monster(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description) : base(name, hitChance, block, maxLife)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
        }

        public Monster() { }

        //Methods

        public override string ToString()
        {
            return base.ToString() + $"Max Damage: {MaxDamage}\nMin Damage: {MinDamage}\nDescription: {Description}\n";
        }

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }

        public static Monster GetBossMonster(byte monsterNumber)
        {
            switch (monsterNumber)
            {
                case 1: 
                    return new ("Shelob", 70, 8, 30, 5, 1, "A GIANT spider...She's fast and stealthy but vulerable.");
                case 2:
                    return new("The Knight King", 70, 5, 50, 10, 4, "He's powerful but...anyone made of ice is bound to be a bit slow.");
                case 3:
                    return new("Atlas", 70, 4, 60, 20, 5, "He's Giant!.....but very slow.");
                case 4:
                    return new("Smaug", 70, 9, 50, 15, 1, "The last great dragon.");
                default:
                    return new("Shelob", 70, 8, 30, 5, 1, "A GIANT spider...She's fast and stealthy but vulerable.");//Shelob will be the default should it be needed.
            }
        }
        
        public static Monster GetBabyMonster()
        {
            //Create a variety of monsters

            BabySpider m5 = new();
            BabyDragon m6 = new();
            WhiteWalker m7 = new();
            BabyGiant m8 = new();
            //Add the monsters to a collection

            List<Monster> monsters = new()
            {
                m5,
                m6,
                m7,
                m8
            };

            return monsters[new Random().Next(monsters.Count)];

            //Pick one at random to place in our dungeon room    
        }
    }
}
