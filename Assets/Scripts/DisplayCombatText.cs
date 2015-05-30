using UnityEngine;
using System.Collections;

public class DisplayCombatText : MonoBehaviour {

	public float displayTime = 5.0f;
	private bool _isDisplayText = false;

	private GUIStyle _style = new GUIStyle();
	private string _displayText;
	private Vector2 _position = new Vector2();

	private Vector3 pos;

	//depending on who hit it, display a text over the thing hit!
	public void displayCombatText(string name){
		if (name.Equals ("star")) {
			_style.normal.textColor = Color.yellow;
			_displayText = "Star Shower!";
			StartCoroutine ("waitDisplayTime");
		} else if (name.Equals("heal")){
			_style.normal.textColor = Color.green;
			_displayText = "Heal!";
			StartCoroutine ("waitDisplayTime");
		} else if (name.Equals ("Bullet(Clone)")) {
			_style.normal.textColor = Color.red;
			_displayText = "Hit!!";
			StartCoroutine("waitDisplayTime");
		}
	}

	IEnumerator waitDisplayTime(){
		_isDisplayText = true;
		yield return new WaitForSeconds (displayTime);
		_isDisplayText = false;
	}

	void OnGUI(){
		if (_isDisplayText) {
			pos = Camera.main.WorldToScreenPoint(transform.position);
			pos.y = Screen.height - pos.y;
			GUI.Label(new Rect(pos.x, pos.y, 100,100),_displayText,_style);
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
