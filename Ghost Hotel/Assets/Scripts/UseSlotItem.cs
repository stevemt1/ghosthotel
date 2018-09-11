using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSlotItem : MonoBehaviour {

	public Player player;

	void Start () {
		player = FindObjectOfType<Player> ();
	}

	void Update(){
		player = FindObjectOfType<Player> ();
	}
	
	public void Use(){
		if (gameObject.GetComponent<Image> ().sprite == null) {

		}
		else
			player.UseItem (gameObject.GetComponent<Image>().sprite.name);
	}
}
