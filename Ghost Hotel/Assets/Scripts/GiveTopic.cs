using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveTopic : MonoBehaviour {
		
	private Player player;
	public DialogueManager DialogueManager;
//	private AcquiredBox Box;
	public string topic;
	public bool dialogueFinished = false;


	void Start(){
		player = FindObjectOfType<Player> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();
//		Box = FindObjectOfType<AcquiredBox> ();
	}

	void OnMouseDown(){
		if (!player.check_topic(topic)) {
			dialogueFinished = true;
		}
	}

	void Update(){
		if (dialogueFinished && DialogueManager.flavortexts.Count == 0){
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
				if (!player.check_item(topic))
					player.add_topic (topic);
//			Box.ShowBox ();
				dialogueFinished = false;
			}
		}
	}
}
