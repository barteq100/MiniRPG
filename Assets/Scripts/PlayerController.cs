using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
  static private int health = 10;
  static public int Health {
    get { return health; }
    set { health = value;
    if(health <= 0)
      {
        Debug.Log("Game Over");
        /*
        CanvasController.GameOver();
        Time.timeScale = 0;
        */
        SceneManager.LoadScene("GameOverScene");
      
      }
        } 
    }

  static private int strenght = 1;
  static public int Strength
  {
    get { return strenght; }
    set { strenght = value; }
  }

  static private int agility = 1;
  static public int Agility {
    get { return agility; }
    set { agility = value; }
  }
  private PlayerController() { }

  static public void EquipItem(Item item)
  {
    health += item.Vitality * 10;
    strenght += item.Strength;
    agility += item.Agility;
  }

  static public void UnEquipItem(Item item)
  {
    health -= item.Vitality * 10;
    strenght -= item.Strength;
    agility -= item.Agility;
  }

}
