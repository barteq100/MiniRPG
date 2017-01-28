using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Armor : Item {

  public Armor(int vit, int str, int agi)
  {
    id = 2;
    vitality = vit;
    strength = str;
    agility = agi;
  }

  void Awake()
  { 
    sprite = GetComponent<Image>().sprite;
  }

}
