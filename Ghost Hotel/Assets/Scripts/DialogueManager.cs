using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public GameObject dialogueBox;
	public Text dialogueText;
	public Queue<string> flavortexts;
	public Queue<bool> dir;
	public bool onenext = false;
	public bool player1 = true;
	public string nexttext;
	public bool donezo = false;
	public bool fulltext = false;
	public bool conve = false;
	public string charname;
	public float letterPause = 0.03f;
	public bool convo = false;
	public int i = 0;
	public TopicChoice topic;
//	public DialogueManager otherDM = null;
	public bool second = false;
	public bool alternate = false;
	public Sprite leftbubble;
	public Sprite rightbubble;
	public bool dialogueActive = false;
	public float timeBetweenSpace = .6f;
	public float timer = 0f;
	private float timestamp;


	public GameObject leftperson;
	public GameObject dore;
	public GameObject doreright;
	public GameObject cabbie;
	public GameObject ana;
	public GameObject corn;
	public GameObject mana;
	public GameObject peng;
	public GameObject pygoleft;
	public GameObject russ;
	public GameObject mila;
	public GameObject personleft;
	public GameObject persona;
	public GameObject currentperson = null;

	void Start(){
		flavortexts = new Queue<string> ();
		dir = new Queue<bool> ();
		topic = FindObjectOfType<TopicChoice> ();
	}

	void Update(){
		if (currentperson == null)
			currentperson = corn;
		if (leftperson == null)
			leftperson = ana;
		if (dialogueActive) {
//			if (timer > 1f && (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0))) {
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
				
				Close ();
//				timer = 0f;
			}
		}
		if (convo) {
			dialogueBox.GetComponent<Image> ().sprite = leftbubble;
		}
		if (!convo) {
			dialogueBox.GetComponent<Image> ().sprite = rightbubble;
		}
//		timer += .08f;
	}

	public void Close(){
		if (donezo) {
			donezo = false;
			dialogueBox.SetActive (false);
			dialogueActive = false;
			leftperson.SetActive (false);
			currentperson.SetActive (false);
			if (alternate) {
				alternate = false;
			}
		}
		if (dialogueActive && flavortexts.Count == 0 && !topic.IsActive ()) {
			fulltext = false;
			StopAllCoroutines ();
			dialogueText.text = nexttext;
//			convo = false;
//			i = 0;
//			dialogueBox.SetActive (false);
//			dialogueActive = false;
//			if (otherDM != null)
//				otherDM.ForceClose ();
			donezo = true;
		}
		else if (fulltext ){
			fulltext = false;
			if (alternate) {
				StopAllCoroutines ();
				convo = !convo;
				if (!convo) {
					leftperson.SetActive (false);
					currentperson.SetActive (true);
				} else {
					leftperson.SetActive (true);
					currentperson.SetActive (false);
				}

			}
			if (!alternate && conve) {
				StopAllCoroutines ();
				convo = dir.Dequeue ();
				if (convo) {
					leftperson.SetActive (true);
					currentperson.SetActive (false);
				} else {
					leftperson.SetActive (false);
					currentperson.SetActive (true);
				}
			}
			if (flavortexts.Count != 0)
				StopAllCoroutines ();
			StartCoroutine (TypeText ());
		} else {
			StopAllCoroutines ();
			dialogueText.text = nexttext;
			fulltext = true;
		}
//		if (onenext) {
//			onenext = false;
//			StartCoroutine (TypeText ());
//		
//		} else if (!convo) {
//			StopAllCoroutines ();
//			dialogueText.text = nexttext;
//			onenext = true;
//		} else {
//
//		}
	}

	public void ForceClose(){
		StopAllCoroutines ();
		dialogueBox.SetActive (false);
		dialogueActive = false;
		leftperson.SetActive (false);
		currentperson.SetActive (false);
	}

