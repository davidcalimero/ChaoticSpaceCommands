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

			GameObject a1 = GameObject.Find("sudoAnchorTop");
			GameObject a2 = GameObject.Find("sudoAnchorBottom");

			float x1 = a1.transform.position.x;
			float y1 = a1.transform.position.y;

			float x2 = a2.transform.position.x;
			float y2 = a2.transform.position.y;


			Instantiate(Powerup, new Vector2(Random.Range(x2,x1), Random.Range(y2,y1)), Quaternion.identity);
		}

		yield return new WaitForSeconds(respawntime);
		StartCoroutine("PowerUpShare");
	
	}

}
