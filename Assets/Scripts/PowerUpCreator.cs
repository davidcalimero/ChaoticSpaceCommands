using UnityEngine;
using System.Collections;

public class PowerUpCreator : MonoBehaviour {

	// Use this for initialization
	public GameObject Powerup;
	public float respawntime = 5;
	void Start () {
		StartCoroutine("PowerUpShare");
	}

	IEnumerator PowerUpShare(){
		if (GameObject.FindGameObjectWithTag("Powerup") == null){
			Instantiate(Powerup, new Vector2(Random.Range(-28F,25F), Random.Range(-0.5F,-28F)), Quaternion.identity);
		}

		yield return new WaitForSeconds(respawntime);
		StartCoroutine("PowerUpShare");
	
	}

}
