using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemFactory : MonoBehaviour {

  private Item item;
  private GameObject i;
  public GameObject armor;
  public GameObject weapon;
  Sprite sprite;
  static ItemFactory instance;

  private ItemFactory(GameObject armor, GameObject weapon)
  {
    this.armor = armor;
    this.weapon = weapon;
  }

  private ItemFactory() { }

 static public ItemFactory getInstance()
  {
    return instance;
  }

  void Awake(){
    armor = GameObject.Find("Armor");
    weapon = GameObject.Find("Weapon");
    instance = new ItemFactory(armor, weapon);
  }

  public Item makeItem(int type)
  {
    int vit = Random.Range(0, 4);
    int str = Random.Range(0, 4);
    int agi = Random.Range(0, 4);
    if(type == 1)
    {
      item = new Weapon(vit,str,agi);
      i = weapon;
      Item iStats = i.transform.GetComponent<Weapon>();
      iStats.Vitality = item.Vitality;
      iStats.Strength = item.Strength;
      iStats.Agility = item.Agility;
      sprite = Weapon.getSprite();
    }
    else
    {
      item = new Armor(vit,str,agi);
      i = armor;
      Item iStats = i.transform.GetComponent<Armor>();
      iStats.Vitality = item.Vitality;
      iStats.Strength = item.Strength;
      iStats.Agility = item.Agility;
      sprite = Armor.getSprite();
    }
    return item;
  }

  public GameObject getItemInstance(int type)
  {
    int vit = Random.Range(0, 4);
    int str = Random.Range(0, 4);
    int agi = Random.Range(0, 4);
    if (type == 1)
    {
      item = new Weapon(vit, str, agi);
      i = Instantiate(weapon);
      i.transform.GetComponent<Weapon>().SetStats(vit, str, agi);
      sprite = Weapon.getSprite();
    }
    else
    {
      item = new Armor(vit, str, agi);
      i = Instantiate(weapon);
      i.transform.GetComponent<Armor>().SetStats(vit, str, agi);
      sprite = Armor.getSprite();
    }
    return i;
  }
  public GameObject getObjectInstance()
  {
   
    return i;
  }
  public Sprite getItemSprite()
  {
    return sprite;
  }
}
