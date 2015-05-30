using UnityEngine;
using System.Collections;

//defines action for the move forward button press
public class PlayerMoveButton : RandomButton {

	public float forwardForce = 100.0f;
	public GameObject animator;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (_key)) {
			GetComponent<Rigidbody2D>().AddForce(transform.up * forwardForce);
			animator.SendMessage ("Accelerate", SendMessageOptions.DontRequireReceiver);
		}
		else
			animator.SendMessage("Decelerate", SendMessageOptions.DontRequireReceiver);
	}
}
