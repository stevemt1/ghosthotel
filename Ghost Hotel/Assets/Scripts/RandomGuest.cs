using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGuest : MonoBehaviour {

	public Player player;
	public DialogueManager DialogueManager;
	[TextArea (1, 10)]
	public string[] dialogue;
	public bool once = true;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!DialogueManager.dialogueActive && DialogueManager.flavortexts.Count == 0) {
			player.talking = false;
		}

		if (Vector2.Distance (player.transform.position, gameObject.transform.position) <= 4 && once) {
			//			PlayerDM.ForceClose ();
			once = false;
			player.talking = true;
			DialogueManager.ShowBox (dialogue, true, false, false, false, "", "");
			if (!player.check_topic ("CABBIE")) {
				player.add_topic ("CABBIE");
			}
		}
	}
}
