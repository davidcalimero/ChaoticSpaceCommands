using UnityEngine;
using System.Collections;

public class PowerUpCreator : MonoBehaviour {

	// Use this for initialization
	public GameObject Powerup;
	public float respawntime = 2000;
	void Start () {
		StartCoroutine("PowerUpShare");
	}

	IEnumerator PowerUpShare(){
		if (GameObject.FindGameObjectWithTag("Powerup") == null){
			Instantiate(Powerup, new Vector2(Random.Range(-2.4F,2.4F),Random.Range(-1.4F,1.4F)),Quaternion.identity);
		}

		yield return new WaitForSeconds(respawntime);
		StartCoroutine("PowerUpShare");
	
	}

}
