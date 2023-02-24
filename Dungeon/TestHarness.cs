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
            Weapon w1 = new Weapon(20, 5, "Andúril", 30, true, WeaponType.Sword);

            //Build and test a character - include CalcBlock(), CalcHitChance(), CalcDamage()
            Player c1 = new Player(100, "Isildur", 10, 40, Race.Human, w1);

            Console.WriteLine($"{c1}Block Chance: {c1.CalcBlock()}%\n" +
                            $"Hit Chance: {c1.CalcHitChance()}%\n" +
                            $"Damage: {c1.CalcDamage()}\n");

            //Build and test a monster
            Monster m1 = new Monster(80, "Smaug", 20, 30, 40, 10, "Dragon!");
            Console.WriteLine(m1 + $"Damage Given: " + m1.CalcDamage());
        }
    }
}
