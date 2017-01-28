using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Weapon : Item{
  public Weapon(int vit, int str, int agi)
  {
    Vitality = vit;
    Strength = str;
    Agility = agi;
    scale = 0.25f;
    id = 1;
  }

    void Awake()
  {
 
    sprite = GetComponent<Image>().sprite;
  }

}
