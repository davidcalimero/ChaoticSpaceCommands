using UnityEngine;
using System.Collections;

public class ShipControllerScript : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate(new Vector3(0,0,1));
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate(new Vector3(0,0,-1));
		}
		if (Input.GetKey (KeyCode.W)) {
			Debug.Log ("Come On!");
			transform.position += transform.forward;
			anim.SetBool ("accelerate", true);
		} else
			anim.SetBool ("accelerate", false);

	}
}
