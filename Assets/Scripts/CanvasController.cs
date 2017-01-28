using UnityEngine;
using System.Collections;

public class CanvasController : MonoBehaviour {
  static Canvas canvas;
  static bool isInventoryOpen = false;
  static GameObject gameOver;
  // Use this for initialization
  void Start () {
    canvas = GetComponent<Canvas>();
    gameOver = transform.FindChild("GameOver").gameObject;
  }

  static public void OpenInventory()
  {
    canvas.planeDistance = 2;
    isInventoryOpen = true;

  }
  static public void GameOver()
  {
    gameOver.transform.position += new Vector3(0,0,11f);
    OpenInventory();
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
