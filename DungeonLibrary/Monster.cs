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
        private int _maxDamage;
        private string _description;

        //Props

        public int MaxDamage 
        {   get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public int MinDamage
        { 
            get { return _minDamage;} 
            set { _minDamage = value > MaxDamage ? MaxDamage : value; } 
        }
        public string Description 
        {   get { return _description; }
            set { _description = value; }
        }

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
            Random rando = new Random();
            int monstDamage = rando.Next(MinDamage, MaxDamage + 1);
            return monstDamage;
        }
    }
}
