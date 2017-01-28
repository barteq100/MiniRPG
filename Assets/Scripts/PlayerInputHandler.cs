using UnityEngine;
using System.Collections;

public class PlayerInputHandler : MonoBehaviour {
  
  Rigidbody2D body;
  Animator anim;
  private float speed;
  static PlayerInputHandler handler;
  private bool isInventoryOpen = false;
  static Transform t;
  // Use this for initialization
  void Start() {
    handler = this;
    body = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    t = GetComponent<Transform>();
  }

  // Update is called once per frame
  void Update() {
    speed = PlayerController.Agility;
    Vector2 movementV = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    
    if (movementV != Vector2.zero)
    {
      anim.SetBool("isWalking", true);
      anim.SetFloat("input_x", movementV.x);
      anim.SetFloat("input_y", movementV.y);
    }
    else
    {
      anim.SetBool("isWalking", false);
    }
    body.MovePosition(body.position + (movementV * 100) * Time.deltaTime * speed);

    if (Input.GetKeyDown(KeyCode.I)) {
      if (isInventoryOpen == false)
      {
        //InventoryController.OpenInventory();
        //EquipmentController.OpenInventory();
        CanvasController.OpenInventory();
        isInventoryOpen = true;
        Time.timeScale = 0;
      }
     else if (isInventoryOpen == true)
      {
        //InventoryController.CloseInventory();
        //EquipmentController.CloseInventory();
        CanvasController.CloseInventory();
        isInventoryOpen = false;
        Time.timeScale = 1;
      }
    }
  }
  private PlayerInputHandler() { }
  public static PlayerInputHandler getPlayerHandler()
  {
    return handler;
  }

  public void setPlayerPositon(Transform t)
  {
    transform.position = t.position;
  }
 
}

