using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

	private int _life;

	// Use this for initialization
	void Start () {
		_life = 100;
	}

	public void affectLife(int newAmmount){
		_life += newAmmount;
	}
	
	// Update is called once per frame
	void Update () {
		if (_life <= 0)
			Destroy (this.gameObject);
	}

	void OnGUI () {
		Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		screenPosition.y = Screen.height - screenPosition.y; // the GUI coordinate system is upside down relative to every other coordinate system

		Rect currentLifeBar = new Rect (screenPosition.x - 0.5f, screenPosition.y - 1, Utils.minMaxNormalization(_life, 0, 100, 0, 5), 1);

		Texture2D currentLifeTexture = new Texture2D (_life, 10);
		for (int x = 0; x < currentLifeTexture.width; x++)
			for (int y = 0; y < currentLifeTexture.height; y++)
				currentLifeTexture.SetPixel (x, y, new Color((100 - _life)/100, _life / 100, 0));
		currentLifeTexture.Apply ();
		GUI.Label(currentLifeBar, currentLifeTexture);
		//GUI.Label(new Rect(10, 40, currentLifeTexture.width, currentLifeTexture.height), currentLifeTexture);
	}
}
