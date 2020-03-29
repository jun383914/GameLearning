﻿using System;
using System.Collections.Generic;
using System.Linq;
using Engine.Models;
using Engine.Factories;


namespace Engine.ViewModels
{
    //Refactory: Having Player calss inheritance from BaseNotificationClass to reduce Duplicated code
    public class GameSession : BaseNotificationClass
    {
        private Location _currentLocation;
        private Monster _currentMonster;

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

                GivePlayerQuestsAtLocation();
                GetMonsterAtLocation();
            }
        }

        public Monster CurrentMonster
        {
            get { return _currentMonster; }
            set
            {
                _currentMonster = value;

                OnPropertyChanged(nameof(CurrentMonster));
                OnPropertyChanged(nameof(HasMonster));
            }
        }

        public bool HasLocationToNorth
        {
            get { return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null; }
        }

        public bool HasLocationToEast
        {
            get { return CurrentWorld.LocationAt(CurrentLocation.XCoordinate+1, CurrentLocation.YCoordinate) != null; }
        }

        public bool HasLocationToWest
        {
            get { return CurrentWorld.LocationAt(CurrentLocation.XCoordinate-1, CurrentLocation.YCoordinate) != null; }
        }

        public bool HasLocationToSouth
        {
            get { return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate-1) != null; }
        }

        //Same concept as the get return statement
        public bool HasMonster => CurrentMonster != null;

        public GameSession()
        {
            CurrentPlayer = new Player { Name = "Scott", 
                                        Gold = 1000000, 
                                        CharacterClass = "Fighter" , 
                                        HitPoints = 10,
                                        Level = 1,
                                        ExperiencePoints = 0
                                        };

            CurrentWorld = WorldFactory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0,0);
        }

        public void MoveNorth()
        {
            if (HasLocationToNorth) //Guarding Clause to make sure there is a location to north
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);

            }
        }

        public void MoveEast()
        {
            if (HasLocationToEast)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate +1, CurrentLocation.YCoordinate);
            }

        }

        public void MoveWest()
        {
            if (HasLocationToWest)
            { 
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate -1, CurrentLocation.YCoordinate);
            }
        }

        public void MoveSouth()
        {
            if (HasLocationToSouth) 
            { 
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
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

        private void GetMonsterAtLocation()
        {
            CurrentMonster = CurrentLocation.GetMonster();
        }
    }
}
