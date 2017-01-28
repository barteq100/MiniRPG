using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {
  GameObject credits;
  float period = 0f;
	// Use this for initialization
	void Start () {
	credits = transform.FindChild("Credits").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
    period += Time.deltaTime;
    if (period > 4f)
    {
      credits.SetActive(true);
      period = 0;
    }
  }
}
