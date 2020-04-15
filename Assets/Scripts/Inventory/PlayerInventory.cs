using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [Header("Database")]
    public ItemDatabase itemDatabase;
    [Header("UI Prefab")]
    public GameObject itemUIPrefab;
    [Header("Item Container")]
    public GameObject itemHolderA;
    public GameObject itemHolderB;
    public GameObject itemHolderC;
    [Header("List")]
    public List<GameObject> itemList = new List<GameObject>();

    public void AddItemToInventory(int id)
    {
        ItemDatabase.Items addItem = itemDatabase.GetItemsById(id);

        for (int i = 0; i < itemDatabase.items.Count; i++)
        {
            if (itemDatabase.items[i].itemId == id)
            {
                GameObject newInventoryItem = Instantiate(itemUIPrefab);
                newInventoryItem.GetComponent<Item>().item = addItem;
                newInventoryItem.GetComponent<Item>().itemId = i;
                newInventoryItem.GetComponent<Item>().itemType = itemDatabase.items[i].itemType;
                newInventoryItem.GetComponent<Item>().itemName.text = itemDatabase.items[i].itemName;
                newInventoryItem.GetComponent<Item>().itemIcon.GetComponent<Image>().sprite = itemDatabase.items[i].itemIcon;
                newInventoryItem.GetComponent<Item>().itemIcon.GetComponent<Image>().preserveAspect = true;
                newInventoryItem.GetComponent<Item>().itemPrice.text = itemDatabase.items[i].itemPrice.ToString();
                newInventoryItem.GetComponent<Item>().isPurchased = true;
                itemList.Add(newInventoryItem);

                switch (newInventoryItem.GetComponent<Item>().itemType)
                {
                    case ItemType.Headwear:
                        newInventoryItem.transform.SetParent(itemHolderA.transform, false);
                        break;
                    case ItemType.Tops:
                        newInventoryItem.transform.SetParent(itemHolderB.transform, false);
                        break;
                    case ItemType.Shoes:
                        newInventoryItem.transform.SetParent(itemHolderC.transform, false);
                        break;
                }
                break;
            }
        }
    }
}
