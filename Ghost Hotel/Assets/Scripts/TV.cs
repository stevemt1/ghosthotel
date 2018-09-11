using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour {

	public Player player;
	public DialogueManager DialogueManager;
	[TextArea (1,4)]
	public string[] dialogue;
	[TextArea (1,30)]
	public string[] dialogue1;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.check_topic ("TVFIXED") && player.check_topic ("SHOWS")) {
			gameObject.GetComponent<Animator> ().enabled = false;
		}
	}

	void OnMouseDown(){
		if (player.check_topic ("FREETV") && player.event7 && !player.talking) {
			DialogueManager.ForceClose ();
			DialogueManager.ShowBox (dialogue1, true, false, false, false, "", "");
			if (!player.check_topic ("BREAKIN")) {
				player.add_topic ("BREAKIN");
			}
		}
		if (player.check_topic("SHOWS") && !player.event7 && !player.talking){
			DialogueManager.ForceClose ();
			DialogueManager.ShowBox (dialogue, true, true, false, false, "", "Milan");
			if (!player.check_topic ("CHILDREN'SSHOW")) {
				player.add_topic ("CHILDREN'SSHOW");
			}
		}
	}

}
