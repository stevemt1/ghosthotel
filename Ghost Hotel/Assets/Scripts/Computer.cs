using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour {

	public Player player;
	public TopicChoice TopicChoice;
	public DialogueManager DialogueManager;
	public bool loggedin = false;
	[TextArea (1,4)]
	public string[] dialogue;
	[TextArea (1,4)]
	public string[] dialogue1;
	[TextArea (1, 10)]
	public string[] beforepass;
	[TextArea (1, 10)]
	public string[] password;
	[TextArea (1,10)]
	public string[] checkstatus;
	[TextArea (1,20)]
	public string[] checkoutrusset;
	[TextArea (1,20)]
	public string[] money;
	[TextArea (1,20)]
	public string[] ready;
	[TextArea (1,20)]
	public string[] moneyready;
	public string[] empty;
	public Queue<bool> checkstatusdirections = new Queue<bool> (new[] {true, false, true, true, true, true, true, false, false});
	public Queue<bool> moneyreadydirections = new Queue<bool> (new[] {true});

	public List<string> Usable;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		TopicChoice = FindObjectOfType<TopicChoice> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();
		Usable = new List<string> (){"MYDEATH"};
	}

	// Update is called once per frame
	void Update () {
		checkstatusdirections = new Queue<bool> (new[] {true, false, true, true, true, true, true, false, false});
		moneyreadydirections = new Queue<bool> (new[] {true});

//		if (TopicChoice.IsActive ()) {
//			if (Input.GetKey (KeyCode.Escape)) {
//				player.talking = false;
//				TopicChoice.Close ();
//				DialogueManager.ForceClose ();
//			}
//		}
	}

	void OnMouseDown(){
		if (player.event8 && player.check_topic("RUSSETREADY") && player.check_topic("MONEY") && !player.talking){
			DialogueManager.ShowBox (moneyready, moneyreadydirections, true, false, true, false, "", "Russet");
		}
		if (player.event8 && player.check_topic("MONEY") && !player.check_topic("RUSSETREADY") && !player.talking){
			DialogueManager.ShowBox (money, true, false, false, false, "", "");
		}
		if (player.event8 && player.check_topic("RUSSETREADY") && !player.check_topic("MONEY") && !player.talking){
			DialogueManager.ShowBox (ready, true, false, false, false, "", "");
		}
		if (player.event8 && !player.check_topic("MONEY") && !player.check_topic("RUSSETREADY") && !player.talking) {
			DialogueManager.ShowBox (checkoutrusset, true, false, false, false, "", "");
		}

		if ((player.event5 || player.event6 || player.event7) && !player.talking) {
			DialogueManager.ShowBox (GetComponent<Item>().flavortext, true, false, false, false, "", "");
		}

		if (player.event3 && player.check_topic("CHECKOUT") && !loggedin && player.cursor_value == 0 && !player.event8 && !player.talking) {
			player.talking = true;
			DialogueManager.ShowBox(dialogue, true, false, false, false, "", "");
			if (player.check_topic ("MYDEATH")) {
				player.talking = true;
				TopicChoice.ShowBoxes (Usable, "Computer");
			}
			else {
				DialogueManager.ShowBox (dialogue1, true, false, false, false, "", "");
//				player.talking = false;
			}
		}

		else if (player.event3 && !loggedin && !player.check_topic("CHECKOUT") && player.cursor_value == 0 && !player.talking) {
			DialogueManager.ForceClose ();
			DialogueManager.ShowBox (beforepass, true, false, false, false, "", "");
		}

		else if (loggedin && player.cursor_value == 0 && !player.talking) {
			if (player.event4) {
				DialogueManager.ShowBox(gameObject.GetComponent<Item>().flavortext1, true, false, false, false, "", "");
			} else {
				DialogueManager.ForceClose ();
				DialogueManager.ShowBox (checkstatus, checkstatusdirections, true, false, true, false, "", "Russet");
				if (!player.check_topic("RUSSET"))
					player.add_topic ("RUSSET");
				if (!player.check_topic ("WALLET"))
					player.add_topic ("WALLET");
			}
		}

	}

	public void returnChoice(GameObject imageobject){
		if (player.talking) {
			if (imageobject.name == "Image1") {
				TopicChoice.Close ();
				DialogueManager.ForceClose ();
				DialogueManager.ShowBox (Choice (TopicChoice.text1.text), true, false, false, false, "", "");
			}
			loggedin = true;
		}
	}

	public string[] Choice(string text){
		if (text == "MYDEATH") {
			return password;
		}
		else 
			return empty;
	}

}
