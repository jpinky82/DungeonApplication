using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace Dungeon
{
    internal class TestHarness
    {
        static void Main(string[] args)
        {
            //Build and test the functionality of our Library
            
            //Build and test a weapon
            Weapon longSword = new Weapon()
            {
                Name = "Andúril",
                MaxDamage = 20,
                MinDamage = 5,
                BonusHitChance = 30,
                IsTwoHanded = true
            };
            Console.WriteLine(longSword);

            //Build and test a character - include CalcBlock(), CalcHitChance(), CalcDamage()
            Character isildur = new Character()
            {
                Name = "Isildur",
                Life = 80,
                MaxLife = 100,
                HitChance = 10,
                Block = 40,
            };
            Console.WriteLine($"{isildur}\n\n" +
                            $"Block Chance: {Character.CalcBlock(isildur.Block)}\n" +
                            $"Hit Chance: {Character.CalcHitChance(isildur.HitChance)}\n" +
                            $"Damage: {Character.CalcDamage(0)}");
        }
    }
}
