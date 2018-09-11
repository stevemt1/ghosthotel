using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event6 : MonoBehaviour {
	private Player player;
	public Pygo Pygo;
	public Milan Milan;
	public Russet Russet;
	public Cornelia Cornelia;
	public DialogueManager DialogueManager;
	[TextArea(1,30)]
	public string[] dialogue;
	public Queue<bool> directions = new Queue<bool> (new[] {true, false, false, false, false, false, false, false, false, false, false, false, true, false, true});


	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player Ana").GetComponent<Player>();
		DialogueManager = FindObjectOfType<DialogueManager> ();

		if (player.check_item ("Master Control") && player.event5) {
			player.event5 = false;
			player.event6 = true;
			Destroy(GameObject.Find ("Player Platform"));
			DialogueManager.ShowBox (dialogue, directions, false, false, true, false, "", "Russet");
		}
	}

	// Update is called once per frame
	void Update () {
		if (player.event6) {
			if (player.check_item ("Master Control")) {
				if (Russet != null && GameObject.FindGameObjectWithTag ("Room").name == "Hallway(Clone)")
					Russet.gameObject.SetActive (true);
				else
					Russet.gameObject.SetActive (false);
			}
			if (Pygo != null && !player.pygogone)
				Pygo.gameObject.SetActive (true);
			if (Milan != null)
				Milan.gameObject.SetActive (true);
			if (Cornelia != null)
				Cornelia.gameObject.SetActive (false);
		}
		directions = new Queue<bool> (new[] {true, false, false, false, false, false, false, false, false, false, false, false, true, false, true});
	}
}
