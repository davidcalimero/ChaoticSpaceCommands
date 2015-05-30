using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Powerup")) {
			Debug.Log("Powerup touched");
			Destroy(other.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
