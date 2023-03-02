﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //Make it public!
    public class Weapon
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
        private WeaponType _type;

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
        public WeaponType WeaponType
        {
            get { return _type; }
            set { _type = value; }
        }

        //CTORS/Constructors
        //1 fq ctor, and 1 unqualified ctor if you want Object Initialization Syntax

        //Unqualified ctor
        public Weapon() { }

        //fully qualified
        public Weapon(int maxDamage, int minDamage, string name, int bonusHitChance, bool isTwoHanded, WeaponType type)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
            WeaponType = type;
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
                    return new (8, 1, "Long Sword", 8, true, WeaponType.Sword);

                case "b":
                    return new(10, 1, "Bow & Arrow", 10, true, WeaponType.Bow_Arrow);

                case "w":
                    return new(8, 1, "War Hammer", 12, false, WeaponType.War_Hammer);

                case "c":
                    return new(12, 1, "Crossbow", 5, true, WeaponType.Crossbow);

                case "k":
                    return new(12, 4, "Katana", 5, false, WeaponType.Katana);

                case "s":
                    return new(12, 4, "Spear", 5, true, WeaponType.Spear);

                default:
                    return new(8, 1, "Long Sword", 8, true, WeaponType.Sword);//default weapon will be sword

            }
        }
    }
}
