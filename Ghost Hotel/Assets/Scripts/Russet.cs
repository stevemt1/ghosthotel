using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Russet : MonoBehaviour {

	public DialogueManager DialogueManager;
	public TopicChoice TopicChoice;
	public Player player;
	public bool rtalking;
	public bool walkedby = false;
	public bool greeted = false;
	public bool serviced = false;
	public bool first = false;
	public Sprite nonglow;
	public Sprite glow;
	public GameObject flashback;
	public bool flashbacking;
	[TextArea (1,4)]
	public string[] dialogue;
	[TextArea (1,20)]
	public string[] greet;
	[TextArea (1,20)]
	public string[] service;
	[TextArea (1,20)]
	public string[] myDeath;
	[TextArea (1,20)]
	public string[] hotelLimbo;
	[TextArea (1,20)]
	public string[] checkIn;
	[TextArea (1,20)]
	public string[] checkOut;
	[TextArea (1,20)]
	public string[] passwords;
	[TextArea (1,20)]
	public string[] childshow;
	[TextArea (1,20)]
	public string[] manager;
	[TextArea (1,20)]
	public string[] cornelia;
	[TextArea (1,20)]
	public string[] television;
	[TextArea (1,20)]
	public string[] pygo;
	[TextArea (1,20)]
	public string[] milan;
	[TextArea (1,20)]
	public string[] russet;
	[TextArea (1,20)]
	public string[] breakin;
	[TextArea (1,30)]
	public string[] memorial;
	public string[] empty;
	public Queue<bool> directions = new Queue<bool> (new[] {false, true});
	public Queue<bool> mydeathdirections = new Queue<bool> (new[] {false, false, true, false, false});
	public Queue<bool> hoteldirections = new Queue<bool> (new[] {false, false, false, false, true});
	public Queue<bool> servicedirections = new Queue<bool> (new[] {false, true, false, false, false, true, false, true, true});
	public Queue<bool> checkindirections = new Queue<bool> (new[] {false, false, true});
	public Queue<bool> checkoutdirections = new Queue<bool> (new[] {false, false, false, false, false, false});
	public Queue<bool> passworddirections = new Queue<bool> (new[] {true});
	public Queue<bool> childshowdirections = new Queue<bool> (new[] {false, false, false, true});
	public Queue<bool> managerdirections = new Queue<bool> (new[] {false, true, false, false, false});
	public Queue<bool> corneliadirections = new Queue<bool> (new[] {false, false, false});
	public Queue<bool> tvdirections = new Queue<bool> (new[] {false, false});
	public Queue<bool> pygodirections = new Queue<bool> (new[] {false, true, false, false});
	public Queue<bool> milandirections = new Queue<bool> (new[] {false, false, true, false, false, true});
	public Queue<bool> russetdirections = new Queue<bool> (new[] {false, false, true, true});
	public Queue<bool> breakindirections = new Queue<bool> (new[] {false, true, false, true, false, false, true, false, false, false, true});
	public Queue<bool> memorialdirections = new Queue<bool> (new[] {false, false, false, false, true, false, true, false, true, true, true, false, true, true, false, true, false, false, true, false, false, false, false, true, false, false, true, false, false});

	public Queue<bool> empty1;

	public List<string> Usable;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		flashback = GameObject.Find ("Flashback");
		DialogueManager = FindObjectOfType<DialogueManager> ();
		TopicChoice = FindObjectOfType<TopicChoice> ();
		Usable = new List<string> (){"GREET", "MYDEATH", "HOTEL", "SERVICE", "CHECKIN", "CHECKOUT", "PASSWORDS", "CHILDRENSHOW", "BREAKIN", "MANAGER", "CORNELIA", "TV", "PYGO", "MILAN", "RUSSET", "MEMORIAL"};
	}

	public void OnMouseDown(){
		if (!DialogueManager.dialogueActive && player.cursor_value == 0 && GameObject.FindGameObjectWithTag("Room").name != "Memory(Clone)") {
			player.talking = true;
			rtalking = true;
			DialogueManager.ShowBox(dialogue, false, false, false, false, "", "Russet");
			TopicChoice.ShowBoxes (Usable, "Russet");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (greeted && !DialogueManager.dialogueActive) {
			if (DialogueManager.flavortexts.Count == 0) {
				if (!player.check_topic("COMPUTER"))
					player.add_topic ("COMPUTER");
			}
				if (flashbacking) {
					flashback.GetComponent<UIFade> ().Reset ();
					greeted = false;
					flashbacking = false;
					player.talking = false;
					player.russetgone = true;
					gameObject.SetActive (false);
				}
			greeted = false;
			player.talking = false;
		}
		if (flashbacking) {
			if (DialogueManager.flavortexts.Count == 10) {
				flashback.GetComponent<UIFade> ().FadeIn ();
			}
			if (DialogueManager.flavortexts.Count == 5) {
				flashback.GetComponent<UIFade> ().FadeOut ();
			}
		}

		if (player.event4) {
			dialogue [0] = "What? I'm trying to eat... Leave me alone...";
		}
		if (GameObject.FindGameObjectWithTag ("Room").name == "Hotel Exterior(Clone)") {
			dialogue [0] = "The sky is so black...";
		}
		if (player.event7) {
			dialogue [0] = "What now?";
		}
		directions = new Queue<bool> (new[] {false, true});
		breakindirections = new Queue<bool> (new[] {false, true, false, true, false, false, true, false, false, false, true});
		servicedirections = new Queue<bool> (new[] {false, true, false, false, false, true, false, true, true});
		mydeathdirections = new Queue<bool> (new[] {false, false, true, false, false});
		hoteldirections = new Queue<bool> (new[] {false, false, false, false, true});
		checkindirections = new Queue<bool> (new[] {false, false, true});
		checkoutdirections = new Queue<bool> (new[] {false, false, false, false, false, false});
		passworddirections = new Queue<bool> (new[] {true});
		childshowdirections = new Queue<bool> (new[] {false, false, false, true});
		managerdirections = new Queue<bool> (new[] {false, true, false, false, false});
		corneliadirections = new Queue<bool> (new[] {false, false, false});
		tvdirections = new Queue<bool> (new[] {false, false});
		pygodirections = new Queue<bool> (new[] {false, true, false, false});
		milandirections = new Queue<bool> (new[] {false, false, true, false, false, true});
		russetdirections = new Queue<bool> (new[] {false, false, true, true});
		memorialdirections = new Queue<bool> (new[] {
			false,
			false,
			false,
			false,
			true,
			false,
			true,
			false,
			true,
			true,
			true,
			false,
			true,
			true,
			false,
			true,
			false,
			false,
			true,
			false,
			false,
			false,
			false,
			true,
			false,
			false,
			true,
			false,
			false
		});
	}

	public void returnChoice(GameObject imageobject){
		if (rtalking) {
			if (imageobject.name == "Image1") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text1.text), true, "Ana", "Manager");
				DialogueManager.ShowBox (Choice (TopicChoice.text1.text), Choice1(TopicChoice.text1.text), true, false, true, false, "", "Russet");
				greeted = true;
			}
			if (imageobject.name == "Image2") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text2.text), Choice1(TopicChoice.text2.text), true, false, true, false, "", "Russet");
				greeted = true;
			}
			if (imageobject.name == "Image3") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text3.text), Choice1(TopicChoice.text3.text), true, false, true, false, "", "Russet");
				greeted = true;
			}
			if (imageobject.name == "Image4") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Russet", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), Choice1 (TopicChoice.text4.text), true, false, true, false, "", "Russet");
				greeted = true;

			}
			if (imageobject.name == "Image5") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Russet", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text5.text), Choice1 (TopicChoice.text5.text), true, false, true, false, "", "Russet");
				greeted = true;

			}
			if (imageobject.name == "Image6") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Russet", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text6.text), Choice1 (TopicChoice.text6.text), true, false, true, false, "", "Russet");
				greeted = true;

			}
			if (imageobject.name == "Image7") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Russet", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text7.text), Choice1 (TopicChoice.text7.text), true, false, true, false, "", "Russet");
				greeted = true;

			}
			if (imageobject.name == "Image8") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Russet", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text8.text), Choice1 (TopicChoice.text8.text), true, false, true, false, "", "Russet");
				greeted = true;

			}
			if (imageobject.name == "Image9") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text2.text), true, "Russet", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text9.text), Choice1 (TopicChoice.text9.text), true, false, true, false, "", "Russet");
				greeted = true;

			}
			if (imageobject.name == "Image10") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text3.text), true, "Russet", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text10.text), Choice1 (TopicChoice.text10.text), true, false, true, false, "", "Russet");
				greeted = true;

			}
			if (imageobject.name == "Image11") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Russet", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text11.text), Choice1 (TopicChoice.text11.text), true, false, true, false, "", "Russet");
				greeted = true;

			}
			if (imageobject.name == "Image12") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Russet", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text12.text), Choice1 (TopicChoice.text12.text), true, false, true, false, "", "Russet");
				greeted = true;

			}
			if (imageobject.name == "Image13") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Russet", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text13.text), Choice1 (TopicChoice.text13.text), true, false, true, false, "", "Russet");
				greeted = true;

			}
			if (imageobject.name == "Image14") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Russet", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text14.text), Choice1 (TopicChoice.text14.text), true, false, true, false, "", "Russet");
				greeted = true;

			}
			if (imageobject.name == "Image15") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Russet", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text15.text), Choice1 (TopicChoice.text15.text), true, false, true, false, "", "Russet");
				greeted = true;

			}
			if (imageobject.name == "Image16") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Russet", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text16.text), Choice1 (TopicChoice.text16.text), true, false, true, false, "", "Russet");
				greeted = true;

			}
		}
	}

	public string[] Choice(string text){
		if (text == "GREET") {
			return greet;
		}
		if (text == "MYDEATH") {
			return myDeath;
		}
		if (text == "HOTEL") {
			return hotelLimbo;
		}
		if (text == "SERVICE") {
			return service;
		}

		if (text == "CHECKIN") {
			return checkIn;
		}
		if (text == "CHECKOUT") {
			return checkOut;
		}
		if (text == "PASSWORDS") {
			return passwords;
		}
		if (text == "CHILDRENSHOW") {
			return childshow;
		}
		if (text == "MANAGER") {
			return manager;
		}
		if (text == "CORNELIA") {
			return cornelia;
		}
		if (text == "TV") {
			return television;
		}
		if (text == "PYGO") {
			return pygo;
		}
		if (text == "MILAN") {
			return milan;
		}
		if (text == "RUSSET") {
			return russet;
		}

		if (text == "BREAKIN") {
			player.home = true;
			flashbacking = true;
			return breakin;
		}
		if (text == "MEMORIAL") {
			return memorial;
		}
		else 
			return empty;
	}
	public Queue<bool> Choice1(string text){
		if (text == "GREET") {
			return directions;
		}
		if (text == "MYDEATH") {
			return mydeathdirections;
		}
		if (text == "HOTEL") {
			return hoteldirections;
		}
		if (text == "SERVICE") {
			return servicedirections;
		}

		if (text == "CHECKIN") {
			return checkindirections;
		}
		if (text == "CHECKOUT") {
			return checkoutdirections;
		}
		if (text == "PASSWORDS") {
			return passworddirections;
		}
		if (text == "CHILDRENSHOW") {
			return childshowdirections;
		}
		if (text == "MANAGER") {
			return managerdirections;
		}
		if (text == "CORNELIA") {
			return corneliadirections;
		}
		if (text == "TV") {
			return tvdirections;
		}
		if (text == "PYGO") {
			return pygodirections;
		}
		if (text == "MILAN") {
			return milandirections;
		}
		if (text == "RUSSET") {
			return russetdirections;
		}

		if (text == "BREAKIN") {
			return breakindirections;
		}
		if (text == "MEMORIAL") {
			if (!player.check_topic ("RUSSETREADY")) {
				player.add_topic ("RUSSETREADY");
			}
			return memorialdirections;
		}
		else
			return empty1;
	}

	void OnMouseEnter(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = glow;
	}

	void OnMouseExit(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = nonglow;
	}

}
