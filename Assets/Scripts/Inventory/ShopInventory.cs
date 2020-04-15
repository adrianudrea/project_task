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
    public GameObject itemHolderA;
    public GameObject itemHolderB;
    public GameObject itemHolderC;
    [Header("Shop List")]
    public List<GameObject> itemList = new List<GameObject>();

    private void Start()
    {
        AddItemsToStore(0);
        AddItemsToStore(1);
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
                itemList.Add(newStoreItem);

                switch (newStoreItem.GetComponent<Item>().itemType)
                {
                    case ItemType.Headwear:
                        /* breaks unity
                        for(int x = 0; x < itemHolderA.GetComponent<SlotList>().slotList.Count; i++)
                        {
                            itemHolderA.GetComponent<SlotList>().slotList[x].GetComponent<ItemSlot>().slotId = x;
                            itemHolderA.GetComponent<SlotList>().slotList[x].GetComponent<ItemSlot>().isEmpty = false;
                            newStoreItem.transform.SetParent(itemHolderA.GetComponent<SlotList>().slotList[x].transform, false);
                        }
                        */
                        break;
                    case ItemType.Tops:
                        newStoreItem.transform.SetParent(itemHolderB.transform, false);
                        break;
                    case ItemType.Shoes:
                        newStoreItem.transform.SetParent(itemHolderC.transform, false);
                        break;
                }
                break;
            }
        }
    }
}
