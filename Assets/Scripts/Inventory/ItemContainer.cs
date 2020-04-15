using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemContainer : MonoBehaviour, IDropHandler
{
    public bool isPlayerInventory;

    public void OnDrop(PointerEventData eventData)
    {
        DragItem dragItem = eventData.pointerDrag.GetComponent<DragItem>();
        dragItem.currentHolder = gameObject.transform;

        if(dragItem.currentHolder == dragItem.currentHolder.GetComponent<ItemContainer>().isPlayerInventory)
        {
            dragItem.GetComponent<Item>().isPurchased = true;
            dragItem.GetComponent<Item>().BuyItem();
        }
        else if (dragItem.currentHolder == !dragItem.currentHolder.GetComponent<ItemContainer>().isPlayerInventory)
        {
            dragItem.GetComponent<Item>().isPurchased = false;
            dragItem.GetComponent<Item>().SellItem();
        }
    }
}
