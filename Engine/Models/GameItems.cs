using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class GameItems
    {
        public int ItemTypeID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        //Constructors to set property When we create the items
        public GameItems(int itemTypeID, string name, int price)
        {
            ItemTypeID = itemTypeID;
            Name = name;
            Price = price;
        }


        public GameItems Clone()
        {
            //instantiatinga new GameItems object using same property value
            return new GameItems(ItemTypeID, Name, Price);
        }
    }
}
