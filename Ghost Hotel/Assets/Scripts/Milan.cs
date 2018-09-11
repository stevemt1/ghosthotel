using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Milan : MonoBehaviour {

	public DialogueManager DialogueManager;
	public TopicChoice TopicChoice;
	public Player player;
	public bool mtalking;
	public bool greeted = false;
	public Sprite nonglow;
	public Sprite glow;
	public GameObject reports;
	public Sprite thinking;
	private bool greetedAlready;
	[TextArea (1,4)]
	public string[] dialogue;
	[TextArea (1,20)]
	public string[] greet;
	[TextArea (1,20)]
	public string[] computer;
	[TextArea (1,20)]
	public string[] checkout;
	[TextArea (1,20)]
	public string[] passwords;
	[TextArea (1, 20)]
	public string[] service;

	[TextArea (1,20)]
	public string[] myDeath;
	[TextArea (1,20)]
	public string[] hotelLimbo;
	[TextArea (1,20)]
	public string[] checkIn;
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
	[TextArea (1,20)]
	public string[] greet2;


	public string[] empty;
	public Queue<bool> directions = new Queue<bool> (new[] {true, false, true, false, true, false, true, false, false, true, true, false, true, false, false, false, false, false, true, false, false, false});
	public Queue<bool> checkoutdirections = new Queue<bool> (new[] {false, false, false, true});
	public Queue<bool> passwordsdirections = new Queue<bool> (new[] {false, false, true, true, false, true, false, true, false, true, false, false, false, true, false, true});
	public Queue<bool> computerdirections = new Queue<bool> (new[] {false, true});
	public Queue<bool> servicedirections = new Queue<bool> (new[] {false, true, false});

	public Queue<bool> mydeathdirections = new Queue<bool> (new[] {false, false});
	public Queue<bool> hoteldirections = new Queue<bool> (new[] {false, false});
	public Queue<bool> checkindirections = new Queue<bool> (new[] {false, false, true});
	public Queue<bool> childshowdirections = new Queue<bool> (new[] {false, false, true, false});
	public Queue<bool> managerdirections = new Queue<bool> (new[] {false, false});
	public Queue<bool> corneliadirections = new Queue<bool> (new[] {false, false, false});
	public Queue<bool> tvdirections = new Queue<bool> (new[] {false});
	public Queue<bool> pygodirections = new Queue<bool> (new[] {false, false, false, false});
	public Queue<bool> milandirections = new Queue<bool> (new[] {false, true, false, false, true, false});
	public Queue<bool> russetdirections = new Queue<bool> (new[] {false});
	public Queue<bool> breakindirections = new Queue<bool> (new[] {true});
	public Queue<bool> greet2directions = new Queue<bool> (new[] {false, false});



	public Queue<bool> empty1;

	public List<string> Usable;


	// Use this for initialization
	void Start () {
		greetedAlready = false;
		player = FindObjectOfType<Player> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();
		TopicChoice = FindObjectOfType<TopicChoice> ();
		Usable = new List<string> (){"GREET", "MYDEATH", "HOTEL", "SERVICE", "CHECKIN", "CHECKOUT", "PASSWORDS", "CHILDRENSHOW", "BREAKIN", "MANAGER", "CORNELIA", "TV", "PYGO", "MILAN", "RUSSET"};
			}

	public void OnMouseDown(){
		if (!DialogueManager.dialogueActive && player.cursor_value == 0) {
			player.talking = true;
			mtalking = true;
			DialogueManager.ShowBox(dialogue, false, false, false, false, "", "Milan");
			TopicChoice.ShowBoxes (Usable, "Milan");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (mtalking) {
			GetComponent<SpriteRenderer> ().sprite = thinking;
		}
		if (greeted && !DialogueManager.dialogueActive) {
			if (DialogueManager.flavortexts.Count == 0) {
				if (player.check_topic("COMPUTER") && !player.check_topic ("CHECKOUT")) {
					player.add_topic ("CHECKOUT");
					dialogue [0] = "Ugh, you again.";
				}
				if (!player.check_topic("MILAN")){
					player.add_topic ("MILAN");
				}
			}
			greeted = false;
			player.talking = false;
			mtalking = false;
			GetComponent<SpriteRenderer> ().sprite = nonglow;

		}
		if (DialogueManager.dialogueActive && DialogueManager.flavortexts.Count != 0) {
			GetComponent<SpriteRenderer> ().sprite = thinking;
		}

		if (player.event4 && !Usable.Contains("COMPUTER")) {
			Usable.Add ("COMPUTER");
			dialogue [0] = "Hmmm...? I'm tryin' to fix this TV. What's up?";
		}
		if (player.event6 && !Usable.Contains ("SERVICE")) {
			Usable.Add ("SERVICE");
			dialogue [0] = "Hmmm...? I'm tryin' to fix this TV. What's up?";
		}

//		if (TopicChoice.IsActive ()) {
//			if (Input.GetKey (KeyCode.Escape)) {
//				player.talking = false;
//				TopicChoice.Close ();
//				DialogueManager.ForceClose ();
//			}
//		}
		directions = new Queue<bool> (new[] {true, false, true, false, true, false, true, false, false, true, true, false, true, false, false, false, false, false, true, false, false, false});
		checkoutdirections = new Queue<bool> (new[] {false, false, false, true});
		computerdirections = new Queue<bool> (new[] {false, true});
		passwordsdirections = new Queue<bool> (new[] {false, false, true, true, false, true, false, true, false, true, false, false, false, true, false, true});
		servicedirections = new Queue<bool> (new[] {false, true, false});

		mydeathdirections = new Queue<bool> (new[] {false, false});
		hoteldirections = new Queue<bool> (new[] {false, false});
		checkindirections = new Queue<bool> (new[] {false, false, true});
		childshowdirections = new Queue<bool> (new[] {false, false, true, false});
		managerdirections = new Queue<bool> (new[] {false, false});
		corneliadirections = new Queue<bool> (new[] {false, false, false});
		tvdirections = new Queue<bool> (new[] {false});
		pygodirections = new Queue<bool> (new[] {false, false, false, false});
		milandirections = new Queue<bool> (new[] {false, true, false, false, true, false});
		russetdirections = new Queue<bool> (new[] {false});
		breakindirections = new Queue<bool> (new[] {true});
		greet2directions = new Queue<bool> (new[] { false, false });
	}

	public void returnChoice(GameObject imageobject){
		if (mtalking) {
			if (imageobject.name == "Image1") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text1.text), Choice1(TopicChoice.text1.text), true, false, true, false, "", "Milan");
				greeted = true;
			}
			if (imageobject.name == "Image2") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text2.text), Choice1(TopicChoice.text2.text), true, false, true, false, "", "Milan");
				greeted = true;
			}

			if (imageobject.name == "Image3") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text3.text), Choice1(TopicChoice.text3.text), true, false, true, false, "", "Milan");
				greeted = true;
			}
			if (imageobject.name == "Image4") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), Choice1(TopicChoice.text4.text), true, false, true, false, "", "Milan");
				greeted = true;
			}
			if (imageobject.name == "Image5") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text5.text), Choice1(TopicChoice.text5.text), true, false, true, false, "", "Milan");
				greeted = true;
			}
			if (imageobject.name == "Image6") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text6.text), Choice1(TopicChoice.text6.text), true, false, true, false, "", "Milan");
				greeted = true;
			}
			if (imageobject.name == "Image7") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text7.text), Choice1(TopicChoice.text7.text), true, false, true, false, "", "Milan");
				greeted = true;
			}

			if (imageobject.name == "Image8") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text8.text), Choice1(TopicChoice.text8.text), true, false, true, false, "", "Milan");
				greeted = true;
			}
			if (imageobject.name == "Image9") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text9.text), Choice1(TopicChoice.text9.text), true, false, true, false, "", "Milan");
				greeted = true;
			}
			if (imageobject.name == "Image10") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text10.text), Choice1(TopicChoice.text10.text), true, false, true, false, "", "Milan");
				greeted = true;
			}
			if (imageobject.name == "Image11") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text11.text), Choice1(TopicChoice.text11.text), true, false, true, false, "", "Milan");
				greeted = true;
			}
			if (imageobject.name == "Image12") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text12.text), Choice1(TopicChoice.text12.text), true, false, true, false, "", "Milan");
				greeted = true;
			}
			if (imageobject.name == "Image13") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text13.text), Choice1(TopicChoice.text13.text), true, false, true, false, "", "Milan");
				greeted = true;
			}

			if (imageobject.name == "Image14") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text14.text), Choice1(TopicChoice.text14.text), true, false, true, false, "", "Milan");
				greeted = true;
			}
			if (imageobject.name == "Image15") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text15.text), Choice1(TopicChoice.text15.text), true, false, true, false, "", "Milan");
				greeted = true;
			}
			if (imageobject.name == "Image16") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text16.text), Choice1(TopicChoice.text16.text), true, false, true, false, "", "Milan");
				greeted = true;
			}
		}
	}

	public string[] Choice(string text){
		if (text == "GREET") {
			if (greetedAlready) {
				return greet2;
			} else {
				return greet;
			}
		}
		if (text == "CHECKOUT") {
			return checkout;
		}
		if (text == "COMPUTER") {
			return computer;
		}
		if (text == "PASSWORDS") {
			if (!player.check_item("Credit Report")){
				player.add_item ("Credit Report");
				player.add_sprite_item (reports.GetComponent<SpriteRenderer>().sprite);
			}
			return passwords;
		}
		if (text == "SERVICE") {
			if (!player.check_topic ("TV")) {
				player.add_topic ("TV");
			}
			return service;
		}
		if (text == "MYDEATH") {
			return myDeath;
		}
		if (text == "HOTEL") {
			return hotelLimbo;
		}
		if (text == "CHECKIN") {
			return checkIn;
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
			return breakin;
		}


		else 
			return empty;
	}
	public Queue<bool> Choice1(string text){
		if (text == "GREET") {
			if (greetedAlready) {
				return greet2directions;
			} else {
				greetedAlready = true;
				return directions;
			}
		}
		if (text == "CHECKOUT") {
			return checkoutdirections;
		}
		if (text == "COMPUTER") {
			return computerdirections;
		}
		if (text == "PASSWORDS") {
			return passwordsdirections;
		}
		if (text == "SERVICE") {
			return servicedirections;
		}
		if (text == "MYDEATH") {
			return mydeathdirections;
		}
		if (text == "HOTEL") {
			return hoteldirections;
		}
		if (text == "CHECKIN") {
			return checkindirections;
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
