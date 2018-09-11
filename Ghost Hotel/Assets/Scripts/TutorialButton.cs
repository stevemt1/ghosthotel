using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour {

	public GameObject locationPrefab;
	public GameObject tuttext;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	//void Update () {
		//OnMouseDown ();
	//}
	public void LoadTutorial(){
		Destroy (GameObject.FindGameObjectWithTag ("Room"));
		GameObject.Instantiate (locationPrefab);
		tuttext.SetActive (true);
		gameObject.SetActive (false);
	}

//	void OnMouseDown()
//	{
//		if (gameObject.tag == "Tut_button") {
//			Debug.Log ("Worked");
//			Destroy (GameObject.FindGameObjectWithTag ("Room"));
//			GameObject.Instantiate (locationPrefab);
//		}
//
//	}
}
