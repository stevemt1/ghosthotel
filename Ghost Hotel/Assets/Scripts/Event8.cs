using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Event8 : MonoBehaviour {

	private Player player;
	public GameObject flashback;
	public DialogueManager DialogueManager;
	public Milan Milan;
	public Pygo Pygo;
	public Cornelia Cornelia;
	public Russet Russet;
	public GameObject Rando;
	[TextArea(1,30)]
	public string[] dialogue;
	[TextArea(1, 25)]
	public string[] final;

	public bool gameend = false;
	public GameObject end;

	public Queue<bool> directions = new Queue<bool> (new[] {false, true, false, true, false, false, true, true, true, true, false, false, false, false, false, false, true, false, true, true, true, true, true, true});



	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player Ana").GetComponent<Player>();
		DialogueManager = FindObjectOfType<DialogueManager> ();
		flashback = GameObject.Find ("Flashback");
		end = GameObject.Find ("End");

		if (player.check_item ("Valuables") && player.event7) {
			player.event7 = false;
			player.event8 = true;
			Destroy (GameObject.Find ("Player Platform"));
			DialogueManager.ShowBox (dialogue, true, false, false, false, "", "");
		} else {
			Destroy (GameObject.Find ("Player Platform"));
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (gameend && !DialogueManager.dialogueActive && DialogueManager.flavortexts.Count == 0) {
			end.GetComponent<Image> ().enabled = true;
		
			if (Input.GetMouseButtonDown (0)) {
				SceneManager.LoadScene ("Title");
			}
		}

		if (player.event8) {
			if (player.check_topic ("NEWGUEST") && Rando != null) {
				Rando.SetActive (true);
			}
			if (Milan != null)
				Milan.gameObject.SetActive (false);
			if (Pygo != null)
				Pygo.gameObject.SetActive (false);
			if (Russet != null && GameObject.FindGameObjectWithTag ("Room").name == "Lobby(Clone)") {
				Russet.gameObject.SetActive (true);
			}
			if (Cornelia != null) {
				if (GameObject.FindGameObjectWithTag ("Room").name == "Restaurant(Clone)") {
					Cornelia.gameObject.SetActive (true);
				} else {
					Cornelia.gameObject.SetActive (false);
				}
			}
			if (player.check_topic ("CABBIE") && GameObject.FindGameObjectWithTag ("Room").name == "Hotel Exterior(Clone)") {
				flashback.GetComponent<UIFade> ().FadeIn ();
				DialogueManager.ShowBox (dialogue, directions, true, false, true, false, "", "Cabbie");
				gameend = true;
			}
		}
		directions = new Queue<bool> (new[] {false, true, false, true, false, false, true, true, true, true, false, false, false, false, false, false, true, false, true, true, true, true, true, true});
	}
}
