using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [Header("Components")]
    [HideInInspector]
    public ItemDatabase.Items item;
    public GameObject playerInventory;
    [Header("Values")]
    public int itemId;
    public ItemType itemType;
    [Header("UI Components")]
    public Text itemName;
    public Image itemIcon;
    public Text itemPrice;
    public Button itemBuyButton;
    public Button itemSellButton;
    public Button itemEquipButton;
    [Header("Bools")]
    public bool isPurchased;
    public bool isEquipped;

    private void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory");
        itemBuyButton.onClick.AddListener(BuyItem);
        itemSellButton.onClick.AddListener(SellItem);
    }

    private void Update()
    {
        CheckIfItemIsPurchased();
    }

    private void BuyItem()
    {
        playerInventory.GetComponent<PlayerInventory>().AddItemToInventory(itemId);
    }

    private void SellItem()
    {
        playerInventory.GetComponent<PlayerInventory>().itemList.Remove(gameObject);
        Destroy(gameObject);

    }
    
    private void CheckIfItemIsPurchased()
    {
        if(isPurchased)
        {
            itemBuyButton.gameObject.SetActive(false);
            itemSellButton.gameObject.SetActive(true);
        }
        else
        {
            itemBuyButton.gameObject.SetActive(true);
            itemSellButton.gameObject.SetActive(false);
        }
    }
}
    
