using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInventory : MonoBehaviour
{
    [Header("Item Database")]
    public ItemDatabase itemDatabase;
    [Header("UI Prefab")]
    public GameObject itemUIPrefab;
    [Header("Item Container")]
    public GameObject itemHolder;
    [Header("Shop List")]
    public List<GameObject> itemList = new List<GameObject>();
    

    private void Start()
    {
        AddItemsToStore(0);
        AddItemsToStore(1);
        AddItemsToStore(2);
        AddItemsToStore(3);
        AddItemsToStore(4);
        AddItemsToStore(5);
        AddItemsToStore(6);
        AddItemsToStore(7);
        AddItemsToStore(8);
    }

    public void AddItemsToStore(int id)
    {
        ItemDatabase.Items additem = itemDatabase.GetItemsById(id);

        for(int i = 0; i < itemDatabase.items.Count; i++)
        {
            if(itemDatabase.items[i].itemId == id)
            {
                GameObject newStoreItem = Instantiate(itemUIPrefab);
                newStoreItem.GetComponent<Item>().item = additem;
                newStoreItem.GetComponent<Item>().itemId = i;
                newStoreItem.GetComponent<Item>().itemType = itemDatabase.items[i].itemType;
                newStoreItem.GetComponent<Item>().itemName.text = itemDatabase.items[i].itemName;
                newStoreItem.GetComponent<Item>().itemIcon.GetComponent<Image>().sprite = itemDatabase.items[i].itemIcon;
                newStoreItem.GetComponent<Item>().itemIcon.GetComponent<Image>().preserveAspect = true;
                newStoreItem.GetComponent<Item>().itemPrice.text = itemDatabase.items[i].itemPrice.ToString();
                newStoreItem.transform.SetParent(itemHolder.transform, false);
                itemList.Add(newStoreItem);
                break;
            }
        }
    }
}
