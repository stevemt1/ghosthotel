using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event7 : MonoBehaviour {

	private Player player;
	public GameObject Flashback;
	public DialogueManager DialogueManager;
	public Pygo Pygo;
	public Milan Milan;
	public Russet Russet;
	public bool once;
	[TextArea(1,30)]
	public string[] dialogue;
	public Queue<bool> directions = new Queue<bool> (new[] {false, true, false, true, false, true, false, true, false, true});



	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();
		Flashback = GameObject.Find ("Flashback");

		if (player.check_topic ("PYGOWATCH") && player.event6) {
			player.event6 = false;
			player.event7 = true;
			if (Pygo != null) {
				Pygo.gameObject.SetActive (true);
			}
			if (Milan != null) {
				Milan.gameObject.SetActive (true);
			}
			DialogueManager.ShowBox (dialogue, directions, true, false, true, true, "Pygo", "Milan");
			if (!player.check_topic ("FREETV")) {
				player.add_topic ("FREETV");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!DialogueManager.dialogueActive && DialogueManager.flavortexts.Count == 0 && player.event7 && once) {
			once = false;
			Flashback.GetComponent<UIFade> ().Reset ();
			if (Milan != null)
				Milan.gameObject.SetActive (false);
			if (Pygo != null)
				Pygo.gameObject.SetActive (false);
		}
		if (player.event7) {
			if (Russet != null && !player.russetgone && (GameObject.FindGameObjectWithTag ("Room").name == "Hallway(Clone)" || GameObject.FindGameObjectWithTag ("Room").name == "Hallway")) {
				Russet.gameObject.SetActive (true);
			}
		}
	}
}
