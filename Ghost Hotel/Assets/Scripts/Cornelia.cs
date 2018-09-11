using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cornelia : MonoBehaviour {

	public Player player;
	public DialogueManager DialogueManager;
//	public DialogueManager playerDM;
//	private AcquiredBox Box;
	public Sprite nonglow;
	public Sprite glow;
	public TopicChoice TopicChoice;
	public List<string> Usable;
	public bool greeted;
	public bool deathed;
	public bool checkind;
	public bool managered;
	public bool ctalking;
	public bool greetedAlready;
	[TextArea (1,2)]
	public string[] dialogue;
	[TextArea (1,30)]
	public string[] greet;
	[TextArea (1,20)]
	public string[] greet2;
	[TextArea (1,10)]
	public string[] death;
	[TextArea (1,10)]
	public string[] checkin;
	[TextArea (1,10)]
	public string[] manager;
	[TextArea (1,10)]
	public string[] pygo;
	[TextArea (1,10)]
	public string[] milan;
	[TextArea (1, 15)]
	public string[] service;

	[TextArea (1,20)]
	public string[] hotelLimbo;
	[TextArea (1,20)]
	public string[] checkOut;
	[TextArea (1,20)]
	public string[] passwords;
	[TextArea (1,20)]
	public string[] childshow;
	[TextArea (1,20)]
	public string[] cornelia;
	[TextArea (1,20)]
	public string[] television;
	[TextArea (1,20)]
	public string[] russet;
	[TextArea (1,20)]
	public string[] breakin;


	public string[] empty;
	public Queue<bool> directions = new Queue<bool> (new [] {false, true, false, false, true, true, false, false, false, false, true, true, true, true, false, true, false, false, false, false, false, true, true, true});
	public Queue<bool> greet2directions = new Queue<bool> (new [] {false, false,false, false});
	public Queue<bool> deathdirections = new Queue<bool> (new[] {false, true, false, true});
	public Queue<bool> checkindirections = new Queue<bool> (new[] {false, false, false, true, false, false, false, false, true});
	public Queue<bool> managerdirections = new Queue<bool> (new[] {false, false, false, true, false});
	public Queue<bool> pygodirections = new Queue<bool> (new[] {false, true, false, false, false});
	public Queue<bool> milandirections = new Queue<bool> (new[] {true, false, true, true});
	public Queue<bool> servicedirections = new Queue<bool> (new[] {false, true, false, false, true, false, false, true});
	public Queue<bool> hoteldirections = new Queue<bool> (new[] {false, false, false, true, false, false, false, false, true});
	public Queue<bool> checkoutdirections = new Queue<bool> (new[] {false, false, true, false, true, false, true});
	public Queue<bool> passwordsdirections = new Queue<bool> (new[] {false, false, true});
	public Queue<bool> childshowdirections = new Queue<bool> (new[] {false, false, false, false, false});
	public Queue<bool> corneliadirections = new Queue<bool> (new[] {false, false, true});
	public Queue<bool> tvdirections = new Queue<bool> (new[] {false, true, false, true});
	public Queue<bool> russetdirections = new Queue<bool> (new[] {false, false, false, true});
	public Queue<bool> breakindirections = new Queue<bool> (new[] {true});


	public Queue<bool> empty1;

	void Start(){
		greetedAlready = false;
		player = FindObjectOfType<Player> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();
//		Box = FindObjectOfType<AcquiredBox> ();
		TopicChoice = FindObjectOfType<TopicChoice> ();
		Usable = new List<string> (){"GREET", "MYDEATH", "HOTEL", "SERVICE", "CHECK IN", "CHECKOUT", "PASSWORDS", "CHILDRENSHOW", "BREAKIN", "MANAGER", "CORNELIA", "TV", "PYGO", "MILAN", "RUSSET"};
			}

	void OnMouseDown(){
		if (!DialogueManager.dialogueActive && player.check_topic("GREET") && player.cursor_value == 0) {
			player.talking = true;
			ctalking = true;
//			DialogueManager.ShowBox (dialogue, false, "Cornelia", "Ana");
			DialogueManager.ShowBox (dialogue, false, false, false, false, "", "Cornelia");
			TopicChoice.ShowBoxes (Usable, "Cornelia");
		}
	}

	void Update(){
		if (greeted && !DialogueManager.dialogueActive) {
			if (DialogueManager.flavortexts.Count == 0) {
				
//				Box.ShowBox ();
				greeted = false;
				player.talking = false;
			}
		}
//		if (ctalking && !DialogueManager.dialogueActive) {
//			playerDM.ForceClose ();
//			ctalking = false;
//		}
//		if (TopicChoice.IsActive()) {
//			if (Input.GetKey (KeyCode.Escape)) {
//				TopicChoice.Close ();
//				player.talking = false;
//				DialogueManager.ForceClose ();
//			}
//		}

		if (player.event8) {
			dialogue [0] = "Oh, so NOW you want to talk to me. Oh, dear, there IS something I feel I wanted to ask you for.";
		}


		directions = new Queue<bool> (new [] {false, true, false, false, true, true, false, false, false, false, true, true, true, true, false, true, false, false, false, false, false, true, true, true});
		deathdirections = new Queue<bool> (new[] {false, true, false, true});
		checkindirections = new Queue<bool> (new[] {false, false, false, true, false, false, false, false, true});
		managerdirections = new Queue<bool> (new[] {false, false, false, true, false});
		pygodirections = new Queue<bool> (new[] {false, true, false, false, false});
		milandirections = new Queue<bool> (new[] {true, false, true, true});
		//milandirections = new Queue<bool> (new[] {false, true, false, false, true, false, false, true});
		corneliadirections = new Queue<bool> (new[] {false, false, true});

		greet2directions = new Queue<bool> (new [] {false, false,false, false});
		servicedirections = new Queue<bool> (new[] {false, true, false, false, true, false, false, true});
		hoteldirections = new Queue<bool> (new[] {false, false, false, true, false, false, false, false, true});
		checkoutdirections = new Queue<bool> (new[] {false, false, true, false, true, false, true});
		passwordsdirections = new Queue<bool> (new[] {false, false, true});
		childshowdirections = new Queue<bool> (new[] {false, false, false, false, false});
		tvdirections = new Queue<bool> (new[] {false, true, false, true});
		russetdirections = new Queue<bool> (new[] {false, false, false, true});
		breakindirections = new Queue<bool> (new[] {true});

	}

	public void returnChoice(GameObject imageobject){
//		playerDM.ForceClose ();
		DialogueManager.ForceClose ();
		if (ctalking) {
			if (imageobject.name == "Image1") {
				TopicChoice.Close();
//				DialogueManager.ShowBox (Choice (TopicChoice.text1.text), true, "Ana", "Cornelia");
				DialogueManager.ShowBox (Choice (TopicChoice.text1.text), Choice1 (TopicChoice.text1.text), true, false, true, false, "", "Cornelia");
				if (!player.check_topic("CORNELIA"))
					player.add_topic ("CORNELIA");
				if (!player.check_topic("MYDEATH"))
					player.add_topic ("MYDEATH");
			}
			if (imageobject.name == "Image2") {
				TopicChoice.Close ();
//				DialogueManager.ShowBox (Choice (TopicChoice.text2.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text2.text), Choice1 (TopicChoice.text2.text), true, false, true, false, "", "Cornelia");
			}
			if (imageobject.name == "Image3") {
				TopicChoice.Close ();
//				DialogueManager.ShowBox (Choice (TopicChoice.text3.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text3.text), Choice1 (TopicChoice.text3.text), true, false, true, false, "", "Cornelia");

			}
			if (imageobject.name == "Image4") {
				TopicChoice.Close ();
//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), Choice1 (TopicChoice.text4.text), true, false, true, false, "", "Cornelia");

			}
			if (imageobject.name == "Image5") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text5.text), Choice1 (TopicChoice.text5.text), true, false, true, false, "", "Cornelia");

			}
			if (imageobject.name == "Image6") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text6.text), Choice1 (TopicChoice.text6.text), true, false, true, false, "", "Cornelia");

			}
			if (imageobject.name == "Image7") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text7.text), Choice1 (TopicChoice.text7.text), true, false, true, false, "", "Cornelia");

			}
			if (imageobject.name == "Image8") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text8.text), Choice1 (TopicChoice.text8.text), true, false, true, false, "", "Cornelia");

			}
			if (imageobject.name == "Image9") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text2.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text9.text), Choice1 (TopicChoice.text9.text), true, false, true, false, "", "Cornelia");
			}
			if (imageobject.name == "Image10") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text3.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text10.text), Choice1 (TopicChoice.text10.text), true, false, true, false, "", "Cornelia");

			}
			if (imageobject.name == "Image11") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text11.text), Choice1 (TopicChoice.text11.text), true, false, true, false, "", "Cornelia");

			}
			if (imageobject.name == "Image12") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text12.text), Choice1 (TopicChoice.text12.text), true, false, true, false, "", "Cornelia");

			}
			if (imageobject.name == "Image13") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text13.text), Choice1 (TopicChoice.text13.text), true, false, true, false, "", "Cornelia");

			}
			if (imageobject.name == "Image14") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text14.text), Choice1 (TopicChoice.text14.text), true, false, true, false, "", "Cornelia");

			}
			if (imageobject.name == "Image15") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text15.text), Choice1 (TopicChoice.text15.text), true, false, true, false, "", "Cornelia");

			}
			if (imageobject.name == "Image16") {
				TopicChoice.Close ();
				//				DialogueManager.ShowBox (Choice (TopicChoice.text4.text), true, "Cornelia", "Ana");
				DialogueManager.ShowBox (Choice (TopicChoice.text16.text), Choice1 (TopicChoice.text16.text), true, false, true, false, "", "Cornelia");

			}
		}
		greeted = true;
	}

	public string[] Choice(string text){
		if (text == "GREET") {
			if (greetedAlready) {
				return greet2;
			} else {
				return greet;
			}
		}
		if (text == "MYDEATH") {
			return death;
		}
		if (text == "CHECK IN") {
			return checkin;
		}
		if (text == "MANAGER") {
			return manager;
		}
		if (text == "PYGO") {
			return pygo;
		}
		if (text == "MILAN") {
			return milan;
		}


		if (text == "HOTEL") {
			return hotelLimbo;
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
		if (text == "CORNELIA") {
			return cornelia;
		}
		if (text == "TV") {
			return television;
		}
		if (text == "RUSSET") {
			return russet;
		}
		if (text == "BREAKIN") {
			return breakin;
		}


		if (text == "SERVICE") {
			if (!player.check_topic ("GIVEVALUABLES")) {
				player.add_topic ("GIVEVALUABLES");
			}
			return service;
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
		if (text == "MYDEATH") {
			return deathdirections;
		}
		if (text == "CHECK IN") {
			return checkindirections;
		}
		if (text == "MANAGER") {
			return managerdirections;
		}
		if (text == "PYGO") {
			return pygodirections;
		}
		if (text == "MILAN") {
			return milandirections;
		}

		if (text == "HOTEL") {
			return hoteldirections;
		}
		if (text == "CHECKOUT") {
			return checkoutdirections;
		}
		if (text == "PASSWORDS") {
			return passwordsdirections;
		}
		if (text == "CHILDRENSHOW") {
			return childshowdirections;
		}
		if (text == "CORNELIA") {
			return corneliadirections;
		}
		if (text == "TV") {
			return tvdirections;
		}
		if (text == "RUSSET") {
			return russetdirections;
		}
		if (text == "BREAKIN") {
			return breakindirections;
		}



		if (text == "SERVICE") {
			return servicedirections;
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