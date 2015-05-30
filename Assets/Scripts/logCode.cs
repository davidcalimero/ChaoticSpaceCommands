using UnityEngine;
using System.Collections;

public class logCode : MonoBehaviour {

	string[] pilha = new string[6]{"The Chaotic Game","(A)(Z)-Player one","(L)(P)-Player 2","(V)(B)-Player 3","Everything Else...","...Is Everlasting Chaos!!"};

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
<<<<<<< HEAD
		GameObject anchor = GameObject.Find("info");
		float x1 = anchor.transform.position.x;
		float y1 = anchor.transform.position.y;
		GUI.Label(new Rect(x1,y1,1000,2000), fullString());
=======
		GUI.Label(new Rect(Screen.width * 0.09f,Screen.height*0.16f,1000,2000), fullString());
>>>>>>> origin/master
	}
}
