using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	public string effect;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			other.gameObject.transform.parent.GetComponent<DisplayCombatText>().displayCombatText(effect);
			switch(effect){
				case "star":
					other.gameObject.transform.parent.SendMessage("StarFire", SendMessageOptions.DontRequireReceiver);
					break;
				case "heal":
					other.gameObject.transform.parent.SendMessage("affectLife", 40, SendMessageOptions.DontRequireReceiver);
					break;
			}

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
