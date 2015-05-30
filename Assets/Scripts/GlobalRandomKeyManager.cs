using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//controls the random keys of all the players as a server
public class GlobalRandomKeyManager : MonoBehaviour {
	
	public float _randomKeyTimeout = 10.0f; //timer controls how often new random keys are generated
	
	private List<Component> _buttons = new List<Component>(); //contains all the buttons registered to receive random keys
	
	private List<string> _possibleKeys; //keyboard keys allowed
	private int _possibleKeysLenght;


	//after _randomKeyTimeout time, assigns new unused random key for the registered buttons
	IEnumerator renewRandomKeys(){
		if (_buttons.Count != 0) {
			foreach (Component button in _buttons) {
				if(button != null){
					string previousKey = ((RandomButton)button).getCurrentKey ();
					((RandomButton)button).setRandomKey (getUnusedRandomKey (previousKey));
				}
			}
			yield return new WaitForSeconds (_randomKeyTimeout);
			StartCoroutine ("renewRandomKeys");
		}
	}

	/*
	//allows for buttons to register with this globl class, in order to receive random keys
	public void registerButton(Component newButton){
		if(!_buttons.Contains(newButton)){
			_buttons.Add(newButton);
			//Debug.Log (newButton.name + " registered!");
		}
	}
	*/
	//returns an unused key, adding the previous one to the list of available keys
	private string getUnusedRandomKey(string previousKey){
		//Debug.Log ("previous key " + previousKey);
		if (!_possibleKeys.Contains (previousKey)) {
			_possibleKeys.Add (previousKey);
			_possibleKeysLenght++;
		}

		int randIndex = Random.Range (0, _possibleKeysLenght);

		string ret = _possibleKeys[randIndex].ToString();
		_possibleKeys.RemoveAt (randIndex);
		_possibleKeysLenght--;
		return ret;
	}
	
	void Awake(){
		_possibleKeys = new List<string>(new string[] {"1","2","3","4","5","6","7","8","9","0","c","d","e","f","g","h","i","j","k","m","n","o","q","r","s","t","u","w","x","y"});
		_possibleKeysLenght = _possibleKeys.Count;

		_buttons.Add(GameObject.Find ("Player 1").GetComponent<PlayerMoveButton>());
		_buttons.Add(GameObject.Find ("Player 1").GetComponent<PlayerAttackButton>());
		_buttons.Add(GameObject.Find ("Player 2").GetComponent<PlayerMoveButton>());
		_buttons.Add(GameObject.Find ("Player 2").GetComponent<PlayerAttackButton>());
		_buttons.Add(GameObject.Find ("Player 3").GetComponent<PlayerMoveButton>());
		_buttons.Add(GameObject.Find ("Player 3").GetComponent<PlayerAttackButton>());

		//Debug.Log (_possibleKeys.Count + " size");
	}
	
	void Start () {
		StartCoroutine("renewRandomKeys");
	}
}
