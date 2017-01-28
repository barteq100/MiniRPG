using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquipmentController : InventoryController {

  static Canvas canvas;
  static bool isInventoryOpen = false;
  private GameObject inventoryPanel;
  private GameObject slotPanel;
  GameObject ArmorSlot;
  GameObject WeaponSlot;
  List<GameObject> slots = new List<GameObject>();
  Item weapon;
  Item armor;
  ItemFactory itemFactory;

  void Start()
  {
    transform.localPosition = Vector3.zero;
    transform.localScale = Vector3.one;
    slotAmount = 2;
    itemFactory = ItemFactory.getInstance();
    canvas = GetComponent<Canvas>();
    inventoryPanel = this.transform.FindChild("Inventory Panel").gameObject;
    slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
    ArmorSlot = slotPanel.transform.FindChild("ArmorSlot").gameObject;
    slots.Add(ArmorSlot);
    WeaponSlot = slotPanel.transform.FindChild("WeaponSlot").gameObject;
    slots.Add(WeaponSlot);
  }

  static public new void OpenInventory()
  {
    canvas.planeDistance = 1;
    isInventoryOpen = true;

  }
  static public new void CloseInventory()
  {
    if (isInventoryOpen)
    {
      canvas.planeDistance = 0;
      isInventoryOpen = false;
    }
  }

}
 
