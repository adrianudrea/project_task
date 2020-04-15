using System.Collections.Generic;
using UnityEngine;

public enum ItemType { None, Headwear, Tops, Shoes }

[CreateAssetMenu(fileName = "Item Database", menuName = "Database/New Database/Item Database")]
public class ItemDatabase : ScriptableObject
{
    public List<Items> items = new List<Items>();

    public Items GetItemsById(int id)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i].itemId == id)
            {
                return items[i];
            }
        }
        return null;
    }

    [System.Serializable]
    public class Items
    {
        public int itemId;
        public ItemType itemType;
        public string itemName;
        public Sprite itemIcon;
        public int itemPrice;
        public bool isPurchased;
    }
}
