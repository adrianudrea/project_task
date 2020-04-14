using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType { None, Headwear, Tops, Shoes }

[CreateAssetMenu(fileName = "Item Database", menuName = "Database/New Database/Item Database")]
public class ItemDatabase : ScriptableObject
{
    public List<Items> items = new List<Items>();

    [System.Serializable]
    public class Items
    {
        public int itemId;
        public ItemType itemType;
        public string itemName;
        public Sprite itemIcon;
        public int itemPrice;
    }
}
