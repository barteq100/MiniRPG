using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
  public int slotID;
  protected float scale = 1;
  public float Scale { get
    {
      return scale;
    }
  }

  public int Vitality
  {
    get
    {
      return vitality;
    }

    set
    {
      vitality = value;
    }
  }

  public int Agility
  {
    get
    {
      return agility;
    }

    set
    {
      agility = value;
    }
  }

  public int Strength { get
    {
      return strength;
    }

    set
    {
      strength = value;
    }
  }
  protected int id;
  protected string itemName;
  protected int damage;
  protected int strength;
  protected int agility;
  protected int vitality;
  protected int rarity;
  public Transform originalParent;
  static protected Sprite sprite;
  protected bool isEqipped = false;
 


  public Item()
  {
    id = -1;    
  }
 
  public Item(int id)
  {
    this.id = id;
  }

  public void SetStats(int vit, int str, int agi)
  {
    Vitality = vit;
    Strength = str;
    Agility = agi;
  }

  public bool IsEmpty()
  {
    if(this.id==-1) return true;
    return false;
  }

  //virtual public Sprite getSprite()
  //{
  //  return sprite;
  //}
  
  virtual public void Equip()
  {
    PlayerController.EquipItem(this);
    this.isEqipped = true;
  }
  virtual public void UnEquip()
  {
    PlayerController.UnEquipItem(this);
    this.isEqipped = false;
  }
  static public Sprite getSprite()
  {
    return sprite;
  }

  public void OnBeginDrag(PointerEventData eventData)
  {
    originalParent = this.transform.parent;
    this.transform.SetParent(this.transform.parent.parent.parent.parent.parent);
    Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    pz.z = 0;
    this.transform.position = pz;
    this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    if (isEqipped)
    {
      UnEquip();
    }
  }

  public void OnDrag(PointerEventData eventData)
  {
    Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    pz.z = 0;
    this.transform.position = pz;
  }

  public void OnEndDrag(PointerEventData eventData)
  {
    if (!transform.parent.GetComponent<Slot>()) 
    {
      this.transform.SetParent(originalParent);
      this.transform.position = originalParent.position;
    }
    this.GetComponent<CanvasGroup>().blocksRaycasts = true;
  }
}
