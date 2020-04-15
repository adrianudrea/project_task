using UnityEngine;
using UnityEngine.UI;

public class ShopSorter : MonoBehaviour
{
    [Header("Components")]
    public ShopInventory shopInventory;
    [Header("Buttons")]
    public Button sortAButton;
    public Button sortBButton;
    public Button sortCButton;

    private void Start()
    {
        shopInventory = gameObject.GetComponent<ShopInventory>();

        SortA();
    }

    private void Update()
    {
        ButtonFunctionality();
    }

    private void SortA() { Sort(ItemType.Headwear); }
    private void SortB() { Sort(ItemType.Tops);     }
    private void SortC() { Sort(ItemType.Shoes);    }
  

    private void ButtonFunctionality()
    {
        sortAButton.onClick.AddListener(SortA);
        sortBButton.onClick.AddListener(SortB);
        sortCButton.onClick.AddListener(SortC);
    }


    public void Sort(ItemType itemType)
    {
        for (int i = 0; i < shopInventory.itemList.Count; i++)
        {
            if (shopInventory.itemList[i].GetComponent<Item>().itemType == itemType)
            {
                shopInventory.itemList[i].GetComponent<Item>().gameObject.SetActive(true);
            }
            else
            {
                shopInventory.itemList[i].GetComponent<Item>().gameObject.SetActive(false);
            }
        }
    }
}
