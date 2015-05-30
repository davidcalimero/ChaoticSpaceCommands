using UnityEngine;
using System.Collections;

//defines action for the move forward button press
public class PlayerMoveButton : RandomButton {

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (_key)) {
			//this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10);
			transform.Translate(new Vector3(0,0.01f,0f));
		}
	}

}
