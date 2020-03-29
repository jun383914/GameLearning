using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class World
    {
        private List<Location> _locations = new List<Location>();

        internal void AddLocation(int xCoordinate, int yCoordinate, string name, string discription, string imagename)
        {
            Location Loc = new Location();
            Loc.XCoordinate = xCoordinate;
            Loc.YCoordinate = yCoordinate;
            Loc.Name = name;
            Loc.Description = discription;
            Loc.ImageName = imagename;

            _locations.Add(Loc);
        }

        public Location LocationAt(int xCoordinate, int yCoordinate)
        {
            foreach(Location Loc in _locations)
            {
                if(Loc.XCoordinate == xCoordinate && Loc.YCoordinate == yCoordinate)
                {
                    return Loc;
                }
            }
            return null;
        }
    }
}
