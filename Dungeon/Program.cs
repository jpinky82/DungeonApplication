namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dungeon Application!");

            //TODO Create Player
            bool monsterBool = false;
            bool menu = false;
            do
            {
                //TODO Create Monster

                //TODO Create Room
                do
                {
                    Console.WriteLine("\nPlease choose a program\n" +
                    "(A) Attack\n" +
                    "(R) Run Away\n" +
                    "(C) Character Info\n" +
                    "(M) Monster Info\n" +
                    "(X) Exit");

                    string choice = Console.ReadKey(false).Key.ToString();
                    switch (choice)
                    {
                        case "A":
                            //TODO ATTACK!
                            break;
                        case "R":
                            //TODO RUN AWAY
                            break;
                        case "C":
                            //TODO CHARACTER INFO
                            break;
                        case "M":
                            //TODO MONSTER INFO
                            break;
                        case "X":
                        //TODO EXIT
                        default:
                            Console.WriteLine("Input not recognized. Please try again.");
                            //Console.WriteLine(Console.ReadKey().Key);
                            break;
                    }//end switch

                } while (!menu);

            } while (!monsterBool);
        }
    }
}