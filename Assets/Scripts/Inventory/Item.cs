using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [Header("Components")]
    public GameObject itemPrefab;
    public GameObject playerInventory;
    [Header("Values")]
    public int itemId;
    public ItemType itemType;
    [Header("UI Components")]
    public Text itemName;
    public Image itemIcon;
    public Text itemPrice;
    public Button itemBuyButton;
    [Header("Bools")]
    public bool isPurchased;

    private void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory");
        itemBuyButton.onClick.AddListener(BuyItem);
    }

    private void BuyItem()
    {
        GameObject newItem = gameObject;
        newItem = Instantiate(newItem);
        playerInventory.GetComponent<PlayerInventory>().itemList.Add(newItem);
        playerInventory.GetComponent<PlayerInventory>().AssignItem();
    }
}
