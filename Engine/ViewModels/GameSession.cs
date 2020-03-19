using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
using Engine.Factories;
using System.ComponentModel;

namespace Engine.ViewModels
{
    //Refactory: Having Player calss inheritance from BaseNotificationClass to reduce Duplicated code
    public class GameSession : BaseNotificationClass
    {
        private Location _currentLocation;

       public World CurrentWorld { get; set; }
       public Player CurrentPlayer { get; set; }
       public Location CurrentLocation 
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                //using nameof in case of the name of the variable changes
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(HasLocationToNorth));
                OnPropertyChanged(nameof(HasLocationToEast));
                OnPropertyChanged(nameof(HasLocationToWest));
                OnPropertyChanged(nameof(HasLocationToSouth));
            }
        }

        public bool HasLocationToNorth
        {
            get { return CurrentWorld.LocationAt(CurrentLocation.Xcoordinate, CurrentLocation.Ycoordinate + 1) != null; }
        }

        public bool HasLocationToEast
        {
            get { return CurrentWorld.LocationAt(CurrentLocation.Xcoordinate+1, CurrentLocation.Ycoordinate) != null; }
        }

        public bool HasLocationToWest
        {
            get { return CurrentWorld.LocationAt(CurrentLocation.Xcoordinate-1, CurrentLocation.Ycoordinate) != null; }
        }

        public bool HasLocationToSouth
        {
            get { return CurrentWorld.LocationAt(CurrentLocation.Xcoordinate, CurrentLocation.Ycoordinate-1) != null; }
        }

        public GameSession()
        {
            CurrentPlayer = new Player { Name = "Scott", 
                                        Gold = 1000000, 
                                        CharacterClass = "Fighter" , 
                                        HitPoints = 10,
                                        Level = 0,
                                        ExperiencePoints = 1
                                        };

            CurrentWorld = WorldFactory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, -1);
        }

        public void MoveNorth()
        {
            if (HasLocationToNorth) //Guarding Clause to make sure there is a location to north
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.Xcoordinate, CurrentLocation.Ycoordinate + 1);

            }
        }

        public void MoveEast()
        {
            if (HasLocationToEast)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.Xcoordinate + 1, CurrentLocation.Ycoordinate);
            }

        }

        public void MoveWest()
        {
            if (HasLocationToWest)
            { 
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.Xcoordinate-1, CurrentLocation.Ycoordinate);
            }
        }

        public void MoveSouth()
        {
            if (HasLocationToSouth) 
            { 
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.Xcoordinate, CurrentLocation.Ycoordinate - 1);
            }
        }

        private void GivePlayerQuestsAtLocation()
        {
            foreach (Quest quest in CurrentLocation.QuestsAvailableHere)
            {
                if (!CurrentPlayer.Quests.Any(q => q.PlayerQuest.ID == quest.ID))
                {
                    CurrentPlayer.Quests.Add(new QuestStatus(quest));
                }
            }
        }
    }
}
