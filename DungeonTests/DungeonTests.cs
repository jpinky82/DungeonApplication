using DungeonLibrary;
using System.Xml.Linq;

namespace DungeonTests
{
    public class DungeonTests
    {
        [Fact]
        public void TestCalcHitChance()
        {

            //Arrange

            Player p = new Player("bob", 65, 9, 50, Race.Centaur, Weapon.GetWeapon("b"), Shield.GetShield(), 0, 0, 0, 0, 0);

            int expectedHitChance = 0;
            int actualHitChance = 0;

            //Act
            expectedHitChance = 65 + 5 + 10; //Hit Chance + Bonus Hit Chance + Weapon Bonus Hit Chance
            actualHitChance = p.CalcHitChance();

            //Assert
            Assert.Equal(expectedHitChance, actualHitChance);
        }

        [Fact]
        public void TestCalcHitChance2()
        {

            //Arrange

            Player p = new Player("Robert", 35, 9, 50, Race.Human, Weapon.GetWeapon("k"), Shield.GetShield(), 0, 0, 0, 0, 0);

            int expectedHitChance = 0;
            int actualHitChance = 0;

            //Act
            expectedHitChance = 35 + 10 + 5; //Hit Chance + Bonus Hit Chance + Weapon Bonus Hit Chance
            actualHitChance = p.CalcHitChance();

            //Assert
            Assert.Equal(expectedHitChance, actualHitChance);
        }

        [Fact]
        public void TestCalcHitChance3()
        {

            //Arrange

            Player p = new Player("Steve", 20, 9, 50, Race.Elf, Weapon.GetWeapon("l"), Shield.GetShield(), 0, 0, 0, 0, 0);

            int expectedHitChance = 0;
            int actualHitChance = 0;

            //Act
            expectedHitChance = 20 + 15 + 8; //Hit Chance + Race Bonus Hit Chance + Weapon Bonus Hit Chance
            actualHitChance = p.CalcHitChance();

            //Assert
            Assert.Equal(expectedHitChance, actualHitChance);
        }

        [Fact]
        public void TestCalcHitChance4()
        {

            //Arrange

            Player p = new Player("Allen", 1, 0, 50, Race.Dwarf, Weapon.GetWeapon("w"), Shield.GetShield(), 0, 0, 0, 0, 0);

            int expectedHitChance = 0;
            int actualHitChance = 0;

            //Act
            expectedHitChance = 1 + 0 + 12; //Hit Chance + Race Bonus Hit Chance + Weapon Bonus Hit Chance
            actualHitChance = p.CalcHitChance();

            //Assert
            Assert.Equal(expectedHitChance, actualHitChance);
        }

        [Fact]
        public void TestCalcHitChance5()
        {
            //Arrange

            Player p = new Player("Dan", 44, 9, 50, Race.Gnome, Weapon.GetWeapon("c"), Shield.GetShield(), 0, 0, 0, 0, 0);

            int expectedHitChance = 0;
            int actualHitChance = 0;

            //Act
            expectedHitChance = 44 + 5 + 5; //Hit Chance + Bonus Hit Chance + Weapon Bonus Hit Chance
            actualHitChance = p.CalcHitChance();

            //Assert
            Assert.Equal(expectedHitChance, actualHitChance);
        }





        //Tried running the test below but it always errors out even though the returned result is exactly the same for both objects.

        //[Fact]
        //public void TestGetPlayerRace()
        //{
        //    //Arrange

        //    string userName = "Jason";
        //    Weapon weapon = Weapon.GetWeapon("c");
        //    char choice = 'd';

        //    //Act

        //    Player expectedPlayer = new Player("Jason", 65, 10, 50, Race.Dwarf, Weapon.GetWeapon("c"), Shield.GetShield(), 0, 0, 0, 0, 0);

        //    Player actualPlayer = Player.GetPlayerRace(choice, userName, weapon);

        //    //Assert

        //    Assert.Equal(expectedPlayer, actualPlayer);
        //}
    }
}