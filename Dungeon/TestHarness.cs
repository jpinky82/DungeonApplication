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

            Console.WriteLine("\n\n********************************* PLAYER *********************************\n");

            //Build and test a character - include CalcBlock(), CalcHitChance(), CalcDamage()
            Player c1 = new Player("Isildur", 100, 10, 40, Race.Human, w1);

            Console.WriteLine($"{c1}Block Chance: {c1.CalcBlock()}%\n" +
                            $"Hit Chance: {c1.CalcHitChance()}%\n" +
                            $"Damage: {c1.CalcDamage()}\n");

            Console.WriteLine("\n\n********************************* MONSTER *********************************\n");

            //Call up a Monster
            Console.WriteLine(Monster.GetMonster());
            Monster monster = Monster.GetMonster();

            Console.WriteLine("\n\n********************************* COMBAT *********************************\n");
            Combat.DoBattle(c1, monster);

            Console.ReadLine();
        }
    }
}
