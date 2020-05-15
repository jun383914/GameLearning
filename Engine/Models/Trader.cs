using System.Collections.ObjectModel;


namespace Engine.Models
{
    public class Trader : BaseNotificationClass
    {
        public string Name { get; set; }

        public ObservableCollection<GameItems> Inventory { get; set; }

        public Trader(string name)
        {
            Name = name;
            Inventory = new ObservableCollection<GameItems>();
        }

        public void AddItemToInventory(GameItems item)
        {
            Inventory.Add(item);
        }

        public void RemoveItemFromInventory(GameItems item)
        {
            Inventory.Remove(item);
        }
    }
}
