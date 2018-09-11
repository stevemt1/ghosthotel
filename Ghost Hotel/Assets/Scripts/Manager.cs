using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	public DialogueManager DialogueManager;
//	public DialogueManager playerDM;
//	public AcquiredBox Box;
	public TopicChoice TopicChoice;
	public Player player;
	public bool mtalking;
	public bool greeted = false;
	public Sprite nonglow;
	public Sprite glow;
	[TextArea (1,4)]
	public string[] dialogue;
	[TextArea (1,20)]
	public string[] greet;
	[TextArea (1,20)]
	public string[] nowater;
	public string[] empty;
	public Queue<bool> empty1;
	public Queue<bool> directions = new Queue<bool> (new[] {false, true, false, true, false, true, true, false, true, false, false, true, false, false, true, false, false, false, true, false, false, true, true, false});
	public Queue<bool> nowaterdirections = new Queue<bool> (new[] {true, false, true, false, false, false, true});
	public GameObject keys;

	public List<string> Usable;


	void Start(){
		player = FindObjectOfType<Player> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();
//		Box = FindObjectOfType<AcquiredBox> ();
		TopicChoice = FindObjectOfType<TopicChoice> ();
		Usable = new List<string> (){"GREET"};
	}


	public void OnMouseDown(){
		if (!DialogueManager.dialogueActive) {
			player.talking = true;
			mtalking = true;
//			DialogueManager.ShowBox (dialogue, true, "Ana", "Manager");
			DialogueManager.ShowBox(dialogue, false, false, false, false, "", "Manager");
			TopicChoice.ShowBoxes (Usable, "Manager");
		}
	}

	void Update(){
		if (greeted && !DialogueManager.dialogueActive) {
			if (DialogueManager.flavortexts.Count == 0) {
				if (!player.check_topic("WATER"))
					player.add_topic ("WATER");
				if (!player.check_item ("Keys")) {
					player.add_item ("Keys");
					player.add_sprite_item (keys.GetComponent<SpriteRenderer> ().sprite);
				}
//				playerDM.ForceClose ();
//				Box.ShowBox ();
				greeted = false;
				player.talking = false;
			}
		}
//		if (TopicChoice.IsActive ()) {
//			if (Input.GetKey (KeyCode.Escape)) {
//				player.talking = false;
//				TopicChoice.Close ();
//				DialogueManager.ForceClose ();
//			}
//		}
		directions = new Queue<bool> (new[] {false, true, false, true, false, true, true, false, true, false, false, true, false, false, true, false, false, false, true, false, false, true, true, false});
		nowaterdirections = new Queue<bool> (new[] {true, false, true, false, false, false, true});
	}


	public void returnChoice(GameObject imageobject){
		if (mtalking) {
			if (imageobject.name == "Image1") {
				TopicChoice.Close ();
//				DialogueManager.ShowBox (Choice (TopicChoice.text1.text), true, "Ana", "Manager");
				DialogueManager.ShowBox (Choice (TopicChoice.text1.text), Choice1(TopicChoice.text1.text), true, false, true, false, "", "Manager");
				greeted = true;
			}
			if (imageobject.name == "Image2") {
				TopicChoice.Close ();
				DialogueManager.ShowBox (Choice (TopicChoice.text2.text), Choice1(TopicChoice.text2.text), true, false, true, false, "", "Manager");
				greeted = true;
			}
		}
	}

	public string[] Choice(string text){
		if (text == "GREET") {
			return greet;
		}
		if (text == "NOWATER") {
			return nowater;
		}
		else 
			return empty;
	}
	public Queue<bool> Choice1(string text){
		if (text == "GREET") {
			return directions;
		}
		if (text == "NOWATER") {
			return nowaterdirections;
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
