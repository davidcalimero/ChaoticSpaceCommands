using UnityEngine;
using System.Collections;

public class logCode : MonoBehaviour {

	string[] pilha = new string[6]{"The Chaotic Game","(A)(Z)-Player 1","(L)(P)-Player 2","(V)(B)-Player 3","Everything Else...","...Is Everlasting Chaos!!"};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	public string[] saltaNext(string ele){
		string iter = ele;
		int i;
		for(i=0; i < pilha.Length - 1;i++){
			string v = pilha[i];
			pilha[i] = iter;
			iter = pilha[i+1];
			pilha[i+1] = v;
		} 

		return pilha;
	}

	public string fullString(){
		string str = "LogBook:\n\n";
		int i;
		for(i=0; i < pilha.Length; i++){
			str += pilha[i] + "\n";
		}
		return str;
	}

	void OnGUI(){
		GUI.Label(new Rect(Screen.width - 0.10f,Screen.height-0.15f,1000,2000), fullString());
	}
}