//	public void ShowBox1(string[] dialogue){
//		StopAllCoroutines();
//		dialogueText.text = "";
//		nexttext = "";
//		flavortexts.Clear();
//		foreach (string flavor in dialogue) {
//			flavortexts.Enqueue (flavor);
//		}
//		dialogueActive = true;
//		dialogueBox.SetActive (true);
//		StartCoroutine (TypeText());
//	}
	public void ShowBox(string[] dialogue, bool startconv, bool alt, bool conver, bool other, string left, string person){
		convo = startconv;
		conve = conver;
		if (other) {
			if (left == "Dore"){
				leftperson = dore;
			}
			if (left == "Person") {
				leftperson = personleft;
			}
			if (left == "Pygo") {
				leftperson = pygoleft;
			}
			if (left == "") {
				leftperson = ana;
			}
		} else {
			leftperson = ana;
		}
		if (convo) {
			dialogueBox.GetComponent<Image> ().sprite = leftbubble;
		}
		if (!convo) {
			dialogueBox.GetComponent<Image> ().sprite = rightbubble;
		}
		alternate = alt;
		if (person == "Cornelia")
			currentperson = corn;
		if (person == "Manager")
			currentperson = mana;
		if (person == "Milan")
			currentperson = mila;
		if (person == "Pygo")
			currentperson = peng;
		if (person == "Russet")
			currentperson = russ;
		if (person == "")
			currentperson = ana;
		if (person == "Dore")
			currentperson = doreright;
		if (person == "Cabbie")
			currentperson = cabbie;
		if (person == "Person")
			currentperson = persona;
		//		otherDM = other;
		//		otherDM.convo = true;
		StopAllCoroutines();
		nexttext = "";
		dialogueText.text = "";
		//		other.dialogueText.text = "";
		flavortexts.Clear();
		foreach (string flavor in dialogue) {
			flavortexts.Enqueue (flavor);
		}
		dialogueActive = true;
		dialogueBox.SetActive (true);
		if (dialogueBox.GetComponent<Image> ().sprite == leftbubble) {
			leftperson.SetActive (true);
		} else {
			currentperson.SetActive (true);
		}
		//		other.dialogueBox.SetActive (true);
		StartCoroutine (TypeText());
	}

	public void ShowBox(string[] dialogue, Queue<bool> directions, bool startconv, bool alt, bool conver, bool other, string left, string person){
		convo = startconv;
		dir = directions;
		conve = conver;
		if (other) {
			if (left == "Dore"){
				leftperson = dore;
			}
			if (left == "Person") {
				leftperson = personleft;
			}
			if (left == "Pygo") {
				leftperson = pygoleft;
			}
			if (left == "") {
				leftperson = ana;
			}

		} else {
			leftperson = ana;
		}
		if (convo) {
			dialogueBox.GetComponent<Image> ().sprite = leftbubble;
		}
		if (!convo) {
			dialogueBox.GetComponent<Image> ().sprite = rightbubble;
		}
		alternate = alt;
		if (person == "Cornelia")
			currentperson = corn;
		if (person == "Manager")
			currentperson = mana;
		if (person == "Milan")
			currentperson = mila;
		if (person == "Pygo")
			currentperson = peng;
		if (person == "Russet")
			currentperson = russ;
		if (person == "Dore")
			currentperson = doreright;
		if (person == "Person")
			currentperson = persona;
		if (person == "Cabbie")
			currentperson = cabbie;
		//		otherDM = other;
		//		otherDM.convo = true;
		StopAllCoroutines();
		nexttext = "";
		dialogueText.text = "";
		//		other.dialogueText.text = "";
		flavortexts.Clear();
		foreach (string flavor in dialogue) {
			flavortexts.Enqueue (flavor);
		}
		dialogueActive = true;
		dialogueBox.SetActive (true);
		if (dialogueBox.GetComponent<Image> ().sprite == leftbubble) {
			leftperson.SetActive (true);
		} else {
			currentperson.SetActive (true);
		}
//				other.dialogueBox.SetActive (true);
		StartCoroutine (TypeText());
	}

	IEnumerator TypeText(){
		while (flavortexts.Count != 0) {
			nexttext = flavortexts.Dequeue ();
			if (nexttext != "") {
				dialogueText.text = "";
				foreach (char letter in nexttext.ToCharArray()) {
					dialogueText.text += letter;
					yield return new WaitForSeconds (letterPause);
				}
			}
			yield return new WaitForSeconds (30);
		}	
	}

//	IEnumerator ConvoText(DialogueManager other, bool player1){
//		while (flavortexts.Count != 0) {
//			nexttext = flavortexts.Dequeue ();
//			if (nexttext != ""){
//				if(!player1){
//					dialogueText.text = "";
//					foreach (char letter in nexttext.ToCharArray()) {
//						dialogueText.text += letter;
//						yield return new WaitForSeconds (letterPause);
//					}
//				}
//				else{
//					other.dialogueText.text = "";
//					foreach (char letter in nexttext.ToCharArray()) {
//						other.dialogueText.text += letter;
//						yield return new WaitForSeconds (letterPause);
//					}
//				}
//			} 
//			player1 = !player1;
//			yield return new WaitForSeconds (.4f);
//		}	
//	}
}
