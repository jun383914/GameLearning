using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Engine.Factories;
using System.Collections.ObjectModel;

namespace Engine.Models
{
    //Refactory: Having Player calss inheritance from BaseNotificationClass to reduce Duplicated code
    public class Player : BaseNotificationClass
    {
        #region Properties
        
        private string _name;
        private string _charaterClass;
        private int _hitPoints;
        private int _experiencePoints;
        private int _level;
        private int _gold;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string CharacterClass
        {
            get { return _charaterClass; }
            set
            {
                _charaterClass = value;
                OnPropertyChanged(nameof(CharacterClass));
            }
        }
        public int HitPoints 
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set 
            {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));            
            }
        }
        public int Level 
        {
            get { return  _level; }
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        public int Gold 
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }
        #endregion
        public ObservableCollection<GameItems> Inventory { get; set; }

        public List<GameItems> Weapons =>
            Inventory.Where(i => i is Weapon).ToList();

        public ObservableCollection<QuestStatus> Quests { get; set; }


        public Player()
        {
            Inventory = new ObservableCollection<GameItems>();
            Quests = new ObservableCollection<QuestStatus>();
        }
        public void AddItemToInventory(GameItems item)
        {
            Inventory.Add(item);

            OnPropertyChanged(nameof(Weapons));
        }
    }
}
