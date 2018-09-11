using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mall : MonoBehaviour {

	public Player player;
	public GameObject playersaved;
	public GameObject maincam;
	public DialogueManager DialogueManager;
	[TextArea(1,10)]
	public string[] dialogue;

	// Use this for initialization
	void Start () {
		playersaved = GameObject.Find ("Player Ana");
		maincam = GameObject.Find ("Main Camera");
		playersaved.SetActive (false);
		maincam.SetActive (false);
		player = FindObjectOfType<Player>();
		player.remake_inv (playersaved.GetComponent<Player> ());
		DialogueManager = FindObjectOfType<DialogueManager> ();
		if (player.check_topic("ROOM1502") && !player.office && !player.home) {
			player.talking = true;
			DialogueManager.ForceClose ();
			DialogueManager.ShowBox (dialogue, true, false, false, false, "", "");
		}
	}

	// Update is called once per frame
	void Update () {

//		if (player.talking && !DialogueManager.dialogueActive) {
//			player.talking = false;
//		}
	}


	void OnMouseDown(){
		if (!player.talking) {
			if (player != null) {
				Destroy (player);
			}
			playersaved.SetActive (true);
			playersaved.transform.position = new Vector3 (25.5f, -2.3f, 0f);
			maincam.SetActive (true);
			playersaved.GetComponent<Player> ().remake_inv (player);
			//		Destroy (player);
			foreach (GameObject item in GameObject.FindGameObjectsWithTag("pickup")) {
				Destroy (item);
			}
		}
	}
}
