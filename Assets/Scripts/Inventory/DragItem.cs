using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Transform currentHolder;

   public void OnBeginDrag(PointerEventData evenData)
    {
        currentHolder = transform.parent;
        transform.SetParent(transform.parent.parent.parent);
        transform.position = evenData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(currentHolder);
        transform.position = currentHolder.transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}

