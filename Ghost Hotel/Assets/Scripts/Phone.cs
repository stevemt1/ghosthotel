using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour {

	public Player player;
	public DialogueManager DialogueManager;
//	public DialogueManager playerDM;
	[TextArea (1, 10)]
	public string[] calling;
	[TextArea (1, 10)]
	public string[] event3;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown(){

		if (player.event4 || player.event5) {
			DialogueManager.ForceClose ();
			DialogueManager.ShowBox (gameObject.GetComponent<Item>().flavortext1, true, false, false, false, "", "");
		}

		if (player.event3) {
			DialogueManager.ForceClose ();
			DialogueManager.ShowBox (event3, true, false, false, false, "", "");
		}

		else if (player.check_item("Phone Book") && !player.talking && !player.event4) {
			if (!player.check_topic ("NOISE"))
				player.add_topic ("NOISE");
			DialogueManager.ShowBox (calling, false, true, false, false, "", "Cornelia");
		}
	}
}
