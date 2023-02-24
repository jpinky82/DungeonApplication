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
        public int MinDamage
        { 
            get { return _minDamage;} 
            set { _minDamage = value > 0 && value <= MaxDamage ? value : 0; } 
        }
        public string Description { get; set; } = null!;

        //CTORS/Construstors

        public Monster(int maxLife, string name, int hitChance, int block, int maxDamage, int minDamage, string description) : base(maxLife, name, hitChance, block)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
        }

        //Methods

        public override string ToString()
        {
            return base.ToString() + $"Max Damage: {MaxDamage}\nMin Damage: {MinDamage}\nDescription: {Description}\n";
        }

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }

        public static Monster GetMonster()
        {
            //Create a variety of monsters
            Monster m1 = new(25, "White Rabbit", 50, 20, 8, 2, "That's no ordinary rabbit! Look at the bones!");
            Monster m2 = new(30, "Dracula", 70, 8, 8, 1, "Father of all the undead.");
            Monster m3 = new(25, "Mikey", 50, 10, 4, 1, "He is no longer a teenager, but he is still a mutant turtle.");
            Monster m4 = new(20, "Smaug", 65, 20, 15, 1, "The last great dragon.");
            //Add the monsters to a collection
            List<Monster> monsters = new()
            {
                m1,
                m2,m2,m2,m2, //4 times the chance of showing up
                m3,
                m4
            };
            //Pick one at random to place in our dungeon room
            return monsters[new Random().Next(monsters.Count)];
        }
    }
}
