using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

  Rigidbody2D body;
  Animator anim;
  private float MoveSpeed = 1;
  private int attack = 5;
  Transform Player;
  int MaxDist = 10;
  int MinDist = 20;
  private float period = 0f;
  // Use this for initialization
  void Start()
  {
    body = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
   
  }

  // Update is called once per frame
  void Update()
  {
    //TODO Enemy AI
    Player = PlayerInputHandler.getPlayerHandler().transform;
    Vector3 diff = Player.position - transform.position;
    diff.Normalize();

    float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    Vector2 movementV = new Vector2(diff.x, diff.y);
    if (movementV != Vector2.zero)
    {
      
      anim.SetFloat("Rotation",Mathf.Abs(rot_z));
    }
    else
    {
      anim.SetBool("isWalking", false);
    }

    period += Time.deltaTime;
    if ((int)period % 1000 == 0) MoveSpeed += 0.001f;
    if (Vector3.Distance(transform.position, Player.position) >= MinDist)
      body.MovePosition(body.position + (new Vector2(diff.x, diff.y)* 100) * Time.deltaTime * MoveSpeed);
    else
    {
      if (period > 1.0f)
      {
        attackPlayer();
        period = 0;
      }
    }

  }
    private void attackPlayer()
  {
    PlayerController.Health -= this.attack;
    Debug.Log("attacking");
  }
  
  }


