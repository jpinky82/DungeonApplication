using DungeonLibrary;
using System;
using System.ComponentModel;
using System.Numerics;

namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Opening Welcome Screen

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
            Console.Write("Please choose a weapon for your Weapon: ");

            Weapon userWeapon = Weapon.GetWeapon(Console.ReadLine());


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

            char rChoice = Console.ReadLine().ToLower()[0];

            Player userPlayer = Player.GetPlayerRace(rChoice, userName, userWeapon);

            #endregion

            #region Story Intro
            Console.Clear();
            Console.WriteLine("In a far off land known as LandyMcLandia there was the small town of TownyMcTowntown. Both of which were named after an overwhelming, and unfortunate, youth turnout in the Great Renaming Vote of 1272....You can still hear the elders in the saloon going on and on about the disaster....Anyway...\n\nLandyMcLandia is a magical land full of a variety of different species. They all, somehow, speak the same language and get along fairly well despite the occasional grievance. On the outskirts of town lived an extremely wealthy scientist, Dr. Agon.  He kept to himself mostly but had been seen in the town on occassion gathering strange supplies for an experiment.\n\nThe rumors about Dr. Agon experimenting on other animals started 2 years ago. Public opinion swayed drastically against the doctor at that point and, after being openly pressed on the matter by the Mayor, he wasn't seen in town again.\n\nA little over a month ago, a group of teenagers wondered on to the property. In front of what looks like some kind of dungeon door that leads underground, they found the body of Dr.Agon with a puncture wound through the abdomin. After 2 officers of The Peace entered the dungeon and never came out, Mayor Amy Stake has decided to put a call out to all the land.\n\nTo anyone willing to enter the dugeon on the Dr. Agon estate, anything of financial significance on the property will be yours as long as what lies inside is destroyed. The citizens of TownyMcTowntown deserve to feel safe in their homes, WE NEED A HERO!\n\n");
            Console.WriteLine($"{userName}...YOU...ARE...THAT...HERO!");
            Console.Write("\nPress any key to continue. ");
            Console.ReadKey();
            Console.Clear();
            #endregion

            //TODO Move storyline to string and iterate through with for loop and add delay for typwriter effect Thread.Sleep(milliseconds) if character = "." add extra time.
            ////TODO Try Console.BufferWidth Property to fix the word wrap issue.  May not work with the for loop above. 


            Console.WriteLine($"Shortly after arriving in TownyMcTowntown, the Mayor wastes no time and leads you to the dungeon door.  She pats you on the back and exclaims, \"Good Luck!!\" and swiftly scurries off.  You open the door, pull out your {userWeapon.Name}, walk through the entrance.\n");


            //Pre-Loading Dungeon Rooms
            DungeonRoom room1 = DungeonRoom.GetDungeonRoom(1);
            DungeonRoom room2 = DungeonRoom.GetDungeonRoom(2);
            DungeonRoom room3 = DungeonRoom.GetDungeonRoom(3);
            DungeonRoom room4 = DungeonRoom.GetDungeonRoom(4);
            DungeonRoom room5 = DungeonRoom.GetDungeonRoom(5);
            DungeonRoom room6 = DungeonRoom.GetDungeonRoom(6);
            DungeonRoom room7 = DungeonRoom.GetDungeonRoom(7);
            DungeonRoom room8 = DungeonRoom.GetDungeonRoom(8);

            //Pre-Loading the first Boss Monster
            Monster monster = Monster.GetBossMonster(1);


            //Variable to keeps score and bool to exit dowhile loop
            bool exit = false;
            byte currentLevel = 1;
            bool levelSelectExit = false;
            do
            {

                //Generate first Monster (for scope)


                //Room switch DoWhile
                do
                {
                    //There are 8 rooms in this dungeon.  Players have the ability to move back and forth between rooms
                    switch (currentLevel)
                    {
                        //Each Room has a switch of it's own so each time they come back, it will be the same as they left it.
                        case 1:
                            switch (room1.NumOfVisits)
                            {
                                case 1:
                                    Console.WriteLine(room1.NotVisitedMessage);
                                    levelSelectExit = true;
                                    room1.NumOfVisits++;
                                    monster = Monster.GetBossMonster(1);
                                    break;

                                case 2:
                                    userPlayer.PlayerShield.Count++;
                                    userPlayer.Potions++;
                                    userPlayer.Gold += 600;
                                    room1.NumOfVisits++;

                                    Console.Clear();
                                    Console.WriteLine("You stand over the dead spider terrified at what just happened.  You turn to walk out the door but then see the treasure on the back wall of the room. The desire to leave instantly vanishes as you investigate and realized you just picked up a Healing Potion, Shield, and 600 gold coins!\n\n");

                                    Console.Write("As you're looking at the back wall, you have noticed there are 2 doors on your left and right.\n\n" +
                                                  "Which door do you choose? (L/R)");
                                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                                    if (userChoice == ConsoleKey.R)
                                    {
                                        currentLevel = 3;
                                        Console.WriteLine("You open the door to the right and walk through.");
                                    }
                                    else
                                    {
                                        currentLevel = 2;
                                        Console.WriteLine("You open the door to the left and walk through.");
                                    }
                                    break;

                                case >= 3:
                                    if(room1.NumOfVisits % 2 != 0)
                                    {
                                        room1.NumOfVisits++;
                                        Console.WriteLine(room1.HasVisitedMessage);
                                        Console.WriteLine("\nYou hear something coming towards you!\n");
                                        monster = Monster.GetBabyMonster();
                                        levelSelectExit = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"After quickly disposing of {monster.Name}, you look around at your exits\nAgain looking at the back wall, you can exit the dungeon by turning around and walking out the door behind or there's a door to your left and one to your right.");
                                        Console.Write("Which direction do you choose?  (E)xit, (L)eft, or (R)ight");
                                        ConsoleKey userRm1Choice = Console.ReadKey(true).Key;
                                        if (userRm1Choice == ConsoleKey.R)
                                        {
                                            currentLevel = 3;
                                            Console.WriteLine("You open the door to the right and walk through.");
                                        }
                                        else if(userRm1Choice == ConsoleKey.L)
                                        {
                                            currentLevel = 2;
                                            Console.WriteLine("You open the door to the left and walk through.");
                                        }
                                        else
                                        {
                                            levelSelectExit = true;
                                            exit = true;//TODO NEED TO TURN GAMEPLAY MENU LOOP INTO WHILE LOOP BASED ON WHETHER EXIT IS FALSE.
                                        }
                                        break;

                                    }
                                    break;
                            
                            }//end Level 1 Switch
                            break;
                    }//end Level Switch
                } while (!levelSelectExit);
                levelSelectExit = false;
                
               
                
                




                //Select a random monster to inhabit the room
                //Monster monster = Monster.GetBabyMonster();
                

                

                Console.WriteLine($"In the back corner of the room you hear a loud high pitched voice say, \"My name is {monster.Name}, who are you?\"");
                
                #region Gameplay Menu Loop
                bool reload = false;
                do
                {
                    
                    //Gameplay Menu
                    #region Menu
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run away\n" +
                        "P) Player Info\n" +
                        "I) Inventory\n" +
                        "M) Monster Info\n" +
                        "E) Exit\n");

                    Console.WriteLine($"{userName}'s Health: {userPlayer.Life} of {userPlayer.MaxLife}  " +
                                      $"{monster.Name}'s Health: {monster.Life} of {monster.MaxLife}");

                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            //Combat
                            //Potential Expansion : weapon/race bonus attack
                            //if race == darkelf -> player.DoAttack(monster)
                            Combat.DoBattle(userPlayer, userPlayer.PlayerShield.ShieldActive, monster);
                            //check if the monster is dead
                            if (monster.Life <= 0)
                            {
                                //Combat rewards -> money, health, whatever
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nYou killed {monster.Name}!");
                                Console.ResetColor();
                                //flip the inner-loop bool to true
                                reload = true;

                                userPlayer.Score++;
                            }

                            if (userPlayer.PlayerShield.ShieldActive && userPlayer.PlayerShield.AttacksGiven == 9)
                            {
                                userPlayer.PlayerShield.AttacksGiven = 0;
                                userPlayer.PlayerShield.Count--;
                                userPlayer.PlayerShield.ShieldActive = false;

                            }else if (userPlayer.PlayerShield.ShieldActive)
                             {
                                userPlayer.PlayerShield.AttacksGiven++;
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

                        case ConsoleKey.I:
                            //Inventory
                            bool exitInventory = false;
                            do
                            {
                                Console.Clear();
                                Console.Write("****** INVENTORY ******\n" +
                                "L) Long Sword\n" +
                                "B) Bow & Arrow\n" +
                                "W) War Hammer\n" +
                                "C) Crossbow\n" +
                                "K) Katana\n" +
                                "S) Spear\n" +
                                "H) Healing Potion\n" +
                                "D) Shield\n" +
                                "E) Exit Inventory\n");
                                Console.Write("Please choose an item from your inventory: ");

                                ConsoleKey inventoryChoice = Console.ReadKey(true).Key;
                                switch (inventoryChoice)
                                {
                                    case ConsoleKey.L:
                                        userPlayer.EquippedWeapon = Weapon.GetWeapon("l");
                                        Console.Clear();
                                        #region Long Sword Change
                                        Console.WriteLine(@"

*****************************************************
*                                                   *
*  Equipped Weapon has been changed to Long Sword!  *          
*                                                   *
*****************************************************

");
                                        Console.Write("Press any key to Continue");
                                        Console.ReadKey();
                                        #endregion
                                        break;

                                    case ConsoleKey.B:
                                        userPlayer.EquippedWeapon = Weapon.GetWeapon("b");
                                        Console.Clear();
                                        #region Bow & Arrow Change
                                        Console.WriteLine(@"

******************************************************
*                                                    *
*  Equipped Weapon has been changed to Bow & Arrow!  *          
*                                                    *
******************************************************

");
                                        Console.Write("Press any key to Continue");
                                        Console.ReadKey();
                                        #endregion
                                        break;

                                    case ConsoleKey.W:
                                        userPlayer.EquippedWeapon = Weapon.GetWeapon("w");
                                        Console.Clear();
                                        #region War Hammer
                                        Console.WriteLine(@"

*****************************************************
*                                                   *
*  Equipped Weapon has been changed to War Hammer!  *          
*                                                   *
*****************************************************

");
                                        Console.Write("Press any key to Continue");
                                        Console.ReadKey();
                                        #endregion
                                        break;

                                    case ConsoleKey.C:
                                        userPlayer.EquippedWeapon = Weapon.GetWeapon("c");
                                        Console.Clear();
                                        #region Crossbow Change
                                        Console.WriteLine(@"

*****************************************************
*                                                   *
*   Equipped Weapon has been changed to Crossbow!   *          
*                                                   *
*****************************************************

");
                                        Console.Write("Press any key to Continue");
                                        Console.ReadKey();
                                        #endregion
                                        break;

                                    case ConsoleKey.K:
                                        userPlayer.EquippedWeapon = Weapon.GetWeapon("k");
                                        Console.Clear();
                                        #region Katana Change
                                        Console.WriteLine(@"

*****************************************************
*                                                   *
*    Equipped Weapon has been changed to Katana!    *          
*                                                   *
*****************************************************

");
                                        Console.Write("Press any key to Continue");
                                        Console.ReadKey();
                                        #endregion
                                        break;

                                    case ConsoleKey.S:
                                        userPlayer.EquippedWeapon = Weapon.GetWeapon("s");
                                        Console.Clear();
                                        #region Spear Change
                                        Console.WriteLine(@"

*****************************************************
*                                                   *
*    Equipped Weapon has been changed to Spear!     *          
*                                                   *
*****************************************************

");
                                        Console.Write("Press any key to Continue");
                                        Console.ReadKey();
                                        #endregion
                                        break;

                                    case ConsoleKey.H:
                                        Console.Clear();
                                        #region Healing Potions Menu
                                        Console.WriteLine(@"
*****************************************************
*                                                   *
*                 Healing Potions!                  *          
*                                                   *
*****************************************************
");
                                        Console.WriteLine($"Current Healing Potion Count: {userPlayer.Potions}");
                                        Console.WriteLine($"Current Health: {userPlayer.Life} of {userPlayer.MaxLife}\n\n");
                                        if (userPlayer.Potions == 0)
                                        {
                                            Console.WriteLine("Sorry but you don't have any Healing Potions\n");
                                        }
                                        else if (userPlayer.Life == userPlayer.MaxLife)
                                        {
                                            Console.WriteLine("You're health is already at it's Maximum Level, you don't need a Healing Potion.\nGet out there and Fight!\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"You currently have {userPlayer.Potions} Healing Potion" + (userPlayer.Potions == 1 ? "." : "s.\n"));
                                            Console.WriteLine("Each Healing Potion will fully regenerate your health!\n");
                                            Console.Write("Would you like to use one? Y/N :");
                                            ConsoleKey potionChoice = Console.ReadKey(true).Key;
                                            
                                            if (potionChoice == ConsoleKey.Y)
                                            {
                                                userPlayer.Life = userPlayer.MaxLife;
                                                userPlayer.Potions--;

                                                Console.WriteLine($"\n\nYou're Health is now {userPlayer.Life} of {userPlayer.MaxLife}\n" +
                                                    $"You have {userPlayer.Potions} Healing Potion" + (userPlayer.Potions == 1 ? " " : "s ") + "remaining.\n\n");
                                            }
                                        }
                                        Console.Write("\nPress any key to Continue");
                                        Console.ReadKey();
                                        #endregion
                                        break;
                                    case ConsoleKey.D:
                                        Console.Clear();
                                        #region Shields Menu
                                        Console.WriteLine(@"
*****************************************************
*                                                   *
*                     Shields!                      *          
*                                                   *
*****************************************************
");
                                        Console.WriteLine(userPlayer.PlayerShield);
                                        Console.WriteLine(@"

***************************************************************
*                                                             *
*   Once a shield is enabled, it can withstand 10 attacks!    *
*   Once a shield is exhausted,                               *
*       1) Your shield protection will end.                   *
*       2) The 'Total Number of Shields' will reduce by 1.    *
*                                                             *
*   The 'Attacks left on Current Shield' will always show     * 
*   how many attacks are left on the current Shield until     *
*   all Shields are exhausted.                                *
*                                                             *
***************************************************************
");
                                        if (userPlayer.PlayerShield.Count > 0 && !userPlayer.PlayerShield.ShieldActive)
                                        {
                                            Console.WriteLine("Would you like to activate your shield? (Y/N): ");
                                            ConsoleKey activeChoice = Console.ReadKey(true).Key;

                                            if (activeChoice == ConsoleKey.Y)
                                            {
                                                userPlayer.PlayerShield.ShieldActive = true;
                                                Console.Clear();
                                                Console.WriteLine(@"

*****************************************************
*                                                   *
*                 SHIELD ACTIVATED!                 *          
*                                                   *
*****************************************************

");
                                            }

                                        }else if (userPlayer.PlayerShield.ShieldActive)
                                        {
                                            Console.WriteLine("Would you like to deactivate your shield? (Y/N): ");
                                            ConsoleKey deactiveChoice = Console.ReadKey(true).Key;

                                            if (deactiveChoice == ConsoleKey.Y)
                                            {
                                                userPlayer.PlayerShield.ShieldActive = false;
                                                Console.Clear();
                                                Console.WriteLine(@"

*****************************************************
*                                                   *
*                SHIELD DEACTIVATED!                *          
*                                                   *
*****************************************************

");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("You don't have any Shields to activate right now.");
                                        }

                                        Console.Write("Press any key to Continue");
                                        Console.ReadKey();
                                        #endregion
                                        break;

                                    case ConsoleKey.E:
                                        exitInventory = true;
                                        Console.Clear();
                                        break;
                                }
                            }
                            while (!exitInventory);
                            break;

                        case ConsoleKey.M:
                            //Monster info
                            Console.WriteLine("Monster info: ");
                            Console.WriteLine(monster);
                            break;

                        case ConsoleKey.E:
                        case ConsoleKey.Escape:
                            Console.WriteLine("No one likes a quitter...");
                            exit = true;
                            //reload = true;
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
            Console.WriteLine("You defeated " + userPlayer.Score + " monster" + (userPlayer.Score == 1 ? "." : "s."));

            #endregion
        }//end Main()

        //private static string GetRoom(byte room, bool monsterStatus)
        //{
        //    string[] rooms =
        //    {
        //        "1", "2", "3", "4", "5"
        //    };

        //    switch (room)
        //    {
        //        case 1:
                
        //            if (monsterStatus)
        //            {
        //                Console.WriteLine("You enter a long, semi lit and dungy, hallway. A pair of eyes appear in the darkness ahead. As they get bigger, you realize it's racing at you to attack!");

        //            }
        //           break;
        //    }

        //    //Random rand = new Random();

        //    //int index = rand.Next(rooms.Length);

        //    //string room = rooms[index];

        //    //return room;

        //    //refactor from commented code above
        //    return rooms[new Random().Next(rooms.Length)];

        //}//end GetRoom()


    }//end class
}//end namespace