using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class DungeonRoom
    {
        //Fields

        //Props
        public bool HasKey { get; set; }
        public bool IsLocked { get; set; }
        public int NumOfVisits { get; set; }
        public string HasVisitedMessage { get; set; } = null!;
        public string NotVisitedMessage { get; set; } = null!;

        //CTORS/Construstors

        public DungeonRoom(bool hasKey, bool isLocked, int numOfVisits, string hasVisitedMessage, string notVisitedMessage)
        {
            HasKey = hasKey;
            IsLocked = isLocked;
            NumOfVisits = numOfVisits;
            HasVisitedMessage = hasVisitedMessage;
            NotVisitedMessage = notVisitedMessage;
        }

        //Methods
        
        public static DungeonRoom GetDungeonRoom(byte rmNum)
        {
            switch (rmNum)
            {
                case 1:
                    return new DungeonRoom(false, false, 1, "You're back in the long hallway where you first entered the dungeon and it wreaks of rotting spider.", "The Door shuts behind you. You're standing in a dimly lit hallway.  Multiple eyes suddenly appear in the darkness ahead. As the eyes get larger you see the outline of a large spider sprinting to attack!  What do you do?");
                case 2:
                    return new DungeonRoom(true, false, 1, "You have Visited Room 2 Already", "You are in room 2 for the first time");
                case 3:
                    return new DungeonRoom(false, false, 1, "You have Visited Room 3 Already", "You are in room 3 for the first time");
                case 4:
                    return new DungeonRoom(false, false, 1, "You have Visited Room 4 Already", "You are in room 4 for the first time");
                case 5:
                    return new DungeonRoom(true, false, 1, "You have Visited Room 5 Already", "You are in room 5 for the first time");
                case 6:
                    return new DungeonRoom(false, false, 1, "You have Visited Room 6 Already", "You are in room 6 for the first time");
                case 7:
                    return new DungeonRoom(false, true, 1, "You have Visited Room 7 Already", "You are in room 7 for the first time");
                case 8:
                    return new DungeonRoom(false, true, 1, "You have Visited Room 8 Already", "You are in room 8 for the first time");
                default:
                    return new DungeonRoom(false, false, 1, "You have arrived in an alternate dimension put here by the C# \"I must have a default\" God", 
                        "Reality must be collapsing if you're back here for a 2nd time, something is seriously broke.");
            }


        }

    }
}
