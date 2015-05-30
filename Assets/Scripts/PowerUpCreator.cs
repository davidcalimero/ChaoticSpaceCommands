using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpCreator : MonoBehaviour {

	List<string> _effects = new List<string>(){"star", "heal"};

	// Use this for initialization
	public GameObject Powerup;
	public float respawntime = 5;
	void Start () {
		StartCoroutine("PowerUpShare");
	}

	IEnumerator PowerUpShare(){
		if (GameObject.FindGameObjectWithTag("Powerup") == null){

			GameObject a1 = GameObject.Find("sudoAnchorTop");
			GameObject a2 = GameObject.Find("sudoAnchorBottom");

			float x1 = a1.transform.position.x;
			float y1 = a1.transform.position.y;

			float x2 = a2.transform.position.x;
			float y2 = a2.transform.position.y;


			GameObject o = (GameObject) Instantiate(Powerup, new Vector2(Random.Range(x2,x1), Random.Range(y2,y1)), Quaternion.identity);

			o.GetComponent<Powerup>().setEffect(_effects[Random.Range(0, 2)]);
		}

		yield return new WaitForSeconds(respawntime);
		StartCoroutine("PowerUpShare");
	
	}

}
