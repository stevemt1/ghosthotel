using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRespawn : MonoBehaviour {

	public Player player;
	public Vector3 newPoint;

	void Update(){
		player = FindObjectOfType<Player> ();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		
		if (collision.gameObject.tag == "Player")
		{ 
			player.GetComponent<Respawn> ().ChangeRespawn (newPoint);
		}
	}
}
