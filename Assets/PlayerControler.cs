using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

	public string walkButton;
	public string fireButton;
	public float waitTime = 1000;

	private string characters = "abcdefghijklmnopqrstuvwxyz";

	// Use this for initialization
	void Start () {
		StartCoroutine("generateKeys");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (walkButton)) {
			//this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10);
			transform.Translate(new Vector3(0,0.01f,0f));
			Debug.Log ("WALK");
		}
		if (Input.GetKey(fireButton))
			Debug.Log("FIRE");
	}

	IEnumerator generateKeys(){
		int num1 = Random.Range (0, 25);
		walkButton = characters[num1].ToString();
		int num2 = num1;
		while(num2 == num1){
			num2 = Random.Range (0, 25);
		}
		fireButton = characters[num2].ToString();
		yield return new WaitForSeconds(waitTime);
		StartCoroutine ("generateKeys");
	}
}