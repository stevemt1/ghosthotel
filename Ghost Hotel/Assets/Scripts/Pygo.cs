using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pygo : MonoBehaviour {

	public Player player;
	public DialogueManager DialogueManager;
	public TopicChoice TopicChoice;
	public bool ptalking;
	public Sprite nonglow;
	public Sprite glow;
	public GameObject flashback;
	public bool flashbacking;
	public bool greeted = false;
	[TextArea (1,4)]
	public string[] dialogue;
	[TextArea (1,10)]
	public string[] greet;
	[TextArea (1, 10)]
	public string[] television;
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
	public string[] manager;
	[TextArea (1,20)]
	public string[] cornelia;
	[TextArea (1,20)]
	public string[] pygo;
	[TextArea (1,20)]
	public string[] milan;
	[TextArea (1,20)]
	public string[] russet;
	[TextArea (1,20)]
	public string[] breakin;

	[TextArea (1,20)]
	public string[] shows;
	public string[] empty;
	//start with second person talking
	public Queue<bool> directions = new Queue<bool> (new[] {false, true, false, true, false, true, false, true, false, true, true, true});
	public Queue<bool> mydeathdirections = new Queue<bool> (new[] {false, true, true});
	public Queue<bool> hoteldirections = new Queue<bool> (new[] {false, false, true});
	public Queue<bool> servicedirections = new Queue<bool> (new[] {false, false, true});
	public Queue<bool> checkindirections = new Queue<bool> (new[] {false, true});
	public Queue<bool> checkoutdirections = new Queue<bool> (new[] {false, true, false, false, false, true});
	public Queue<bool> passworddirections = new Queue<bool> (new[] {false, false, true});
	public Queue<bool> childshowdirections = new Queue<bool> (new[] {false, true});
	public Queue<bool> managerdirections = new Queue<bool> (new[] {false, false, true});
	public Queue<bool> corneliadirections = new Queue<bool> (new[] {false, false, true});
	public Queue<bool> tvdirections = new Queue<bool> (new[] {false, true, false, true, false, true, false, true, false, true});
	public Queue<bool> pygodirections = new Queue<bool> (new[] {false, false, true});
	public Queue<bool> milandirections = new Queue<bool> (new[] {false, false, true, true});
	public Queue<bool> russetdirections = new Queue<bool> (new[] {false});
	public Queue<bool> breakindirections = new Queue<bool> (new[] {true});
	public Queue<bool> empty1;


	public List<string> Usable;

	private Animator anim;


	// Use this for initialization
	void Start () {
		flashback = GameObject.Find ("Flashback");
		player = FindObjectOfType<Player> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();
		TopicChoice = FindObjectOfType<TopicChoice> ();
		Usable = new List<string> (){"GREET", "MYDEATH", "HOTEL", "SERVICE", "CHECKIN", "CHECKOUT", "PASSWORDS", "CHILDREN'SSHOW", "BREAKIN", "MANAGER", "CORNELIA", "TV", "PYGO", "MILAN", "RUSSET"};
		anim = GetComponent<Animator> ();
	}

	public void OnMouseDown(){
		if (!DialogueManager.dialogueActive && player.cursor_value == 0) {
			player.talking = true;
			ptalking = true;
			DialogueManager.ShowBox(dialogue, false, false, false, false, "", "Pygo");
			TopicChoice.ShowBoxes (Usable, "Pygo");
		}
	}

	
	// Update is called once per frame
	void Update () {
		if (player == null)
			player = FindObjectOfType<Player> ();
		if (greeted && !DialogueManager.dialogueActive) {
			if (DialogueManager.flavortexts.Count == 0) {
				if (flashbacking) {
					flashback.GetComponent<UIFade> ().Reset ();
					anim.enabled = false;
					if (!player.check_topic ("PYGO"))
						player.add_topic ("PYGO");
					greeted = false;
					flashbacking = false;
					player.talking = false;
					gameObject.SetActive (false);
					player.pygogone = true;
				} else {
					anim.enabled = false;
					if (!player.check_topic ("PYGO"))
						player.add_topic ("PYGO");
					greeted = false;
					player.talking = false;
				}
			}
		}

		if (DialogueManager.dialogueActive && DialogueManager.flavortexts.Count != 0) {
			anim.enabled = true;
			anim.SetTrigger ("Splashing");
		}

		if (player.event6) {
			dialogue [0] = "So thirsty...";
		}
		if (player.check_topic ("CHILDREN'SSHOW")) {
			dialogue [0] = "Pygo!";
		}
//		if (TopicChoice.IsActive ()) {
//			if (Input.GetKey (KeyCode.Escape)) {
//				player.talking = false;
//				TopicChoice.Close ();
//				DialogueManager.ForceClose ();
//			}
//		}
		directions = new Queue<bool> (new[] {false, true, false, true, false, true, false, true, false, true, true, true});


		mydeathdirections = new Queue<bool> (new[] {false, true, true});
		hoteldirections = new Queue<bool> (new[] {false, false, true});
		servicedirections = new Queue<bool> (new[] {false, false, true});
		checkindirections = new Queue<bool> (new[] {false, true});
		checkoutdirections = new Queue<bool> (new[] {false, true, false, false, false, true});
		passworddirections = new Queue<bool> (new[] {false, false, true});
		childshowdirections = new Queue<bool> (new[] {true, false, true});
		managerdirections = new Queue<bool> (new[] {false, false, true});
		corneliadirections = new Queue<bool> (new[] {false, false, true});
		tvdirections = new Queue<bool> (new[] {false, true, false, true, false, true, false, true, false, true});
		pygodirections = new Queue<bool> (new[] {false, false, true});
		milandirections = new Queue<bool> (new[] {false, false, true, true});
		russetdirections = new Queue<bool> (new[] {false});
		breakindirections = new Queue<bool> (new[] {true});



	}

	public void returnChoice(GameObject imageobject){
		if (ptalking) {
			if (imageobject.name == "Image1") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text1.text), Choice1(TopicChoice.text1.text), true, false, true, false, "", "Pygo");
				greeted = true;
			}
			if (imageobject.name == "Image2") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text2.text), Choice1(TopicChoice.text2.text), true, false, true, false, "", "Pygo");
				greeted = true;
			}
			if (imageobject.name == "Image3") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text3.text), Choice1(TopicChoice.text3.text), true, false, true, false, "", "Pygo");
				greeted = true;
			}
			if (imageobject.name == "Image4") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), Choice1 (TopicChoice.text4.text), true, false, true, false, "", "Pygo");
				greeted = true;

			}
			if (imageobject.name == "Image5") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text5.text), Choice1 (TopicChoice.text5.text), true, false, true, false, "", "Pygo");
				greeted = true;

			}
			if (imageobject.name == "Image6") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text6.text), Choice1 (TopicChoice.text6.text), true, false, true, false, "", "Pygo");
				greeted = true;

			}
			if (imageobject.name == "Image7") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text7.text), Choice1 (TopicChoice.text7.text), true, false, true, false, "", "Pygo");
				greeted = true;

			}
			if (imageobject.name == "Image8") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text8.text), Choice1 (TopicChoice.text8.text), true, false, true, false, "", "Pygo");
				greeted = true;

			}
			if (imageobject.name == "Image9") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text2.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text9.text), Choice1 (TopicChoice.text9.text), true, false, true, false, "", "Pygo");
				greeted = true;

			}
			if (imageobject.name == "Image10") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text3.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text10.text), Choice1 (TopicChoice.text10.text), true, false, true, false, "", "Pygo");
				greeted = true;

			}
			if (imageobject.name == "Image11") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text11.text), Choice1 (TopicChoice.text11.text), true, false, true, false, "", "Pygo");
				greeted = true;

			}
			if (imageobject.name == "Image12") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text12.text), Choice1 (TopicChoice.text12.text), true, false, true, false, "", "Pygo");
				greeted = true;

			}
			if (imageobject.name == "Image13") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text13.text), Choice1 (TopicChoice.text13.text), true, false, true, false, "", "Pygo");
				greeted = true;

			}
			if (imageobject.name == "Image14") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text14.text), Choice1 (TopicChoice.text14.text), true, false, true, false, "", "Pygo");
				greeted = true;

			}
			if (imageobject.name == "Image15") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text15.text), Choice1 (TopicChoice.text15.text), true, false, true, false, "", "Pygo");
				greeted = true;

			}
			if (imageobject.name == "Image16") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text16.text), Choice1 (TopicChoice.text16.text), true, false, true, false, "", "Pygo");
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
			return breakin;
		}
		if (text == "CHILDREN'SSHOW") {
			if (!player.check_topic ("PYGOWATCH")) {
				player.add_topic ("PYGOWATCH");
			}
			flashbacking = true;
			return shows;
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
		if (text == "MYDEATH") {
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
		if (text == "CHILDREN'SSHOW") {
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
