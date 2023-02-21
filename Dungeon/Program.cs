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

            int score = 0;

            #region Player Creation
            //TODO Variable to keeps scoore

            //TODO Weapon creation

            //TODO Player Object Creation

            #endregion

            #region Main Game Loop
            bool exit = false;
            int innerCount = 0;
            int outerCount = 0;
            do
            {
                //Console.WriteLine("Outer: " + ++outerCount);
                //TO DO Generate a random room
                Console.WriteLine(GetRoom());
                //TODO Select a random monster to inhabit the room
                Console.WriteLine("Here's a monster!");
                #region Gameplay Menu Loop
                bool reload = false;
                do
                {
                    //Console.WriteLine("Inner: " + ++innerCount);
                    //TODO Gameplay Menu
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
                            //TODO Combat
                            Console.WriteLine("Attack!");
                            break;

                        case ConsoleKey.R:
                            //TODO Attack of Opportunity
                            Console.WriteLine("Run away!!");
                            reload = true;
                            break;

                        case ConsoleKey.P:
                            //TODO Player info
                            Console.WriteLine("Player Info: ");
                            break;

                        case ConsoleKey.M:
                            //TODO Monster info
                            Console.WriteLine("Monster info: ");
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