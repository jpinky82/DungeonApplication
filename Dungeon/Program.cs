using DungeonLibrary;
using System.ComponentModel;
using System.Numerics;

namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Opening Menu

            #region Dragon pic
            Console.Title = "DUNGEON OF DOOM!";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
                               <xeee..
                           ueeeeeu..^""*$e.
                    ur d$$$$$$$$$$$$$$Nu ""*Nu
                  d$$$ ""$$$$$$$$$$$$$$$$$$e.""$c
              u$$c   """"   ^""^**$$$$$$$$$$$$$b.^R:
            z$$#""""""           `!?$$$$$$$$$$$$$N.^
          .$P                   ~!R$$$$$$$$$$$$$b
         x$F                 **$b. '""R).$$$$$$$$$$
        J^""                           #$$$$$$$$$$$$.
       z$e                      ..      ""**$$$$$$$$$
      :$P           .        .$$$$$b.    ..  ""  #$$$$
      $$            L          ^*$$$$b   ""      4$$$$L
     4$$            ^u    .e$$$$e.""*$$$N.       @$$$$$
     $$E            d$$$$$$$$$$$$$$L ""$$$$$  mu $$$$$$F
     $$&            $$$$$$$$$$$$$$$$N   ""#* * ?$$$$$$$N
     $$F            '$$$$$$$$$$$$$$$$$bec...z$ $$$$$$$$
     $$F             `$$$$$$$$$$$$$$$$$$$$$$$$ '$$$$E""$
     $$                  ^""""""""""""`       ^""*$$$& 9$$$$N
     k  u$                                  ""$$. ""$$P r
     4$$$$L                                   ""$. eeeR
      $$$$$k                                   '$e. .@
      3$$$$$b                                   '$$$$
       $$$$$$                                    3$$""
        $$$$$  dc                                4$F
         RF** <$$                                J""
          #bue$$$LJ$$$Nc.                        ""
           ^$$$$$$$$$$$$$r
             `""*$$$$$$$$$
");
            #endregion
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Welcome to the Dungeon Game!\t\tPress any key to continue.");
            Console.ReadKey();

            Console.Clear();
            //TODO get ascii text for "Name your Character

            #region Main Menu and Player Creation

            Console.Write("Please give your character a name: ");
            string userName = Console.ReadLine().ToString();


            Console.Clear();
            //TODO get ascii art text for this menu "Please Select a Race"


            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n" +
            "L) Long Sword\n" +
            "B) Bow & Arrow\n" +
            "W) War Hammer\n" +
            "C) Crossbow\n" +
            "K) Katana\n" +
            "S) Spear\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Please choose a weapon for your Character: ");

            ConsoleKey wepChoice = Console.ReadKey(true).Key;

            Weapon userWeapon = new Weapon(8, 3, "Long Sword", 10, true, WeaponType.Sword);//default weapon

            switch (wepChoice)
            {
                case ConsoleKey.L:
                    userWeapon.MaxDamage = 8;
                    userWeapon.MinDamage = 3;
                    userWeapon.Name = "Long Sword";
                    userWeapon.BonusHitChance = 8;
                    userWeapon.IsTwoHanded = true;
                    userWeapon.WeaponType = WeaponType.Sword;
                    break;
                case ConsoleKey.B:
                    userWeapon.MaxDamage = 10;
                    userWeapon.MinDamage = 1;
                    userWeapon.Name = "Bow & Arrow";
                    userWeapon.BonusHitChance = 10;
                    userWeapon.IsTwoHanded = true;
                    userWeapon.WeaponType = WeaponType.Bow_Arrow;
                    break;
                case ConsoleKey.W:
                    userWeapon.MaxDamage = 8;
                    userWeapon.MinDamage = 1;
                    userWeapon.Name = "War Hammer";
                    userWeapon.BonusHitChance = 12;
                    userWeapon.IsTwoHanded = false;
                    userWeapon.WeaponType = WeaponType.War_Hammer;
                    break;
                case ConsoleKey.C:
                    userWeapon.MaxDamage = 12;
                    userWeapon.MinDamage = 1;
                    userWeapon.Name = "Crossbow";
                    userWeapon.BonusHitChance = 5;
                    userWeapon.IsTwoHanded = true;
                    userWeapon.WeaponType = WeaponType.Crossbow;
                    break;
                case ConsoleKey.K:
                    userWeapon.MaxDamage = 12;
                    userWeapon.MinDamage = 4;
                    userWeapon.Name = "Katana";
                    userWeapon.BonusHitChance = 5;
                    userWeapon.IsTwoHanded = false;
                    userWeapon.WeaponType = WeaponType.Katana;
                    break;
                case ConsoleKey.S:
                    userWeapon.MaxDamage = 12;
                    userWeapon.MinDamage = 4;
                    userWeapon.Name = "Spear";
                    userWeapon.BonusHitChance = 5;
                    userWeapon.IsTwoHanded = true;
                    userWeapon.WeaponType = WeaponType.Spear;
                    break;
            }

            if (userWeapon.IsTwoHanded)
            {
                userWeapon.BonusHitChance += 10;
            }

            Console.Clear();
            //TODO Ascii art for "Select your race"

            Console.Write("\n" +
            "C) Centaur\n" +
            "H) Human\n" +
            "E) Elf\n" +
            "D) Dwarf\n" +
            "G) Gnome\n\n" +
            "Please select a race for your Character:");

            
            Player userPlayer = new(userName, 70, 5, 40, Race.Human, userWeapon);

            ConsoleKey raceChoice = Console.ReadKey(true).Key;
            Console.Clear();
            switch (raceChoice)
            {
                case ConsoleKey.C:
                    userPlayer.HitChance = 65;
                    userPlayer.Block = 9;
                    userPlayer.MaxLife = 50;
                    userPlayer.PlayerRace = Race.Centaur;
                    break;
                case ConsoleKey.H:
                    userPlayer.HitChance = 70;
                    userPlayer.Block = 5;
                    userPlayer.MaxLife = 40;
                    userPlayer.PlayerRace = Race.Human;
                    break;
                case ConsoleKey.E:
                    userPlayer.HitChance = 75;
                    userPlayer.Block = 7;
                    userPlayer.MaxLife = 38;
                    userPlayer.PlayerRace = Race.Elf;
                    break;
                case ConsoleKey.D:
                    userPlayer.HitChance = 65;
                    userPlayer.Block = 10;
                    userPlayer.MaxLife = 50;
                    userPlayer.PlayerRace = Race.Dwarf;
                    break;
                case ConsoleKey.G:
                    userPlayer.HitChance = 68;
                    userPlayer.Block = 5;
                    userPlayer.MaxLife = 30;
                    userPlayer.PlayerRace = Race.Gnome;
                    break;
            }
            #endregion

            #region Story Intro
            Console.Clear();
            Console.WriteLine("In a far off land known as LandyMcLandia there was the small town of TownyMcTowntown. Both of which were named after an overwhelming, and unfortunate, youth turnout in the Great Renaming Vote of 1272....You can still hear the elders in the saloon going on and on about the disaster....Anyway...\n\nLandyMcLandia is a magical land full of a variety of different species. They all, somehow, speak the same language and get along fairly well despite the occasional grievance. On the outskirts of town lived an extremely wealthy scientist, Dr. Agon.  He kept to himself mostly but had been seen in the town on occassion gathering strange supplies for an experiment.\n\nThe rumors about Dr. Agon experimenting on other animals started 2 years ago. Public opinion swayed drastically against the doctor at that point and, after being openly pressed on the matter by the Mayor, he wasn't seen in town again.\n\n8 months ago, a group of teenagers wondered onto the property. In front of what looks like some kind of dungeon door that leads underground, they found the body of Dr.Agon with a puncture wound through the abdomin. After 2 officers of the peace entered the dungeon and never came out, Mayor Amy Stake has decided to put a call out to all the land.\n\nTo anyone willing to enter the dugeon on the Dr. Agon estate, anything of financial significance on the property will be yours as long as what lies inside is destroyed. The citizens of TownyMcTowntown deserve to feel safe in their homes, WE NEED A HERO!\n\n");
            Console.WriteLine($"{userName}...YOU...ARE...THAT...HERO!");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            #endregion


            //Possible Expansion - Display a list of pre-created weapons and let them pick one.
            //or. pick one for them randomly.
            //Weapon sword = new Weapon(8, 1, "Long Sword", 10, true, WeaponType.Sword);

            //Potential Expansion - Allow them to enter theri own name.
            //show the mall the possible races and let them pick one.


            //Variable to keeps score and bool to exit dowhile loop
            int score = 0;
            bool exit = false;

            do
            {
                //Console.WriteLine("Outer: " + ++outerCount);
                //Generate a random room

                //Select a random monster to inhabit the room
                Monster monster = Monster.GetMonster();
                Console.WriteLine($"In this room {monster.Name}!");
                
                #region Gameplay Menu Loop
                bool reload = false;
                do
                {
                    //Console.WriteLine("Inner: " + ++innerCount);
                    //Gameplay Menu
                    #region Menu
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");

                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            //Combat
                            //Potential Expansion : weapon/race bonus attack
                            //if race == darkelf -> player.DoAttack(monster)
                            Combat.DoBattle(userPlayer, monster);
                            //check if the monster is dead
                            if (monster.Life <= 0)
                            {
                                //Combat rewards -> money, health, whatever
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nYou killed {monster.Name}!");
                                Console.ResetColor();
                                //flip the inner-loop bool to true
                                reload = true;

                                score++;
                            }
                            break;

                        case ConsoleKey.R:
                            //TODO Attack of Opportunity
                            Console.WriteLine("Run away!!");
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, userPlayer);
                            Console.WriteLine();//formatting
                            reload = true;//new room, new monster
                            break;

                        case ConsoleKey.P:
                            //Player info
                            Console.WriteLine("Player Info: ");
                            Console.WriteLine(userPlayer);
                            break;

                        case ConsoleKey.M:
                            //Monster info
                            Console.WriteLine("Monster info: ");
                            Console.WriteLine(monster);
                            break;

                        case ConsoleKey.X:
                        case ConsoleKey.E:
                        case ConsoleKey.Escape:
                            Console.WriteLine("No one likes a quitter...");
                            exit = true;
                            //reload = true;
                            break;
                        default:
                            break;
                    }//end switch
                    #endregion
                    //TODO Check player life
                    if (userPlayer.Life <= 0)
                    {
                        Console.WriteLine("Dude...you died!\a");
                        exit = true;
                    }

                } while (!reload && !exit); //if either exit or reload is true, the inner loop will exit.
                #endregion
            } while (!exit);//if exit is true, the outer loop willl exit as well.

            //Show the score
            Console.WriteLine("You defeated " + score + " monster" + (score == 1 ? "." : "s."));

            #endregion
        }//end Main()

        private static string GetRoom()
        {
            string[] rooms =
            {
                "1", "2", "3", "4", "5"
            };

            //Random rand = new Random();

            //int index = rand.Next(rooms.Length);

            //string room = rooms[index];

            //return room;

            //refactor from commented code above
            return rooms[new Random().Next(rooms.Length)];

        }//end GetRoom()

    }//end class
}//end namespace