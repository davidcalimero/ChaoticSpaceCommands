using UnityEngine;
using System.Collections;

//set's the two rotation keys for the space ships and makes it rotate in fixed update
public class PlayerRotation : MonoBehaviour {

	public float rotationAngle = 5.0f;

	private string _rotateLeft; //button rotates ship to the left
	private string _rotateRight; //button rotates ship to the right

	// Use this for initialization
	void Start () {
		if(this.gameObject.name.Equals("Player 1")){
			_rotateLeft = "a";
			_rotateRight = "z";
		}else if(this.gameObject.name.Equals("Player 2")){
			_rotateLeft = "l";
			_rotateRight = "p";
		}else if(this.gameObject.name.Equals("Player 3")){
			_rotateLeft = "v";
			_rotateRight = "b";
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (_rotateLeft))
			transform.Rotate (Vector3.forward, rotationAngle);
		if (Input.GetKey (_rotateRight))
			transform.Rotate (Vector3.forward, rotationAngle);
	}
}
