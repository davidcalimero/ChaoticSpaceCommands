using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	public string epictext = "Oh My GoD!!!";

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			Debug.Log("Powerup touched");
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
