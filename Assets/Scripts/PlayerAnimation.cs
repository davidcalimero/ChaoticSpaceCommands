using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Accelerate (){
		anim.SetBool ("accelerate", true);
	}

	void Decelerate (){
		anim.SetBool ("accelerate", false);
	}
}
