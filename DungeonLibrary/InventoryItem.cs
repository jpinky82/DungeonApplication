using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class InventoryItem        
       
    {
        //Fields

        //Props
        public Inventory Item { get; set; }

        //CTORS/Construstors

        public InventoryItem(Inventory item)
        {
            Item = item;
        }

        //Methods

        public override string ToString()
        {
            return $"Inventory Item: {Item}\n";
        }
    }
}
