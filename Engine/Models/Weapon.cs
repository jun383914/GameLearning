using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Weapon : GameItems
    {

        public int MinimumDamage { get; set; }
        public int MaxmumDamage { get; set; }

        public Weapon(int itemTypeID, string name, int price, int minDamage, int maxDamage) : base(itemTypeID, name, price)
        {
            MinimumDamage = minDamage;
            MaxmumDamage = maxDamage;
        }

        //override base class Clone function
        public new Weapon Clone()
        {
            return new Weapon(ItemTypeID, Name, Price, MinimumDamage, MaxmumDamage);
        }
    }
}
