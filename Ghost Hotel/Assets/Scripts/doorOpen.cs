using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour {

	public bool inDoor;
	private Player player;
	public Vector3 doorGoes;

	void Start(){
		
	}

	// Update is called once per frame
	void Update () {
		player = FindObjectOfType<Player> ();
		if (inDoor == true && Input.GetKey("w")) {
//			Debug.Log ("HAHAHA");
			player.transform.position = doorGoes;
//			Debug.Log ("HAH");
		}
	}


	void OnTriggerEnter2D(Collider2D col) 
	{
//		Debug.Log ("UHHH");
		//jump check
		inDoor = true;
	}

	void OnTriggerExit2D(Collider2D col) 
	{
//		Debug.Log ("dUHHH");
		inDoor = false;
	}
}
