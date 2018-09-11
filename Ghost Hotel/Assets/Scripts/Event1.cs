using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1 : MonoBehaviour {

	private Player player;
	public bool convo = false;
	public bool firsttopic = false;
	public bool e = true;
//	public DialogueManager PlayerDM;
	public DialogueManager DialogueManager;
	public Camera Cam;
	[TextArea(1,10)]
	public string[] dialogue;
	[TextArea(1,30)]
	public string[] event1;
	public Queue<bool> directions = new Queue<bool> (new[] {false, false, false, false, false});

	void Start(){
		player = FindObjectOfType<Player> ();
		if (!player.event1)
			player.talking = true;
		Cam = FindObjectOfType<Camera> ();
//		Cam.GetComponent<CameraController> ().explore = false;
		DialogueManager = FindObjectOfType<DialogueManager> ();
	}

	void Update(){
		if (!player.event1) {
			DialogueManager.ShowBox(dialogue, directions, false, false, true, false, "", "Cornelia");
			player.event1 = true;
		}

		if (!DialogueManager.dialogueActive && DialogueManager.flavortexts.Count == 0) {
			player.talking = false;
			Cam.GetComponent<CameraController> ().explore = true;
			if (!player.check_topic ("GREET") && firsttopic)
				player.add_topic ("GREET");
		}

//		if (player.talking && !DialogueManager.dialogueActive && e) {
//			Cam.GetComponent<CameraController> ().explore = true;
//			player.talking = false;
//			if (firsttopic) {
////				PlayerDM.ForceClose ();
//				player.add_topic ("GREET");
////				player.add_topic ("JUMP");
//				firsttopic = false;
//				e = false;
//			}
//		}
		if (player.cutscene && Vector2.Distance (player.transform.position, gameObject.transform.position) <= 4) {
//			PlayerDM.ForceClose ();
			player.talking = true;
			DialogueManager.ShowBox (event1, true, true, false, false, "", "Cornelia");
			firsttopic = true;
			player.cutscene = false;
		}
	}
}
