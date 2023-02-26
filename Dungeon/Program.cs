using DungeonLibrary;
using System.Threading.Tasks.Sources;

namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Title/Introduction
            Console.Title = "DUNGEON OF DOOM!";
            Console.WriteLine("Your journey begins...\n");
            #endregion

            #region Player Creation
            //Variable to keeps scoore
            int score = 0;

            //Possible Expansion - Display a list of pre-created weapons and let them pick one.
            //or. pick one for them randomly.
            Weapon sword = new Weapon(8, 1, "Long Sword", 10, true, WeaponType.Sword);

            //Potential Expansion - Allow them to enter theri own name.
            //show the mall the possible races and let them pick one.
            Player player = new("Isildur", 65, 8, 70, Race.Human, sword);

            #endregion

            #region Main Game Loop
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
                            Combat.DoBattle(player, monster);
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
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();//formatting
                            reload = true;//new room, new monster
                            break;

                        case ConsoleKey.P:
                            //Player info
                            Console.WriteLine("Player Info: ");
                            Console.WriteLine(player);
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
                    if (player.Life <= 0)
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