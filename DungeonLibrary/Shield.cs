using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Shield : InventoryItem
    {
        //Fields

        //Props
        public byte Count { get; set; }
        public byte AttacksGiven { get; set; }
        public bool ShieldActive { get; set; }

        //CTORS/Construstors

        public Shield(Inventory item,bool shieldActive, byte count, byte attacksRemaining) : base(item)
        {
            ShieldActive = shieldActive;
            Count = count;
            AttacksGiven = attacksRemaining;
        }

        //Methods

        public override string ToString()
        {
            return base.ToString() + (ShieldActive ? "A SHIELD IS CURRENTLY ENABLED!" : "No shield is currently enabled") +
                                     $"\nTotal Number Of Shields: {Count}\nAttacks left on Current Shield: " + (Count == 0 ? 0 : (10 - AttacksGiven));

        }

        public static Shield GetShield()
        {
            return new Shield(Inventory.Shield, false, 0, 0);
        }
    }
}
