using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {


  public Transform target;

  void OnTriggerEnter2D(Collider2D other)
  {
    other.gameObject.transform.position = target.position;

  }
}
