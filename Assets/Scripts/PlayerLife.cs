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
}
