using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event4 : MonoBehaviour {

	private Player player;
	public bool played = false;
	public DialogueManager DialogueManager;
	[TextArea(1,10)]
	public string[] dialogue;
	public Cornelia Cornelia;
	public Pygo Pygo;
	public Milan Milan;
	public Russet Russet;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
//		Cornelia = FindObjectOfType<Cornelia> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();

		if (Cornelia != null && GameObject.FindGameObjectWithTag ("Room").name == "Lobby(Clone)") {
			Cornelia.gameObject.SetActive (false);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (player.event4) {
			
			player.event3 = false;
			if (GameObject.FindGameObjectWithTag ("Room").name == "Hotel Exterior(Clone)" && Cornelia != null && player.event4) {
				Cornelia.gameObject.SetActive (true);
			}
			if (Milan != null && GameObject.FindGameObjectWithTag ("Room").name == "Lobby(Clone)") {
				Milan.gameObject.SetActive (true);
			}
			if (Pygo != null)
				Pygo.gameObject.SetActive (true);
			
			if (GameObject.FindGameObjectWithTag ("Room").name == "Restaurant(Clone)" && player.event4 && !played) {
				DialogueManager.ShowBox (dialogue, true, false, false, false, "", "");
				if (Russet != null)
					Russet.gameObject.SetActive (true);
				played = true;
			}
		}
	}
}
