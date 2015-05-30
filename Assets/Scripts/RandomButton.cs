using UnityEngine;
using System.Collections;

//"interface" of a button that registers with the global random manager to receive random values
public class RandomButton : MonoBehaviour {
	
	public string _key = "d"; //makes ship fly forward
	
	//global key manager will update key using this
	public void setRandomKey(string newKey){
		_key = newKey;
		Debug.Log (this.gameObject.name + " button set to: " + newKey);
	}

	//returns currently assigned key
	public string getCurrentKey(){
		return _key;
	}
	
	// Use this for initialization
	void Start () {
	}
}
