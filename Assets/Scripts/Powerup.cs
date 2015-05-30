using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	public string effect;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			other.gameObject.transform.parent.GetComponent<DisplayCombatText>().displayCombatText(effect);
			Destroy(gameObject);
		}
	}

	public void setEffect (string effect){
		this.effect = effect;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
