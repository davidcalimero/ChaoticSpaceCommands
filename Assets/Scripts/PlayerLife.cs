using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

	private int _life;
    public int maxLife = 100;

	// Use this for initialization
	void Start () {
        _life = maxLife;
	}

	public void affectLife(int newAmmount){
		_life += newAmmount;
        if (_life > maxLife) _life = maxLife;
	}
	
	// Update is called once per frame
	void Update () {
		if (_life <= 0) {
			GameObject.Find ("Explosion").GetComponent<AudioSource>().Play();
			Destroy (this.gameObject);
		}
	}

	void OnGUI () {	
		Texture2D currentLifeTexture = new Texture2D (100, 10);
		for (int x = 0; x < currentLifeTexture.width; x++)
			for (int y = 0; y < currentLifeTexture.height; y++){
			if(y == 0 || y == 9 || x == 99) currentLifeTexture.SetPixel (x, y, new Color(1,1,1,1));
				else if(x > _life) currentLifeTexture.SetPixel (x, y, new Color(0,0,0,0));
				else {
					if(gameObject.name.Equals("Player 1"))
						currentLifeTexture.SetPixel (x, y, Utils.CreateColor(x, 1, 209, 229));
					if(gameObject.name.Equals("Player 2"))
						currentLifeTexture.SetPixel (x, y, Utils.CreateColor(x, 176, 0, 181));
					if(gameObject.name.Equals("Player 3"))
						currentLifeTexture.SetPixel (x, y, Utils.CreateColor(x, 180, 212, 85)); 
				}
			}
		currentLifeTexture.Apply ();
		if(gameObject.name.Equals("Player 1"))
			GUI.DrawTexture (new Rect (Screen.width * 0.0625f, Screen.height * 0.05f, Screen.width * 0.25f, Screen.height * 0.05f), currentLifeTexture);
		if(gameObject.name.Equals("Player 2"))
			GUI.DrawTexture (new Rect (Screen.width * 0.375f, Screen.height * 0.05f, Screen.width * 0.25f, Screen.height * 0.05f), currentLifeTexture);
		if(gameObject.name.Equals("Player 3"))
			GUI.DrawTexture (new Rect (Screen.width * 0.6875f, Screen.height * 0.05f, Screen.width * 0.25f, Screen.height * 0.05f), currentLifeTexture);
	}
}
