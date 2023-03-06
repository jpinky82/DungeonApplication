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
                    return new DungeonRoom(false, false, 1, "You're back in the Main Hallway where you first entered the dungeon and it wreaks of rotting spider.\n", 
                                                           "You're standing in a dimly lit hallway.  Multiple eyes suddenly appear in the darkness ahead. As the eyes get\n" +
                                                           "larger you see the outline of a large spider sprinting to attack!  What do you do?");
                case 2:
                    return new DungeonRoom(true, false, 1, "As you walk in, a monster runs toward you from the corner.  What do you do?", 
                                                           "This room is much smaller, the only exit is the door you just walked through.\n" +
                                                           "As the door shuts a creature leaps at you! What do you do?");
                case 3:
                    return new DungeonRoom(false, false, 1, "A monster is ready to attack as soon as you walk through the door,\n" +
                                                            "what do you do?",
                                                       "As you walk straight into this room, you see it's square and there's another door on the left in the far corner.\n" +
                                                       "From the right, a creature attacks!  What do you do? ");
                case 4:
                    return new DungeonRoom(false, false, 1, "You walk into the giant rectangular shaped room where you defeated the Knight King\nYou " +
                                                            "hear something in the darkness getting louder and louder!.",
                                                            "As you walk into this room you immediatly start shivering, IT'S FREEZING!\n" +
                                                            "You also notice that the room is HUGE!.  It seems you entered in the bottom corner of a large rectangle\n" +
                                                            "shaped room, but the other side is shrowded in darkness. You see 2 doors, side by side, in the middle\nof the " +
                                                            "opposite wall.\n\nThe room gets even colder as you seee a shadowy figure come in to the light, " +
                                                            "It's the Night King!\nYou've only heard of his stories in fairy tales as a kid!  What do you do?");
                case 5:
                    return new DungeonRoom(true, false, 1, "As you walk in, a monster runs toward you from the corner.  What do you do?", "This is another small\n" +
                                                           "room with one entrance and exit.\n" +
                                                           "A monster is standing in the corner rummaging through some gold coins. They turn around and\n" +
                                                           "catapult towards you! What do you do?");
                case 6:
                    return new DungeonRoom(false, true, 1, "You walk in to the room with a slewn Atlas laying on the floor, a figure approaches from the distance.\n", 
                                                            "In this room, the air feels different.  It's humid, hot, and smells horrendous!\n" +
                                                            "It's dimly lit with sporadic torches and the ceiling isn't even visible.\n" +
                                                            "A large shadowy figure suddenly stands in the back corner and starts moving toward you.\n" +
                                                            "Each step thunders beneath it's feat!\n" +
                                                            "You immediately recognize this figure as it gets closer, it's Atlas The Giant!!!\n" +
                                                            "Now you know why the door was locked!\n\nHe's going to attack, what do you do?");
                case 7:
                    return new DungeonRoom(false, true, 1, "You wall back into the large cave where Smaug's body lay lifeless on the floor.\n" +
                                                           "A Monster comes racing out of the darkness towards you!", 
                                                           "You just walked into an enourmous cavern.\n" +
                                                           "Except for a couple torches near the door it's very dark and hard to tell the exact scope\n" +
                                                           "of it's size. After walking a couple hundred feet in, you look up and see bright light coming from\n" +
                                                           "the mouth of what looks like a Dragon!  It spits a stream of fire directly at you as you\n" +
                                                           "diveout of the way.  In that moment you realize what creature has been trapped in here...\n\n" +
                                                           "The infamous Dragon Smaug!!\nWhat do you do?");
                default:
                    return new DungeonRoom(false, false, 1, "Reality must be collapsing if you're back here for a 2nd time, something is seriously broke.", "You have arrived in an alternate dimension put here by the C# \"I must have a default\" God");
            }


        }

    }
}
