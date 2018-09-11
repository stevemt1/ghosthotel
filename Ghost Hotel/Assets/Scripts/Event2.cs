using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2 : MonoBehaviour {

	private Player player;
	public DialogueManager DialogueManager;
	[TextArea(1,10)]
	public string[] dialogue;
	public Manager manager;
	public GameObject water;
	public Pygo Pygo;
	[TextArea (1,20)]
	public string[] nowater;
	public Queue<bool> nowaterdirections = new Queue<bool> (new[] {true, false, true, false, false, false, true});


	void Start(){
		player = FindObjectOfType<Player> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();

		if (player.check_topic ("NOWATER") && !player.event3 && !player.event4 && !player.event5 && !player.event6 && !player.event7 && !player.event8) {
			player.event3 = true;
			player.wetHallway = false;
			water.SetActive (false);
			if (manager != null)
				manager.gameObject.SetActive (true);
			if (!player.check_topic ("SERVICE"))
				player.add_topic ("SERVICE");
			player.talking = true;
			DialogueManager.ShowBox (nowater, nowaterdirections, false, false, true, false, "", "Manager");
		} else if (player.event3 || player.event4 || player.event5 || player.event6 || player.event7 || player.event8) {
//			if (Pygo != null) {
//				Pygo.gameObject.SetActive (false);
//			}
			water.SetActive (false);
		}
	}
	
	void Update () {
		if (player.fisheused) {
			if (Pygo != null) {
				Pygo.gameObject.SetActive (false);
			}
		}

		if (!player.event2) {
			player.wetHallway = true;
			DialogueManager.ShowBox(dialogue, true, false, false, false, "", "");
			player.event2 = true;
		}
		if (DialogueManager.flavortexts.Count == 0 && player.check_topic("SERVICE")){
			player.talking = false;
		}

		nowaterdirections = new Queue<bool> (new[] {true, false, true, false, false, false, true});

	}
}
