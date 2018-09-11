using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	GameObject load;

	// Use this for initialization
	void Start () {
		load = GameObject.Find ("Text (3)");
		load.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			GameObject.Find ("Text (2)").SetActive(false);
			load.SetActive (true);
			SceneManager.LoadScene ("Exterior");
		}
	}
}
