using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInventory : MonoBehaviour
{
    [Header("Item Database")]
    public ItemDatabase itemDatabase;
    [Header("Item Container")]
    public GameObject itemHolderA;
    public GameObject itemHolderB;
    public GameObject itemHolderC;
    public GameObject itemUIPrefab;
    [Header("Shop List")]
    public List<GameObject> itemList = new List<GameObject>();

    private void Start()
    {
        AddItemsToStore();
    }

    public void AddItemsToStore()
    {
        for(int i = 0; i < itemDatabase.items.Count; i++)
        {
            GameObject newStoreItem = Instantiate(itemUIPrefab);
            newStoreItem.GetComponent<Item>().itemId = i;
            newStoreItem.GetComponent<Item>().itemType = itemDatabase.items[i].itemType;
            newStoreItem.GetComponent<Item>().itemName.text = itemDatabase.items[i].itemName;
            newStoreItem.GetComponent<Item>().itemIcon.GetComponent<Image>().sprite = itemDatabase.items[i].itemIcon;
            newStoreItem.GetComponent<Item>().itemIcon.GetComponent<Image>().preserveAspect = true;
            newStoreItem.GetComponent<Item>().itemPrice.text = itemDatabase.items[i].itemPrice.ToString();

            switch (newStoreItem.GetComponent<Item>().itemType)
            {
                case ItemType.Headwear:
                    newStoreItem.transform.SetParent(itemHolderA.transform, false);
                    break;
                case ItemType.Tops:
                    newStoreItem.transform.SetParent(itemHolderB.transform, false);
                    break;
                case ItemType.Shoes:
                    newStoreItem.transform.SetParent(itemHolderC.transform, false);
                    break;
            }
            
            itemList.Add(newStoreItem);
        }
    }
}
