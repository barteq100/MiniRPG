using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ArmorSlot : Slot, IDropHandler
{
  int Id = 0;
  public new void OnDrop(PointerEventData eventData)
  {
    Item dropedItem = eventData.pointerDrag.GetComponent<Item>();

    if (isEmpty && dropedItem.transform.GetComponent<Armor>())
    {
      dropedItem.transform.SetParent(this.transform);
      dropedItem.transform.position = this.transform.position;
      dropedItem.slotID = this.Id;
      dropedItem.originalParent.GetComponent<Slot>().isEmpty = true;
      dropedItem.Equip();
    }
    else
    {
      dropedItem.transform.SetParent(dropedItem.originalParent);
      dropedItem.transform.position = dropedItem.originalParent.position;
    }
  }

}

