using UnityEngine;
using System.Collections;

public class CamerFollow : MonoBehaviour {

  public Transform target;
  private Camera myCam;
	// Use this for initialization
	void Start () {
    myCam = GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update () {
    myCam.orthographicSize = (Screen.height ) / 2f;

    if (target)
    {
      //  transform.position = Vector3.Lerp(transform.position ,target.position, 0.1f) + new Vector3(0,0,-10);
      transform.position = new Vector3(target.position.x, target.position.y,target.position.z - 10f);
    }
	}
}
