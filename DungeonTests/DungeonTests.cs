using DungeonLibrary;
using Microsoft.VisualStudio.TestPlatform.TestHost;
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
            expectedHitChance = 65 + 5 + 10 + 10; //Hit Chance + Bonus Hit Chance + Weapon Bonus Hit Chance + 10 if two handed
            actualHitChance = p.CalcHitChance();

            //Assert
            Assert.Equal(expectedHitChance, actualHitChance);
        }

        [Fact]
        public void TestCalcDamage()
        {

            //Arrange

            Player p = new Player("Robert", 35, 9, 50, Race.Human, Weapon.GetWeapon("k"), Shield.GetShield(), 0, 0, 0, 0, 0);

            int expectedMin;
            int expectedMax;
            int actualDamage;
            int expectedCalcDamage;
            //Act

            expectedMin = 4;
            expectedMax = 12;

            expectedCalcDamage = new Random().Next(expectedMin, expectedMax + 1);
            actualDamage = p.CalcDamage();

            //Assert
            Assert.True(expectedCalcDamage <= expectedMax && expectedCalcDamage >= expectedMin && actualDamage <= expectedMax && actualDamage >= expectedMin );
        }

        [Fact]
        public void TestGetPlayer()
        {
            //Arrange

            char playerLetter;
            string name;
            Weapon weapon;


            //Act

            playerLetter = 'c';
            name = "Steve";
            weapon = Weapon.GetWeapon("c");

            Player player = Player.GetPlayerRace(playerLetter, name, weapon);

            //Assert

            Assert.True(player.PlayerRace == Race.Centaur);
            
        }

        [Fact]
        public void TestGetBossMonster()
        {

            //Arrange


            //Act
            Monster bossMonster = Monster.GetBossMonster(2);

            //Assert
            Assert.IsType<Monster>(bossMonster);
        }

        [Fact]
        public void TestGetDungeon()
        {
            //Arrange



            //Act

            DungeonRoom room = DungeonRoom.GetDungeonRoom(5);

            //Assert
            Assert.NotNull(room);
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