using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event0 : MonoBehaviour {

	private Player player;
	public DialogueManager DialogueManager;
	[TextArea(1,15)]
	public string[] dialogue;
	public GameObject flashback;
	public bool flashbacking1;
	public Queue<bool> directions = new Queue<bool> (new[] {true, false, true, true, false, true, false, true, true, true, true, true, true, true});
	public GameObject butt;

	// Use this for initialization
	void Start () {
		flashback = GameObject.Find ("Flashback"); 
		butt = GameObject.Find ("Button");
		player = FindObjectOfType<Player> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();
		flashback.GetComponent<Image> ().enabled = true;
		flashbacking1 = true;
		player.talking = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!player.event0){
			DialogueManager.ShowBox (dialogue, directions, false, false, true, false, "", "Cabbie");
			player.event0 = true;
		}
		if (flashbacking1){
			if (DialogueManager.flavortexts.Count == 4) {
				flashback.GetComponent<UIFade> ().FadeOut ();
				flashbacking1 = false;
			}
		}
		if (DialogueManager.dialogueActive) {
			player.talking = true;
		}

		if (DialogueManager.flavortexts.Count == 0 && player.talking){
			player.talking = false;
			if (butt != null)
				butt.GetComponent<Button> ().enabled = true;
		}
		directions = new Queue<bool> (new[] {true, false, true, true, false, true, false, true, true, true, true, true, true, true});

	}
}
