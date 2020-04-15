using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [Header("Components")]
    [HideInInspector]
    public ItemDatabase.Items item;
    public GameObject shopInventory;
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
    [Header("Bools")]
    public bool isPurchased;

    private void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory");
        shopInventory = GameObject.FindGameObjectWithTag("ShopInventory");

        ButtonFunctionality();
    }

    private void Update()
    {
        CheckIfItemIsPurchased();
    }

    private void ButtonFunctionality()
    {
        itemBuyButton.onClick.AddListener(BuyItem);
        itemSellButton.onClick.AddListener(SellItem);
    }

    public void BuyItem()
    {
        shopInventory.GetComponent<ShopInventory>().itemList.Remove(gameObject);
        Destroy(gameObject);
        playerInventory.GetComponent<PlayerInventory>().AddItemToInventory(itemId);
    }

    public void SellItem()
    {
        playerInventory.GetComponent<PlayerInventory>().itemList.Remove(gameObject);
        Destroy(gameObject);
        shopInventory.GetComponent<ShopInventory>().AddItemsToStore(itemId);
        
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
    
