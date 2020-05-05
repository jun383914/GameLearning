using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        //using collection-List<> to hold all the items in the world
        private static List<GameItems> _standardGameItems=new List<GameItems>();

        static ItemFactory()
        {
            _standardGameItems.Add(new Weapon(1001, "Pointy Stick", 1, 1, 2));
            _standardGameItems.Add(new Weapon(1002, "Rusty Sword", 5, 1, 3));
            _standardGameItems.Add(new GameItems(9001, "snake fang", 1));
            _standardGameItems.Add(new GameItems(9002, "Snakeskin", 2));
            _standardGameItems.Add(new GameItems(9003, "rat tail", 1));
            _standardGameItems.Add(new GameItems(9004, "Rat fur", 2));
            _standardGameItems.Add(new GameItems(9005, "Spider fang", 1));
            _standardGameItems.Add(new GameItems(9006, "Spider silk", 2));
        }

        public static GameItems CreateGameItem(int itemTypeID)
        {
            GameItems standardItem = _standardGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID);

            if (standardItem != null)
            {
                if(standardItem is Weapon)
                {
                    return (standardItem as Weapon).Clone();
                }
                return standardItem.Clone();
            }
            return null;
        }
    }
}
