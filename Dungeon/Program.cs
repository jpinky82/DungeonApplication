using DungeonLibrary;
using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Threading;
using System.Xml;
using static System.Collections.Specialized.BitVector32;
using static System.Formats.Asn1.AsnWriter;


//Ascii Text Art came from https://onlineasciitools.com/convert-text-to-ascii-art - Font name: small

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
            #region Name Character Ascii
            Console.WriteLine(@"
**************************************************************
*   _  _                                                     *
*  | \| |  __ _   _ __    ___     _  _   ___   _  _   _ _    *
*  | .` | / _` | | '  \  / -_)   | || | / _ \ | || | | '_|   *
*  |_|\_| \__,_| |_|_|_| \___|    \_, | \___/  \_,_| |_|     *
*    ___   _                      |__/     _                 *
*   / __| | |_    __ _   _ _   __ _   __  | |_   ___   _ _   *
*  | (__  | ' \  / _` | | '_| / _` | / _| |  _| / -_) | '_|  *
*   \___| |_||_| \__,_| |_|   \__,_| \__|  \__| \___| |_|    *
*                                                            *
**************************************************************
");
            #endregion

            #region Main Menu and Player Creation

            Console.Write("\nPlease give your character a name: ");
            string userName = Console.ReadLine().ToString();

            Console.Clear();
            #region Choose Weapon Ascii
            Console.WriteLine(@"
**************************************************************
*   ___   _                                                  *
*  / __| | |_    ___   ___  ___     _  _   ___   _  _   _ _  *
* | (__  | ' \  / _ \ (_-< / -_)   | || | / _ \ | || | | '_| *
*  \___| |_||_| \___/ /__/ \___|    \_, | \___/  \_,_| |_|   *
*       __      __                  |__/                     *
*       \ \    / /  ___   __ _   _ __   ___   _ _            *
*        \ \/\/ /  / -_) / _` | | '_ \ / _ \ | ' \           *
*         \_/\_/   \___| \__,_| | .__/ \___/ |_||_|          *
*                               |_|                          *               
*                                                            *
**************************************************************
");
            #endregion
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("L) Long Sword\n" +
                          "B) Bow & Arrow\n" +
                          "W) War Hammer\n" +
                          "C) Crossbow\n" +
                          "K) Katana\n" +
                          "S) Spear\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Please choose a Weapon: ");

            Weapon userWeapon = Weapon.GetWeapon(Console.ReadLine());

            Console.Clear();
            #region Select Race Ascii
            Console.WriteLine(@"
*****************************************************************
*  ___         _              _      __   __                    *
* / __|  ___  | |  ___   __  | |_    \ \ / /  ___   _  _   _ _  *
* \__ \ / -_) | | / -_) / _| |  _|    \ V /  / _ \ | || | | '_| *
* |___/ \___| |_| \___| \__|  \__|     |_|   \___/  \_,_| |_|   *
*                   ___                                         *
*                  | _ \  __ _   __   ___                       *
*                  |   / / _` | / _| / -_)                      *
*                  |_|_\ \__,_| \__| \___|                      *
*                                                               *
*****************************************************************
");
            #endregion

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
            Console.WriteLine("In a far off land known as LandyMcLandia there was the small town of TownyMcTowntown. Both of which were named after an overwhelming, and unfortunate, youth turnout in the Great Renaming Vote of 1272....You can still hear the elders in the saloon going on and on about the disaster....Anyway...\n\nLandyMcLandia is a magical land full of a variety of different species. They all, somehow, speak the same language and get along fairly well despite the occasional grievance. On the outskirts of town lived an extremely wealthy scientist, Dr. Agon.  He kept to himself mostly but had been seen in town on occassion gathering strange supplies for an experiment.\n\nThe rumors about Dr. Agon experimenting on other animals started 2 years ago. Public opinion swayed drastically against the doctor at that point and, after being openly pressed on the matter by the Mayor, he wasn't seen in town again.\n\nA little over a month ago, a group of teenagers wondered on to the property. In front of what looks like some kind of dungeon door that leads underground, they found the body of Dr.Agon with a puncture wound through the abdomin. After 2 officers of The Peace entered the dungeon and never came out, Mayor Amy Stake has decided to put a call out to all the land.\n\nTo anyone willing to enter the dugeon on the Dr. Agon estate, anything of financial significance on the property will be yours as long as what lies inside is destroyed. The citizens of TownyMcTowntown deserve to feel safe in their homes, WE NEED A HERO!\n\n");
            Console.WriteLine($"{userName}...YOU...ARE...THAT...HERO!");
            Console.Write("\nPress any key to continue. ");
            Console.ReadKey();
            Console.Clear();
            #endregion

            //TODO Move storyline to string and iterate through with for loop and add delay for typwriter effect Thread.Sleep(milliseconds) if character = "." add extra time.
            ////TODO Try Console.BufferWidth Property to fix the word wrap issue.  May not work with the for loop above. 


            Console.WriteLine($"Shortly after arriving in TownyMcTowntown, the Mayor wastes no time and leads you to the dungeon door.  She pats you on the back and exclaims, \"Good Luck!!\" and swiftly scurries off.  You pull out your {userWeapon.Name}, open the door, and walk through. The Door shuts behind you.\n\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();


            //Pre-Loading Dungeon Rooms
            DungeonRoom room1 = DungeonRoom.GetDungeonRoom(1);
            DungeonRoom room2 = DungeonRoom.GetDungeonRoom(2);
            DungeonRoom room3 = DungeonRoom.GetDungeonRoom(3);
            DungeonRoom room4 = DungeonRoom.GetDungeonRoom(4);
            DungeonRoom room5 = DungeonRoom.GetDungeonRoom(5);
            DungeonRoom room6 = DungeonRoom.GetDungeonRoom(6);
            DungeonRoom room7 = DungeonRoom.GetDungeonRoom(7);

            //Pre-Loading the first Boss Monster
            Monster monster = Monster.GetBossMonster(1);


            //Variable to keeps score and bool to exit the Level Select DoWhile, bool to Exit the Game, and bool to reload when player chooses to run.
            bool gameExit = false;
            bool playerRan = false;
            int previousLevel = 1;
            int currentLevel = 1;
            bool levelSelectExit = false;
            bool reload = false;
            bool victory = false;
            int runnerRoom = 0;

            //Player can exit game in 1 of 3 ways. run from a Monster in room 1, Select exit from the Gameplay Menu, or Complete the Game.
            //Below is a detailed map where w/Room Numbers and where keys can be found.
            #region Map With Room Numbers & Other Details


            //                                               Dungeon Map
            //                                                                 ______________________________________________
            //                _____________________                           |                                              |
            //               |          |          |                          |                                              |
            //               |          |          |                          |                                              |
            //               |  Rm. 2   |          |_______                   |                                              |
            //               |          |          |       |                  |                                              |
            //_______________|_____  |__|          | Rm. 5 |                  |                                              |
            //                          |           ___    |                  |                                              |
            //             Rm. 1        | Rm. 4    |_______|__________________|                                              |
            //                          |          |___                       |                                              |
            //_____________________  ___|             <-Requires Green Key    |                                              |
            //               |       |  |          |    Found in Rm. 2        |        Rm. 7                                 |
            //               |          |          |                          |                                              |
            //               |  Rm. 3   |          |        Rm. 6              ___<---- Requires Red Key                     |
            //               |           ___       |                          |         Found in Room 5                      |
            //               |__________|__________|__________________________|                                              |
            //                                                                |                                              |
            //                                                                |                                              |
            //            Openings are approximate door locations             |                                              |
            //        Map can also be accesses In-Game through Inventory      |                                              |
            //                                                                |                                              |
            //                                                                |______________________________________________|
            #endregion

            do
            {

                //Room switch DoWhile
                do
                {
                    //If player runs away during battle, they will get sent back to the previous room.
                    if (reload && playerRan)
                    {
                        currentLevel = previousLevel;
                        //TODO - Figure out why the ternary is not working.  In level 2, it is giving me the first reponse
                        Console.WriteLine($"What's the matter {userName}....Chicken??\n");
                        Console.WriteLine(runnerRoom == 1 ? "The entrance door is locked!" : "You manage to make it back to the previous room");
                        Console.WriteLine("\n\nPress any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    reload = false;
                    playerRan = false;

                    //There are 8 rooms in this dungeon.  Players have the ability to move back and forth between rooms
                    if (!gameExit)
                    {
                        switch (currentLevel)
                        {
                            //Each Room has a switch case of it's own so each time a room is re-entered, it will be the same as when it was first left.
                            //A baby monster is also dropped in on repeated visits.
                            case 1:
                                if (runnerRoom == 1)//dials back the number of visits if a player ran from this room previously.
                                                    //This way they can't run and come back to a defeated Boss Monster.
                                {
                                    if (room1.NumOfVisits != 1)
                                    {
                                        room1.NumOfVisits--;
                                    }
                                    runnerRoom = 0;
                                }
                                switch (room1.NumOfVisits)
                                {
                                    case 1://First time through rooms 1,4,6, & 7 we drop in a Boss Monster
                                        Console.WriteLine(room1.NotVisitedMessage);
                                        levelSelectExit = true;
                                        monster = Monster.GetBossMonster(1);
                                        room1.NumOfVisits++;
                                        break;

                                    case 2://Second time through (after the Boss Monster is defeated) we gather the loot and then give the player an option on which door to go through next.
                                        userPlayer.PlayerShield.Count++;
                                        userPlayer.Potions++;
                                        userPlayer.Gold += 600;

                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("+1 Shield\n+1 Potion\n+600 Gold\n\n\n");
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("You stand over the dead spider terrified at what just happened.  You turn to walk out the door but a glimmer of gold catches your eye in the back of the room. The desire to leave instantly vanishes as you investigate and realized you just picked up a Healing Potion, Shield, and 600 gold coins!\n\n");

                                        Console.Write("As you're looking at the back wall, you have noticed there are 2 doors on your left and right.\n\n" +
                                                      "Which door do you choose? (L/R)");
                                        ConsoleKey userChoice = Console.ReadKey(true).Key;

                                        
                                        if (userChoice == ConsoleKey.R)
                                        {
                                            previousLevel = currentLevel;
                                            currentLevel = 3;
                                            Console.Clear();
                                            Console.WriteLine("You open the door to the right and walk through.\n");
                                        }
                                        else
                                        {
                                            previousLevel = currentLevel;
                                            currentLevel = 2;
                                            Console.Clear();
                                            Console.WriteLine("You open the door to the left and walk through.\n");
                                        }

                                        room1.NumOfVisits++;
                                        break;

                                    case >= 3://On repeated entrances to the same room, odd number of visits will drop a baby monster.
                                              //Even number will give the monster name the baby monster that was just defeated and an option for which door to go through next.

                                        if (room1.NumOfVisits % 2 != 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine(room1.HasVisitedMessage);
                                            monster = Monster.GetBabyMonster();
                                            Console.WriteLine($"\nYou hear something coming towards you!\nIt's {monster.Name}, What do you do?");
                                            levelSelectExit = true;
                                            room1.NumOfVisits++;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"After quickly disposing of {monster.Name}, you look around at your exits.\n\n" +
                                                              $"You are back in the main hallway where you first entered the dungeon.  Looking at the back wall, you can exit the dungeon by turning around and walking out the entrance (ending your game) or there's a door to your left and one to your right.");
                                            Console.Write("Which direction do you choose?  (E)xit, (L)eft, or (R)ight");
                                            ConsoleKey userRm1Choice = Console.ReadKey(true).Key;
                                            if (userRm1Choice == ConsoleKey.R)
                                            {
                                                previousLevel = currentLevel;
                                                currentLevel = 3;
                                                Console.Clear();
                                                Console.WriteLine("You open the door to the right and walk through.\n");
                                            }
                                            else if (userRm1Choice == ConsoleKey.L)
                                            {
                                                previousLevel = currentLevel;
                                                currentLevel = 2;
                                                Console.Clear();
                                                Console.WriteLine("You open the door to the left and walk through.\n");
                                            }
                                            else
                                            {
                                                levelSelectExit = true;
                                                gameExit = true;
                                            }
                                            room1.NumOfVisits++;
                                        }
                                        break;
                                }//end Level 1 Switch
                                break;

                            case 2:
                                if (runnerRoom == 2)
                                {
                                    if (room2.NumOfVisits != 1)
                                    {
                                        room2.NumOfVisits--;
                                    }
                                    runnerRoom = 0;
                                    //TODO - Add this if statement to all other cases as soon as you figure out whats going on with the ternary issue at the top
                                }
                                switch (room2.NumOfVisits)
                                {
                                    case <= 2:
                                        levelSelectExit = true;
                                        monster = Monster.GetBabyMonster();
                                        if (room2.NumOfVisits == 1)
                                        {
                                            Console.WriteLine(room2.NotVisitedMessage);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nAnother creature appears and swings at you but misses. What do you do?\n");
                                        }

                                        room2.NumOfVisits++;
                                        break;
                                    case 3:
                                        userPlayer.GreenKey++;
                                        userPlayer.Gold += 400;
                                        previousLevel = currentLevel;
                                        currentLevel--;

                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("+1 Green Key\n+400 Gold\n\n\n");
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("Another monster down! In the corner, you find a strange looking green key and 400 more gold coins!\n\n");

                                        Console.Write("You take one last look around the room and walk back through the door.\nPress any key to continue.");
                                        Console.ReadKey();

                                        room2.NumOfVisits++;
                                        break;

                                    case >= 4:
                                        if (room2.NumOfVisits % 2 == 0)
                                        {
                                            Console.WriteLine(room2.HasVisitedMessage);
                                            monster = Monster.GetBabyMonster();
                                            levelSelectExit = true;
                                        }
                                        else
                                        {
                                            previousLevel = currentLevel;
                                            currentLevel--;
                                            room2.NumOfVisits++;
                                            Console.WriteLine($"After quickly disposing of {monster.Name}, you look around the room realizing there is nothing else in here and quickly exit.\nPress any key to continue.");
                                            Console.ReadKey();
                                        }
                                        room2.NumOfVisits++;
                                        break;
                                }//End Level 2 Switch
                                break;

                            case 3:
                                if (runnerRoom == 3)
                                {
                                    room3.NumOfVisits--;
                                    runnerRoom = 0;
                                }
                                switch (room3.NumOfVisits)
                                {
                                    case <= 2:
                                        levelSelectExit = true;
                                        room3.NumOfVisits++;
                                        monster = Monster.GetBabyMonster();

                                        if (room3.NumOfVisits == 1)
                                        {
                                            Console.WriteLine(room3.NotVisitedMessage);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Another creature appears next to you! What do you do?\n");
                                        }
                                        break;
                                    case 3:
                                        userPlayer.Gold += 800;
                                        userPlayer.Potions++;
                                        room3.NumOfVisits++;

                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("+1 Healing Potion\n+800 Gold\n\n\n");
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("In this room you find a Healing Potion and a giant mound of 800 GOLD COINS!\n\n");

                                        Console.Write("As you look back at the door you came in, you can head straight through that door (back to the Main Hallway)\n" +
                                                      "OR go deeper into the dungeon by going through the door on your right.\n" +
                                                      "Which door do you choose?  Press S to go straight or any other key to go right.");
                                        ConsoleKey userChoice = Console.ReadKey(true).Key;
                                        if (userChoice == ConsoleKey.S)
                                        {
                                            previousLevel = currentLevel;
                                            currentLevel = 1;
                                            Console.Clear();
                                            Console.WriteLine("You open the door straight ahead and walk through.\n");
                                        }
                                        else
                                        {
                                            previousLevel = currentLevel;
                                            currentLevel++;
                                            Console.Clear();
                                            Console.WriteLine("You open the door to the right and walk through.\n");
                                        }
                                        break;
                                    case >= 4:
                                        if (room3.NumOfVisits % 2 == 0)
                                        {
                                            room3.NumOfVisits++;
                                            Console.Clear();
                                            Console.WriteLine(room3.HasVisitedMessage);
                                            monster = Monster.GetBabyMonster();
                                            levelSelectExit = true;
                                        }
                                        else
                                        {
                                            room3.NumOfVisits++;
                                            Console.WriteLine($"After handling {monster.Name}, you look around and there are 2 doors.  1 heads back out to the Main Hallway(exit) and one leads deeper into the dungeon.\nWhich door do you choose?  Press D to go deeper or any other key to go towards the exit.");
                                            ConsoleKey userRm3Choice = Console.ReadKey(true).Key;
                                            if (userRm3Choice == ConsoleKey.D)
                                            {
                                                previousLevel = currentLevel;
                                                currentLevel++;
                                                Console.Clear();
                                                Console.WriteLine("You open the door to go deeper into the dungeon and walk through.\n");
                                            }
                                            else
                                            {
                                                previousLevel = currentLevel;
                                                currentLevel -= 2;
                                                Console.Clear();
                                                Console.WriteLine("You open the door to the the Main Hallway and walk through.\n");
                                            }
                                            break;
                                        }
                                        break;
                                }//End Level 3 Switch
                                break;

                            case 4:
                                if (runnerRoom == 4)
                                {
                                    room4.NumOfVisits--;
                                    runnerRoom = 0;
                                }
                                switch (room4.NumOfVisits)
                                {
                                    case 1:
                                        Console.WriteLine(room4.NotVisitedMessage);
                                        levelSelectExit = true;
                                        monster = Monster.GetBossMonster(2);
                                        room4.NumOfVisits++;
                                        break;

                                    case 2:
                                        userPlayer.PlayerShield.Count++;
                                        userPlayer.Gold += 1200;

                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("+1 Shield\n+600 Gold\n\n\n");
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("He just shattered into a thousand pieces! You also hear a loud roar coming from deeper in the dugeon.\nWhile investinging the room you find 1200 gold coins and another shield in a far corner!");

                                        Console.Write("While deciding which route to take next, you end up standing in front of the 2, side by side, " +
                                            "doors in the middle of the room.You notice that the door to the right is green!\n" +
                                            "You can turn around and walk back through the door you just came through (towards the exit)" +
                                            " or choose the left or right door leading deeper into the dungeon.\nWhich door do you choose?\n");
                                        Console.Write("Press (L) for the left door, (R) for the right (green) door, or any other key for the exit: ");
                                        ConsoleKey userChoice = Console.ReadKey(true).Key;
                                        switch (userChoice)
                                        {
                                            case ConsoleKey.L:
                                                previousLevel = currentLevel;
                                                currentLevel++;
                                                Console.Clear();
                                                Console.WriteLine("You open the door to the left and walk through.\n");
                                                break;
                                            case ConsoleKey.R:
                                                Console.Clear();
                                                Console.WriteLine("You walk up to the green door on the right and notice that it's locked!\n");

                                                Console.WriteLine(GrantAccess(userPlayer.GreenKey, userPlayer.RedKey, "green"));
                                                if (userPlayer.GreenKey > 0)
                                                {
                                                    userPlayer.GreenKey -= 1;
                                                    previousLevel = currentLevel;
                                                    currentLevel += 2;
                                                    room6.IsLocked = false;
                                                }
                                                else
                                                {
                                                    previousLevel = currentLevel;
                                                    currentLevel--;
                                                }
                                                Console.WriteLine("Press any key to continue.");
                                                Console.ReadKey();
                                                break;
                                            default:
                                                previousLevel = currentLevel;
                                                currentLevel--;
                                                Console.Clear();
                                                Console.WriteLine("You open the door behind you and and head towards the exit.\n");
                                                break;
                                        }
                                        room4.NumOfVisits++;
                                        break;

                                    case >= 3:

                                        if (room4.NumOfVisits % 2 != 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine(room4.HasVisitedMessage);
                                            monster = Monster.GetBabyMonster();
                                            Console.WriteLine($"\n\nIt's {monster.Name}, What do you do?");
                                            levelSelectExit = true;
                                            room4.NumOfVisits++;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"After quickly disposing of {monster.Name}, you look around at your exits.\n\n" +
                                                              $"You stand in front of the 2 side by side doors leading further into the dungeon.\n" +
                                                              $"You can go in to the left door  or right(green) door or through the door behind you towards the exit\n\n");
                                            Console.Write("Press (L) for the left door, (R) for the right door, or any other key for the exit: ");
                                            ConsoleKey userRm4Choice = Console.ReadKey(true).Key;
                                            switch (userRm4Choice)
                                            {
                                                case ConsoleKey.L:
                                                    previousLevel = currentLevel;
                                                    currentLevel++;
                                                    Console.Clear();
                                                    Console.WriteLine("You open the door to the left and walk through.\n");
                                                    break;
                                                case ConsoleKey.R:
                                                    Console.Clear();
                                                    Console.WriteLine(room6.IsLocked ? "You walk up to the green door on the right and notice that it's locked!\n" :
                                                                                       "You open the green door to the right and walk through");
                                                    if (room6.IsLocked)
                                                    {
                                                        Console.WriteLine(GrantAccess(userPlayer.GreenKey, userPlayer.RedKey, "green"));

                                                        if (userPlayer.GreenKey > 0)
                                                        {
                                                            userPlayer.GreenKey -= 1;
                                                            previousLevel = currentLevel;
                                                            currentLevel += 2;
                                                            room6.IsLocked = false;
                                                        }
                                                        else
                                                        {
                                                            previousLevel = currentLevel;
                                                            currentLevel--;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        previousLevel = currentLevel;
                                                        currentLevel += 2;
                                                    }
                                                    Console.WriteLine("\nPress any key to continue.");
                                                    Console.ReadKey();
                                                    break;
                                                default:
                                                    previousLevel = currentLevel;
                                                    currentLevel--;
                                                    Console.Clear();
                                                    Console.WriteLine("You open the door behind you and and head towards the exit.\n");
                                                    break;
                                            }
                                            room4.NumOfVisits++;
                                        }
                                        break;
                                }//end Level 4 Switch
                                break;

                            case 5:
                                if (runnerRoom == 5)
                                {
                                    room5.NumOfVisits--;
                                    runnerRoom = 0;
                                }
                                switch (room5.NumOfVisits)
                                {
                                    case <= 2:
                                        levelSelectExit = true;
                                        monster = Monster.GetBabyMonster();
                                        if (room5.NumOfVisits == 1)
                                        {
                                            Console.WriteLine(room5.NotVisitedMessage);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nAnother creature appears across the room. What do you do?\n");
                                        }

                                        room5.NumOfVisits++;
                                        break;
                                    case 3:
                                        userPlayer.RedKey++;
                                        userPlayer.Gold += 400;
                                        previousLevel = currentLevel;
                                        currentLevel--;

                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("+1 Red Key\n+400 Gold\n\n\n");
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine($"After both monsters are cleared out, you find another strange looking key but this time it's red. You also find 400 more gold coins!\n You're getting rich off this endeavor, you already have {userPlayer.Gold} gold coins!\n");

                                        Console.Write("You clear out the room and head back through the door.\nPress any key to continue.");
                                        Console.ReadKey();

                                        room5.NumOfVisits++;
                                        break;

                                    case >= 4:
                                        if (room5.NumOfVisits % 2 == 0)
                                        {
                                            Console.WriteLine(room5.HasVisitedMessage);
                                            monster = Monster.GetBabyMonster();
                                            levelSelectExit = true;
                                        }
                                        else
                                        {
                                            previousLevel = currentLevel;
                                            currentLevel--;
                                            room5.NumOfVisits++;
                                            Console.WriteLine($"After quickly disposing of {monster.Name}, you look around to make sure no gold was left behind and head back out the door.\nPress any key to continue.");
                                            Console.ReadKey();
                                        }
                                        room5.NumOfVisits++;
                                        break;
                                }//End Level 5 Switch
                                break;

                            case 6:
                                if (runnerRoom == 6)
                                {
                                    room6.NumOfVisits--;
                                    runnerRoom = 0;
                                }
                                switch (room6.NumOfVisits)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine(room6.NotVisitedMessage);
                                        levelSelectExit = true;
                                        monster = Monster.GetBossMonster(3);
                                        room6.NumOfVisits++;
                                        break;

                                    case 2:
                                        userPlayer.PlayerShield.Count += 2;
                                        userPlayer.Potions++;
                                        userPlayer.Gold += 10000;

                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("+2 Shields\n+1 Potion\n+10000 Gold\n\n\n");
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("After a tough fight wit Atlas, you walk to the back wall and see the biggest treasure yet!  " +
                                            "10,000 gold, 2 shields, and a potion!\nThere's another door going deeper into the dungeon and you can't help but wonder," +
                                            "What comes after Atlas??  How much treasure is behind that door?\n\n");

                                        Console.Write("There are 2 ways out of this cavern, forward or back.  The door ahead is red!\nWhich way will you go?\n");
                                        Console.Write("Press (F) for forward towards the red door or (B) to go back towards the exit: ");
                                        ConsoleKey userChoice = Console.ReadKey(true).Key;
                                        switch (userChoice)
                                        {
                                            case ConsoleKey.B:
                                                previousLevel = currentLevel;
                                                currentLevel -= 2;
                                                Console.Clear();
                                                Console.WriteLine("You open the door behind you and and head towards the exit.\n");
                                                break;
                                            case ConsoleKey.F:
                                                Console.Clear();
                                                Console.WriteLine("You walk up to the red door and notice that it's locked!\n");

                                                Console.WriteLine(GrantAccess(userPlayer.GreenKey, userPlayer.RedKey, "red"));

                                                if (userPlayer.RedKey > 0)
                                                {
                                                    userPlayer.RedKey--;
                                                    previousLevel = currentLevel;
                                                    currentLevel++;
                                                    room7.IsLocked = false;
                                                }
                                                else
                                                {
                                                    previousLevel = currentLevel;
                                                    currentLevel -= 2;
                                                }
                                                break;
                                            default:
                                                previousLevel = currentLevel;
                                                currentLevel -= 2;
                                                Console.Clear();
                                                Console.WriteLine("You open the door behind you and and head towards the exit.\n");
                                                break;
                                        }
                                        Console.WriteLine("Press any key to continue.");
                                        Console.ReadKey();
                                        room6.NumOfVisits++;
                                        break;

                                    case >= 3:

                                        if (room6.NumOfVisits % 2 != 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine(room6.HasVisitedMessage);
                                            monster = Monster.GetBabyMonster();
                                            Console.WriteLine($"\n\nIt's {monster.Name}, What do you do?");
                                            levelSelectExit = true;
                                            room6.NumOfVisits++;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"After quickly disposing of {monster.Name}, you look around at your exits.\n\n" +
                                                              $"There are 2, the door in the back leads deeper into the dungeon or there is the door" +
                                                              $"that leads back towards the exit.\n\n");
                                            Console.Write("Press (F) to go forward, (B) to go back towards the exit ");
                                            ConsoleKey userRm6Choice = Console.ReadKey(true).Key;
                                            switch (userRm6Choice)
                                            {
                                                case ConsoleKey.B:
                                                    previousLevel = currentLevel;
                                                    currentLevel -= 2;
                                                    Console.Clear();
                                                    Console.WriteLine("You turn towards the exit.\n");
                                                    break;
                                                case ConsoleKey.F:
                                                    Console.Clear();
                                                    Console.WriteLine(room7.IsLocked ? "You walk up to the red door notice that it's locked!\n" :
                                                                                       "You open the red door and walk through\n");
                                                    if (room7.IsLocked)
                                                    {
                                                        Console.WriteLine(GrantAccess(userPlayer.GreenKey, userPlayer.RedKey, "red"));

                                                        if (userPlayer.RedKey > 0)
                                                        {
                                                            userPlayer.RedKey -= 1;
                                                            previousLevel = currentLevel;
                                                            currentLevel++;
                                                            room7.IsLocked = false;
                                                        }
                                                        else
                                                        {
                                                            previousLevel = currentLevel;
                                                            currentLevel -= 2;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        previousLevel = currentLevel;
                                                        currentLevel++;
                                                    }
                                                    break;
                                                default:
                                                    previousLevel = currentLevel;
                                                    currentLevel -= 2;
                                                    Console.Clear();
                                                    Console.WriteLine("You open the door behind you and and head towards the exit.\n");
                                                    break;
                                            }
                                            Console.WriteLine("Press any key to continue.");
                                            Console.ReadKey();
                                            room6.NumOfVisits++;
                                        }
                                        break;
                                }//end Level 6 Switch
                                break;

                            case 7:
                                if (runnerRoom == 7)
                                {
                                    room7.NumOfVisits--;
                                    runnerRoom = 0;
                                }
                                switch (room7.NumOfVisits)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine(room7.NotVisitedMessage);
                                        levelSelectExit = true;
                                        monster = Monster.GetBossMonster(4);
                                        room7.NumOfVisits++;
                                        break;

                                    case 2:
                                        userPlayer.Gold += 1000000;

                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("+1000000 Gold\n\n\n");
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        victory = true;
                                        Console.WriteLine("After a long and tough fight with Smaug, you finally come out on top! You take a great deal of time to explore the large cave and find a stash of 1 MILLION GOLD! You also realize that there are no more doors, this was the end of the line!\nCongratulations, you have won!  The town of TownyMcTowntown will be overjoyed that this menace has been purged from existence!");

                                        Console.Write("There is only one way out of here!  You'll keep encountering baby monsters as you go room to room but I can't imagine they'll last too much longer without their larger adult monsters.\n");

                                        room7.NumOfVisits++;
                                        previousLevel = currentLevel;
                                        currentLevel--;

                                        Console.WriteLine("You head back through the door.\n");

                                        Console.WriteLine("Press any key to continue.");
                                        Console.ReadKey();
                                        break;

                                    case >= 3:

                                        if (room7.NumOfVisits % 2 != 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine(room7.HasVisitedMessage);
                                            monster = Monster.GetBabyMonster();
                                            Console.WriteLine($"\n\nIt's {monster.Name}, What do you do?");
                                            levelSelectExit = true;
                                            room7.NumOfVisits++;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"After quickly disposing of {monster.Name}, you look around and head back out the door from where you came.\n\n");
                                            previousLevel = currentLevel;
                                            currentLevel--;
                                            Console.WriteLine("Press any key to continue.");
                                            Console.ReadKey();
                                            room7.NumOfVisits++;
                                        }
                                        break;
                                }//end Level 7 Switch
                                break;
                        }//end Level Switch
                    }
                } while (!levelSelectExit);
                levelSelectExit = false;




                //Console.WriteLine($"In the back corner of the room you hear a loud high pitched voice say, \"My name is {monster.Name}, who are you?\"");

                #region Gameplay Menu Loop
                while (!reload && !gameExit) //if either exit or reload is true, the inner loop will exit.
                {
                    //Gameplay Menu
                    #region Menu

                    //Menu using Recursion Method "GetRecursiveMenu"  Sends in array and it's length.  Prints each item in the array to the console.

                    string[] mainMenu = { "E) Exit", "M) Monster Info", "I) Inventory", "P) Player Info", "R) Run away", "A) Attack", "\n\nPlease choose an action: " };
                    int menuIndex = mainMenu.Length-1;

                    Console.WriteLine(GetRecursiveMenu(mainMenu, menuIndex));


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
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                //flip the inner-loop bool to true
                                reload = true;

                                userPlayer.Score++;
                            }

                            if (userPlayer.PlayerShield.ShieldActive && userPlayer.PlayerShield.AttacksGiven == 9)
                            {
                                userPlayer.PlayerShield.AttacksGiven = 0;
                                userPlayer.PlayerShield.Count--;
                                userPlayer.PlayerShield.ShieldActive = false;

                            }
                            else if (userPlayer.PlayerShield.ShieldActive)
                            {
                                userPlayer.PlayerShield.AttacksGiven++;
                            }

                            break;

                        case ConsoleKey.R:
                            //TODO Attack of Opportunity
                            Console.Clear();
                            Console.WriteLine("You frantically jump to the door you just walked through!!\n\n");
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, userPlayer);
                            Console.WriteLine();
                            reload = true;
                            playerRan = true;
                            runnerRoom = currentLevel;
                            break;

                        case ConsoleKey.P:
                            //Player info
                            Console.WriteLine("Player Info: ");
                            Console.WriteLine(userPlayer);
                            Console.WriteLine($"Current Score: {userPlayer.Score}");
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
                                "M) Map\n" +
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
                                            Console.WriteLine($"You currently have " + userPlayer.Potions + " Healing Potion" + (userPlayer.Potions == 1 ? "." : "s.\n"));
                                            Console.WriteLine("Each Healing Potion will fully regenerate your health!\n");
                                            Console.Write("Would you like to use one? Y/N :");
                                            ConsoleKey potionChoice = Console.ReadKey(true).Key;

                                            if (potionChoice == ConsoleKey.Y)
                                            {
                                                userPlayer.Life = userPlayer.MaxLife;
                                                userPlayer.Potions--;

                                                Console.WriteLine($"\n\nYou're Health is now {userPlayer.Life} of {userPlayer.MaxLife}\n" +
                                                    $"You have " + userPlayer.Potions + " Healing Potion" + (userPlayer.Potions == 1 ? " " : "s ") + "remaining.\n\n");
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
                                        Console.WriteLine(userPlayer.PlayerShield.ShieldActive ? "A SHIELD IS CURRENTLY ENABLED!" : "No shield is currently enabled");
                                        Console.WriteLine($"\nTotal Number Of Shields: {userPlayer.PlayerShield.Count}");
                                        Console.WriteLine($"\nAttacks left on Current Shield: " + (userPlayer.PlayerShield.Count == 0 ? 0 : (10 - userPlayer.PlayerShield.AttacksGiven)));
                                        Console.WriteLine(@"

***************************************************************
*                                                             *
*   Once a shield is enabled, it can withstand 10 attacks!    *
*   Once a shield is exhausted,                               *
*       1) Your shield protection will end.                   *
*       2) The 'Total Number of Shields' will reduce by 1.    *
*       3) The 'Attacks left on Current Shield' will always   * 
*          show how many attacks are left on the current      *
*          Shield until all Shields are exhausted.            *
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

                                        }
                                        else if (userPlayer.PlayerShield.ShieldActive)
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
                                    case ConsoleKey.M:
                                        Console.Clear();
                                        Console.WriteLine(GetMap(currentLevel));
                                        Console.Write("\n\nPress any key to Continue: ");
                                        Console.ReadKey();
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
                            gameExit = true;
                            break;
                    }//end switch
                    #endregion
                    // Check player life
                    if (userPlayer.Life <= 0)
                    {
                        #region You Died Ascii
                        Console.WriteLine(@"
*****************************************************************
*      __   __                 ___    _            _   _        *
*      \ \ / /  ___   _  _    |   \  (_)  ___   __| | | |       *
*       \ V /  / _ \ | || |   | |) | | | / -_) / _` | |_|       *
*        |_|   \___/  \_,_|   |___/  |_| \___| \__,_| (_)       *
*                                                               *
*****************************************************************
");
                        #endregion
                        Console.WriteLine("You died a valient death fighting the good fight!\a");
                        Console.WriteLine("\nThe people of TownyMcTowntown will always remember your sacrifice.");
                        gameExit = true;
                    }
                } //end While Loop 
                #endregion
            } while (!gameExit);//if exit is true, the outer loop willl exit as well.

            //Show the score
            if (victory)
            {
                Console.Clear();
                #region You Died Ascii
                Console.WriteLine(@"
******************************************************************
* __   __  ___    ___   _____    ___    ___  __   __  _   _   _  *
* \ \ / / |_ _|  / __| |_   _|  / _ \  | _ \ \ \ / / | | | | | | *
*  \ V /   | |  | (__    | |   | (_) | |   /  \ V /  |_| |_| |_| *
*   \_/   |___|  \___|   |_|    \___/  |_|_\   |_|   (_) (_) (_) *
*                                                                *
******************************************************************
");
                #endregion
                Console.WriteLine("Victory is yours!!\nYou have defeated all of the vile creatures of Dr. Agon's creation!\n");
                Console.WriteLine("\nThe mayor of TownyMcTowntown give you a key to the city!\nThe people give you a hero's welcome and throw a ticker tape parade in your honor!\n");
                Console.WriteLine($"The Dr. Agon Estate is now yours! You also came out of the dungeon with {userPlayer.Gold:d0} Gold Coins!");
                Console.WriteLine("You defeated " + userPlayer.Score + " monster" + (userPlayer.Score == 1 ? "." : "s."));
                Console.WriteLine("\n\nYou live the rest of your days on that estate and become a World Renowned Monster Expert!\n\n\n");
            }
            else if (!victory && userPlayer.Life != 0)
            {
                #region Quitter! Ascii
                Console.WriteLine(@"
*******************************************************************
*      __   __   ___    _   _   _   ___   ___       _             *
*      \ \ / /  / _ \  | | | | ( ) | _ \ | __|     /_\            *
*       \ V /  | (_) | | |_| | |/  |   / | _|     / _ \           *
*        |_|    \___/   \___/      |_|_\ |___|   /_/ \_\          *
*                                                                 *
*        ___    _   _   ___   _____   _____   ___   ___   _       *
*       / _ \  | | | | |_ _| |_   _| |_   _| | __| | _ \ | |      *
*      | (_) | | |_| |  | |    | |     | |   | _|  |   / |_|      *
*       \__\_\  \___/  |___|   |_|     |_|   |___| |_|_\ (_)      *
*                                                                 *
*******************************************************************
");
                #endregion
                Console.WriteLine("You quit.......you just quit.\n\nThe great people of TownyMcTowntown hear the news and a mob forms, " +
                                  "they chase you from the area with torches and pitchforks vowing you'll die if you ever return!\n\n" +
                                  "You live out the rest of your days in squaler thinking about what life could have been if you weren't such a chicken.\n");

                Console.WriteLine("You defeated " + userPlayer.Score + " monster" + (userPlayer.Score == 1 ? "." : "s."));
            }
            #endregion
        }//end Main()

        private static string GetRecursiveMenu(string[] menu, int counter)
        {
            
            if (counter == 0)
            {

                return menu[counter];
            }
            else
            {
                Console.WriteLine(menu[counter]);
                return GetRecursiveMenu(menu, counter-1);
            }
        }


        public static string GetMap(int currentLevel)
        {
            switch (currentLevel)
            {
                
                case 1:
                    #region Level1
                    return @"

                                               Dungeon Map
                                                                 ______________________________________________
                _____________________                           |                                              |
               |          |          |                          |                                              |
               |          |          |                          |                                              |
               |          |          |_______                   |                                              |
               |          |          |       |                  |                                              |
_______________|_____  |__|          |       |                  |                                              |
                          |           ___    |                  |                                              |
                 X        |          |_______|__________________|                                              |
                          |          |___                       |                                              |
_____________________  ___|                                     |                                              |
               |       |  |          |                          |                                              |
               |          |          |                          |                                              |
               |          |          |                           ___                                           |
               |           ___       |                          |                                              |
               |__________|__________|__________________________|                                              |
                                                                |                                              |
                                                                |                                              |
            Openings are approximate door locations             |                                              |
                                                                |                                              |
              Caution: Some doors may be locked!                |                                              |
                    X: Shows Player approximate position        |______________________________________________|";
                #endregion
                case 2:
                    #region Level2
                    return @"

                                               Dungeon Map
                                                                 ______________________________________________
                _____________________                           |                                              |
               |          |          |                          |                                              |
               |          |          |                          |                                              |
               |    X     |          |_______                   |                                              |
               |          |          |       |                  |                                              |
_______________|_____  |__|          |       |                  |                                              |
                          |           ___    |                  |                                              |
                          |          |_______|__________________|                                              |
                          |          |___                       |                                              |
_____________________  ___|                                     |                                              |
               |       |  |          |                          |                                              |
               |          |          |                          |                                              |
               |          |          |                           ___                                           |
               |           ___       |                          |                                              |
               |__________|__________|__________________________|                                              |
                                                                |                                              |
                                                                |                                              |
            Openings are approximate door locations             |                                              |
                                                                |                                              |
              Caution: Some doors may be locked!                |                                              |
                    X: Shows Player approximate position        |______________________________________________|";
                #endregion
                case 3:
                    #region Level3
                    return @"

                                               Dungeon Map
                                                                 ______________________________________________
                _____________________                           |                                              |
               |          |          |                          |                                              |
               |          |          |                          |                                              |
               |          |          |_______                   |                                              |
               |          |          |       |                  |                                              |
_______________|_____  |__|          |       |                  |                                              |
                          |           ___    |                  |                                              |
                          |          |_______|__________________|                                              |
                          |          |___                       |                                              |
_____________________  ___|                                     |                                              |
               |       |  |          |                          |                                              |
               |          |          |                          |                                              |
               |   X      |          |                           ___                                           |
               |           ___       |                          |                                              |
               |__________|__________|__________________________|                                              |
                                                                |                                              |
                                                                |                                              |
            Openings are approximate door locations             |                                              |
                                                                |                                              |
              Caution: Some doors may be locked!                |                                              |
                    X: Shows Player approximate position        |______________________________________________|";
                #endregion
                case 4:
                    #region Level4
                    return @"

                                               Dungeon Map
                                                                 ______________________________________________
                _____________________                           |                                              |
               |          |          |                          |                                              |
               |          |          |                          |                                              |
               |          |          |_______                   |                                              |
               |          |          |       |                  |                                              |
_______________|_____  |__|          |       |                  |                                              |
                          |           ___    |                  |                                              |
                          |          |_______|__________________|                                              |
                          |    X     |___                       |                                              |
_____________________  ___|                                     |                                              |
               |       |  |          |                          |                                              |
               |          |          |                          |                                              |
               |          |          |                           ___                                           |
               |           ___       |                          |                                              |
               |__________|__________|__________________________|                                              |
                                                                |                                              |
                                                                |                                              |
            Openings are approximate door locations             |                                              |
                                                                |                                              |
              Caution: Some doors may be locked!                |                                              |
                    X: Shows Player approximate position        |______________________________________________|";
                #endregion
                case 5:
                    #region Level5
                    return @"

                                               Dungeon Map
                                                                 ______________________________________________
                _____________________                           |                                              |
               |          |          |                          |                                              |
               |          |          |                          |                                              |
               |          |          |_______                   |                                              |
               |          |          |       |                  |                                              |
_______________|_____  |__|          |   X   |                  |                                              |
                          |           ___    |                  |                                              |
                          |          |_______|__________________|                                              |
                          |          |___                       |                                              |
_____________________  ___|                                     |                                              |
               |       |  |          |                          |                                              |
               |          |          |                          |                                              |
               |          |          |                           ___                                           |
               |           ___       |                          |                                              |
               |__________|__________|__________________________|                                              |
                                                                |                                              |
                                                                |                                              |
            Openings are approximate door locations             |                                              |
                                                                |                                              |
              Caution: Some doors may be locked!                |                                              |
                    X: Shows Player approximate position        |______________________________________________|";
                #endregion
                case 6:
                    #region Level6
                    return @"

                                               Dungeon Map
                                                                 ______________________________________________
                _____________________                           |                                              |
               |          |          |                          |                                              |
               |          |          |                          |                                              |
               |          |          |_______                   |                                              |
               |          |          |       |                  |                                              |
_______________|_____  |__|          |       |                  |                                              |
                          |           ___    |                  |                                              |
                          |          |_______|__________________|                                              |
                          |          |___                       |                                              |
_____________________  ___|                                     |                                              |
               |       |  |          |                          |                                              |
               |          |          |      X                   |                                              |
               |          |          |                           ___                                           |
               |           ___       |                          |                                              |
               |__________|__________|__________________________|                                              |
                                                                |                                              |
                                                                |                                              |
            Openings are approximate door locations             |                                              |
                                                                |                                              |
              Caution: Some doors may be locked!                |                                              |
                    X: Shows Player approximate position        |______________________________________________|";
                #endregion
                case 7:
                    #region Level7
                    return @"

                                               Dungeon Map
                                                                 ______________________________________________
                _____________________                           |                                              |
               |          |          |                          |                                              |
               |          |          |                          |                                              |
               |          |          |_______                   |                                              |
               |          |          |       |                  |                                              |
_______________|_____  |__|          |       |                  |                                              |
                          |           ___    |                  |                                              |
                          |          |_______|__________________|                                              |
                          |          |___                       |                                              |
_____________________  ___|                                     |                                              |
               |       |  |          |                          |         X                                    |
               |          |          |                          |                                              |
               |          |          |                           ___                                           |
               |           ___       |                          |                                              |
               |__________|__________|__________________________|                                              |
                                                                |                                              |
                                                                |                                              |
            Openings are approximate door locations             |                                              |
                                                                |                                              |
              Caution: Some doors may be locked!                |                                              |
                    X: Shows Player approximate position        |______________________________________________|";
                #endregion
                default:
                    #region Default
                    return @"

                                               Dungeon Map
                                                                 ______________________________________________
                _____________________                           |                                              |
               |          |          |                          |                                              |
               |          |          |                          |                                              |
               |          |          |_______                   |                                              |
               |          |          |       |                  |                                              |
_______________|_____  |__|          |       |                  |                                              |
                          |           ___    |                  |                                              |
                          |          |_______|__________________|                                              |
                          |          |___                       |                                              |
_____________________  ___|                                     |                                              |
               |       |  |          |                          |                                              |
               |          |          |                          |                                              |
               |          |          |                           ___                                           |
               |           ___       |                          |                                              |
               |__________|__________|__________________________|                                              |
                                                                |                                              |
                                                                |                                              |
            Openings are approximate door locations             |                                              |
                                                                |                                              |
              Caution: Some doors may be locked!                |                                              |
                                                                |______________________________________________|";
                    #endregion
            }
        }


        public static string GrantAccess(int greenKey, int redKey, string doorName)
        {
            if (doorName == "green")
            {
                if (greenKey > 0)
                {
                    return "\nYou remember picking up a key in another room that is a similar shade of green.\n" +
                                      "You pull the green key out of your pocket and try it on the lock...IT WORKS!\nYou swing " +
                                      "the door open and walk through.";

                }
                else if (redKey > 0)
                {
                    return "You know you picked up a red key in the other room.\nYou try it in this lock...THE KEY WON'T TURN!\n" +
                        "It seems like you need to go back and find the green key!\nIn search of the green key, " +
                        "you walk back through the door from where you first entered this room.";
                }
                else
                {
                    return "You don't have any keys to unlock this door!\nIn search of the green key, " +
                        "you walk back through the door from where you first entered this room.";
                }
            }

            if (doorName == "red")
            {
                if (redKey > 0)
                {
                    return "\nYou know you picked up a red key in another room.\nYou pull it out of your pocket and try it on the lock..." +
                        "IT WORKS!\nYou swing the door open and walk through.";
                }
                else
                {
                    return "You don't have any keys to unlock this door!\nIn search of the green key, " +
                           "you walk back through the door from where you first entered this room.";
                }
            }
            return "";
        }//end GrantAccess()
    }//end Program
}//end namespace