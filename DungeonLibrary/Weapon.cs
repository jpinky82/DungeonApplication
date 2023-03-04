using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //Make it public!
    public class Weapon : InventoryItem
    {
        //Fields
        /*
         * int for min damage (cannot be less than 0 or > max
         * int for max damage (cannot be less than 0) - assign first in your ctor
         * string for the name
         * int for bonusHitChance
         * bool isTwoHanded
         */

        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;

        //Props
            
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value < 0 ?  0 : value; }
        }
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value > MaxDamage ? MaxDamage : value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value = true; }
        }


        //CTORS/Constructors
        //1 fq ctor, and 1 unqualified ctor if you want Object Initialization Syntax

        //Unqualified ctor

        //fully qualified
        public Weapon(Inventory item, int maxDamage, int minDamage, string name, int bonusHitChance, bool isTwoHanded) : base(item)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
        }


        //Methods
        //Nicely formatted ToString() override
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Min Damage: {MinDamage}\n" +
                   $"Max Damage: {MaxDamage}\n" +
                   $"Bonus Hit Chance: {BonusHitChance}%\n" +
                   $"Two Handed?: {(IsTwoHanded ? "Yes" : "No")}\n";
        }
        public static Weapon GetWeapon(string choice)
        {
            switch (choice)
            {
                case "l":
                    return new (Inventory.Sword, 8, 1, "Long Sword", 8, true);

                case "b":
                    return new(Inventory.Bow_Arrow,10, 1, "Bow & Arrow", 10, true);

                case "w":
                    return new(Inventory.War_Hammer, 8, 1, "War Hammer", 12, false);

                case "c":
                    return new(Inventory.Crossbow, 12, 1, "Crossbow", 5, true);

                case "k":
                    return new(Inventory.Katana, 12, 4, "Katana", 5, false);

                case "s":
                    return new(Inventory.Spear, 12, 4, "Spear", 5, true);

                default:
                    return new(Inventory.Sword, 8, 1, "Long Sword", 8, true);//default weapon will be sword

            }
        }
    }
}
