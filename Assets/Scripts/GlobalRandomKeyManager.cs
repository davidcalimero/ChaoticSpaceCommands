using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//controls the random keys of all the players as a server
public class GlobalRandomKeyManager : MonoBehaviour {

	public float _randomKeyTimeout = 10.0f; //timer controls how often new random keys are generated

	public List<Component> _buttons = new List<Component>(); //contains all the buttons registered to receive random keys

	private List<string> _possibleKeys; //keyboard keys allowed
	private int _possibleKeysLenght;

	//after _randomKeyTimeout time, assigns new unused random key for the registered buttons
	IEnumerator renewRandomKeys(){
		foreach (Component button in _buttons) {
			string previousKey = ((RandomButton)button).getCurrentKey();
			((RandomButton)button).setRandomKey(getUnusedRandomKey(previousKey));
		}
		yield return new WaitForSeconds(_randomKeyTimeout);
		StartCoroutine ("renewRandomKeys");
	}

	//allows for buttons to register with this globl class, in order to receive random keys
	public void registerButton(Component newButton){
		if(!_buttons.Contains(newButton)){
			_buttons.Add(newButton);
			//Debug.Log (newButton.name + " registered!");
		}
	}

	//returns an unused key, adding the previous one to the list of available keys
	private string getUnusedRandomKey(string previousKey){
		if (!_possibleKeys.Contains (previousKey))
			_possibleKeys.Add (previousKey);
		int randIndex = Random.Range (0, _possibleKeysLenght);

		string ret = _possibleKeys[randIndex].ToString();
		_possibleKeys.RemoveAt (randIndex);
		return ret;
	}

	void Start () {
		_possibleKeys = new List<string>(new string[] {"1","2","3","4","5","6","7","8","9","0","c","d","e","f","g","h","i","j","k","m","n","o","q","r","s","t","u","w","x","y"});
		_possibleKeysLenght = _possibleKeys.Count;
		//Debug.Log (_possibleKeys.Count + " size");

		StartCoroutine("renewRandomKeys");
	}
}
