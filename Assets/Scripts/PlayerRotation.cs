using UnityEngine;
using System.Collections;

//set's the two rotation keys for the space ships and makes it rotate in fixed update
public class PlayerRotation : MonoBehaviour {

	public float torqueForce = 60.0f;

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
	void Update () {
		//TODO: add interval to add torque, like every 0.5 seconds, until a max or something
		if (Input.GetKey (_rotateLeft))
			GetComponent<Rigidbody2D> ().AddTorque (torqueForce);
		if (Input.GetKey (_rotateRight))
			GetComponent<Rigidbody2D> ().AddTorque (-torqueForce);
	}
}
