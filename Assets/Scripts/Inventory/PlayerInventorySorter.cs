using UnityEngine;
using UnityEngine.UI;

public class PlayerInventorySorter : MonoBehaviour
{
    [Header("Components")]
    public PlayerInventory playerInventory;
    [Header("Buttons")]
    public Button sortAButton;
    public Button sortBButton;
    public Button sortCButton;

    private void Start()
    {
        playerInventory = gameObject.GetComponent<PlayerInventory>();
       
        SortA();
    }

    private void Update()
    {
        ButtonFunctionality();
    }

    private void SortA() { Sort(ItemType.Headwear); }
    private void SortB() { Sort(ItemType.Tops); }
    private void SortC() { Sort(ItemType.Shoes); }


    private void ButtonFunctionality()
    {
        sortAButton.onClick.AddListener(SortA);
        sortBButton.onClick.AddListener(SortB);
        sortCButton.onClick.AddListener(SortC);
    }


    public void Sort(ItemType itemType)
    {
        for (int i = 0; i < playerInventory.itemList.Count; i++)
        {
            if (playerInventory.itemList[i].GetComponent<Item>().itemType == itemType)
            {
                playerInventory.itemList[i].GetComponent<Item>().gameObject.SetActive(true);
            }
            else
            {
                playerInventory.itemList[i].GetComponent<Item>().gameObject.SetActive(false);
            }
        }
    }
}
