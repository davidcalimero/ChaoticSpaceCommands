using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	public string epictext = "Oh My GoD!!!";

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			other.gameObject.transform.parent.GetComponent<DisplayCombatText>().displayCombatText(this.name);
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
