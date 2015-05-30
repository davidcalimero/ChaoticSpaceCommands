using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	bool paused = false;
	bool gameFinished = false;
	string winner = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape))
			paused = true;
        GameObject[] objects = GameObject.FindGameObjectsWithTag ("Player");
        if (objects.Length == 2) {
			gameFinished = true;
            winner = objects[0].name;
            if (objects[1].name != "Body")
                winner = objects[1].name;
		}
	}

	void OnGUI(){
		if (gameFinished) {
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
			GUI.Label(new Rect(Screen.width * 0.5f - Screen.width / 10.0f, Screen.height * 0.45f, Screen.width / 5.0f, Screen.height * 0.15f), winner + " has won the game! :)");
			if(GUI.Button(new Rect(Screen.width * 0.5f - Screen.width / 6.0f, Screen.height * 0.5f, Screen.width / 3.0f, Screen.height * 0.15f), "Play Again"))
				Application.LoadLevel("mainScene");
			if(GUI.Button(new Rect(Screen.width * 0.5f - Screen.width / 6.0f, Screen.height * 0.7f, Screen.width / 3.0f, Screen.height * 0.15f), "Back To Main Menu"))
				Application.LoadLevel ("Main Menu");
		} else if (paused) {
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Game Paused");
			if(GUI.Button(new Rect(Screen.width * 0.5f - Screen.width / 6.0f, Screen.height * 0.5f, Screen.width / 3.0f, Screen.height * 0.15f), "Back To Game"))
				paused = false;
			if(GUI.Button(new Rect(Screen.width * 0.5f - Screen.width / 6.0f, Screen.height * 0.7f, Screen.width / 3.0f, Screen.height * 0.15f), "Exit To Main Menu"))
				Application.LoadLevel ("Main Menu");
		}
	}
}
