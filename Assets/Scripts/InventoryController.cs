using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour {

  public GameObject inventorySlot;
  public GameObject inventoryItem;
  public int slotAmount;
  static Canvas canvas;
  static bool isInventoryOpen = false;
  GameObject inventoryPanel;
  GameObject slotPanel;
  List<GameObject> slots = new List<GameObject>();
  List<Item> items = new List<Item>();
  ItemFactory itemFactory;
  
  void Start()
  {
    transform.localPosition = Vector3.zero;
    transform.localScale = Vector3.one;
    itemFactory = ItemFactory.getInstance();
    canvas = GetComponent<Canvas>();
    inventoryPanel = this.transform.FindChild("Inventory Panel").gameObject;
    slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
    for(int i=0; i < slotAmount; i++)
    {
      items.Add(new Item());
      slots.Add(Instantiate(inventorySlot));
      slots[i].transform.GetComponent<Slot>().Id = i+2;
      slots[i].transform.SetParent(slotPanel.transform,true);
    }
    AddItem(itemFactory.getItemInstance(1));
    AddItem(itemFactory.getItemInstance(1));
  }
  
  private void AddItem(GameObject item)
  {
    for(int i=0; i<slotAmount; i++)
    {
      if (items[i].IsEmpty())
      {
        inventoryItem = itemFactory.getObjectInstance();
        items[i] = item.transform.GetComponent<Item>();
        items[i].slotID = i;
        slots[i].transform.GetComponent<Slot>().isEmpty = false;
        GameObject itemObj = item;
        itemObj.transform.SetParent(slots[i].transform);
        itemObj.transform.position = slots[i].transform.position;
        itemObj.GetComponent<Image>().sprite = itemFactory.getItemSprite();
        //itemObj.transform.localScale = new Vector3(item.Scale, item.Scale, 1);
        return;
      }
    }
  }

static public void OpenInventory()
  {
    canvas.planeDistance = 2;
    isInventoryOpen = true;

  }

static public void CloseInventory()
  {
    if (isInventoryOpen)
    {
      canvas.planeDistance = 0;
      isInventoryOpen = false;
    }
  }
}
