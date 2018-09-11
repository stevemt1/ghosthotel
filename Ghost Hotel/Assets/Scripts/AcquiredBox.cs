using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcquiredBox : MonoBehaviour {

	public GameObject acquireBox;
	public Text itemtopicText;
	public string acquired;


	// Use this for initialization
	void Start () {
		
	}
	
	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			Close ();
		}
	}


	public void Close(){
		acquireBox.SetActive (false);
	}


	public void ShowBox(){
		acquireBox.SetActive (true);
		itemtopicText.text = acquired + " added into player's inventory";
	}
}
