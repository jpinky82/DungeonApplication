using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {

        //Fields

        //Props
        string description = "";
        public Race PlayerRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Shield PlayerShield { get; set; }
        public int Gold { get; set; }
        public byte Potions { get; set; }
        public byte Score { get; set; }
        public byte RedKey { get; set; }
        public byte GreenKey { get; set; }


        //CTORS/Construstors

        public Player(string name, int hitChance, int block, int maxLife, Race playerRace, Weapon equippedWeapon, Shield playerShield,int gold, byte potions, byte score, byte redKey, byte greenKey) : base(name, hitChance, block, maxLife)
        {
            
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;
            Gold = gold;
            PlayerShield = playerShield;
            Potions = potions;
            Score = score;
            RedKey = redKey;
            GreenKey = greenKey;

            #region Race Bonuses
            switch (PlayerRace)
            {
                case Race.Centaur:
                    HitChance += 5;
                    description = "This four legged hybrid is fast but not the most agile in close quarter combat.";
                    break;
                case Race.Human:
                    HitChance += 10;
                    description = "Humans are cunning, brave creatures.";
                    break;
                case Race.Elf:
                    HitChance += 15;
                    description = "Elves are fast and agile which makes them a great choice in battle.";
                    break;
                case Race.Dwarf:
                    description = "Dwarves are slow but make up for it with power!";
                    break;
                case Race.Gnome:
                    HitChance += 5;
                    description = "Gnomes aren't the happiest of creatures but they'll fight tooth and nail when their life is on the line!";
                    break;
            }
            #endregion
        }

        //Methods
    
        public override string ToString()
        {
            //create a string, switch on Player Race and
            //write some description about that race
            
            return $"Race: {PlayerRace}\n{base.ToString()}\n{description}\n{PlayerShield}\nCurrent Score: {Score}\n\nWeapon Info:\n{EquippedWeapon}";

        }
        public override int CalcDamage()
        {
            //Create a Random object
            Random rand = new Random();
            //determine the damage
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            //return the damage
            return damage;
        }

        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }

        public static Player GetPlayerRace(char uChoice, string name, Weapon userWeapon)
        {
            switch (uChoice)
            {
                case 'c':
                    return new(name, 65, 9, 50, Race.Centaur, userWeapon, Shield.GetShield(), 0, 0, 0,0,0);
                case 'h':
                    return new(name, 70, 5, 40, Race.Human, userWeapon, Shield.GetShield(), 0, 0, 0,0,0);
                case 'e':
                    return new(name, 75, 7, 40, Race.Elf, userWeapon, Shield.GetShield(), 0, 0, 0,0,0);
                case 'd':
                    return new(name, 65, 10, 50, Race.Dwarf, userWeapon, Shield.GetShield(), 0, 0, 0,0,0);
                case 'g':
                    return new(name, 60, 5, 30, Race.Gnome, userWeapon, Shield.GetShield(), 0, 0, 0,0,0);
                default:
                    return new(name, 70, 5, 40, Race.Human, userWeapon, Shield.GetShield(), 0, 0, 0,0,0);
            }
        }
    }
}
