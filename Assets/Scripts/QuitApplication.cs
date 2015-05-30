using UnityEngine;
using System.Collections;

public class QuitApplication : MonoBehaviour {

	// Use this for initialization
	void byebye () {
		Debug.Log ("Been here");
		Application.Quit();
	}

}
