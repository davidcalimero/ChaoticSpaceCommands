using UnityEngine;
using System.Collections;

//defines action for the move forward button press
public class PlayerMoveButton : RandomButton {

	public GameObject animator;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (_key)) {
			transform.Translate (new Vector3 (0, 0.01f, 0f));
			animator.SendMessage ("Accelerate", SendMessageOptions.DontRequireReceiver);
		}
		else
			animator.SendMessage("Decelerate", SendMessageOptions.DontRequireReceiver);
	}
}
