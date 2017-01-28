using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler {
  public int Id;
  public bool isEmpty = true;

  public void OnDrop(PointerEventData eventData)
  {
    Item dropedItem = eventData.pointerDrag.GetComponent<Item>();
    
    if (isEmpty)
    {
      
      dropedItem.transform.SetParent(this.transform);
      dropedItem.transform.position = this.transform.position;
      dropedItem.slotID = this.Id;
      dropedItem.originalParent.GetComponent<Slot>().isEmpty = true;
    }
    else
    {
      dropedItem.transform.SetParent(dropedItem.originalParent);
      dropedItem.transform.position = dropedItem.originalParent.position;
    }
  }

}
