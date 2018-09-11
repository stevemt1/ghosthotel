using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	Vector3 respawnPoint;

	void Start(){
		respawnPoint = new Vector3 (-3, 1, 0);
	}

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
	{


		if (other.gameObject.tag == "Respawn"){
			transform.position = respawnPoint;
		}


	}

	public void ChangeRespawn(Vector3 newPoint)
	{
		respawnPoint = newPoint;	
	}
}
