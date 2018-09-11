using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event5 : MonoBehaviour {
	private Player player;
	public DialogueManager DialogueManager;
	[TextArea(1,10)]
	public string[] dialogue;
	public Milan Milan;
	public Cornelia Cornelia;
	public Russet Russet;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player Ana").GetComponent<Player>();
		DialogueManager = FindObjectOfType<DialogueManager> ();

		if (player.check_topic ("PASSWORDS") && player.event4) {
			player.event4 = false;
			player.event5 = true; 
			Destroy(GameObject.Find ("Player Platform"));
			DialogueManager.ShowBox (dialogue, true, false, false, false, "", "");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (player.event5) {
			if (Cornelia != null){
				if (GameObject.FindGameObjectWithTag ("Room").name == "Hotel Exterior(Clone)")
					Cornelia.gameObject.SetActive (true);
				else
					Cornelia.gameObject.SetActive (false);
			}
			if (Russet != null){
				if (GameObject.FindGameObjectWithTag ("Room").name == "Hotel Exterior(Clone)")
					Russet.gameObject.SetActive (true);
				else
					Russet.gameObject.SetActive (false);
			}
			if (Milan != null)
				Milan.gameObject.SetActive (true);
		}
	}
}
