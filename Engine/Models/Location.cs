using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Location
    {
        public int Xcoordinate { get; set; }
        public int Ycoordinate { get; set; }
        public string Name { get; set; }
        public string Description { get; set;}
        public string ImageName { get; set; }
        public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>();

    }
}
