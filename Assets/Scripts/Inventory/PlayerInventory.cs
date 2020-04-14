using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("List")]
    public List<GameObject> itemList = new List<GameObject>();
    [Header("Item Container")]
    public GameObject itemHolderA;
    public GameObject itemHolderB;
    public GameObject itemHolderC;

    private void Update()
    {
        
    }

    public void AssignItem()
    {
        foreach (GameObject item in itemList)
        {
            switch (item.GetComponent<Item>().itemType)
            {
                case ItemType.Headwear:
                    item.transform.SetParent(itemHolderA.transform, false);
                    break;
                case ItemType.Tops:
                    item.transform.SetParent(itemHolderB.transform, false);
                    break;
                case ItemType.Shoes:
                    item.transform.SetParent(itemHolderC.transform, false);
                    break;
            }
        }
        return;
    }
}
