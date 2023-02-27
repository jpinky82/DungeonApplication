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

        //CTORS/Construstors
        public Player(string name, int hitChance, int block, int maxLife, Race playerRace, Weapon equippedWeapon) : base(name, hitChance, block, maxLife)
        {
            
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;

            #region Potential Expansion - Racial Bonuses
            switch (PlayerRace)
            {
                case Race.Centaur:
                    HitChance += 10;
                    description = "This four legged hybrid is fast and agile.";
                    break;
                case Race.Human:
                    HitChance += 5;
                    description = "Humans are cunning, brave creatures.";
                    break;
                case Race.Elf:
                    HitChance += 15;
                    description = "You're usually dead before you ever see one";
                    break;
                case Race.Dwarf:
                    description = "Dwarves are slow but make up for it with power!";
                    break;
                case Race.Gnome:
                    HitChance += 5;
                    description = "Dwarves aren't the happiest of creatures but they'll fight tooth and nail when their life is on the line!";
                    break;
            }
            #endregion

        }


        //Methods

        
        public override string ToString()
        {
            //create a string, switch on Player Race and
            //write some description about that race
            
            return $"Race: {PlayerRace}\n{base.ToString()}\n{description}\n\nWeapon: {EquippedWeapon}";
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
    }
}
