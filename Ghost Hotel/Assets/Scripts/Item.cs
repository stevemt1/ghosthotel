using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour {

	public Player player;
	public Sprite oldsprite;
	public Sprite newsprite;
	public Sprite nonglow;
	public Sprite nonglow1;
	public Sprite glow;
	public Sprite glow1;
	public bool change;
	public bool taken;
	public bool single;
	public Text text;
	[TextArea (1,10)]
	public string[] flavortext;
	[TextArea (1,10)]
	public string[] flavortext1;
	public GameObject itemwanted;
	public DialogueManager DialogueManager;
	private GameObject Event;

	//Audio
	private GameObject SoundEffectManager;
	public AudioClip onClickSound;
	private AudioSource default1;
	private AudioSource default2;
	private AudioSource SoundEffectSource;
	public bool hasUniqueAudio = false;
	public bool isSegmentedAudio = false;
	public float aTimeStart;
	public float aTimeStop;

	// Use this for initialization
	void Start () {
		DialogueManager = FindObjectOfType<DialogueManager> ();
//		Box = FindObjectOfType<AcquiredBox> ();
		player = FindObjectOfType<Player>();
//		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().check_item (gameObject.name))
//			GameObject.Destroy (gameObject);
		if (player.check_item (gameObject.name)) {
			Destroy (gameObject);
		}
		//Audio
		SoundEffectManager = GameObject.FindGameObjectWithTag ("soundeffects");
		AudioSource [] audiolist = SoundEffectManager.GetComponents<AudioSource> ();
		SoundEffectSource = audiolist [0];
		default1 = audiolist [1];
		default2 = audiolist [2];
	}

//	void OnTriggerStay2D(Collider2D col)
//	{
//		if (Input.GetKey (KeyCode.C))
//		{
//			//interaction with object
//			if (col.transform.tag == "Player" && transform.tag == "interactable") {
//				text.text = flavortext;
//				StartCoroutine (Showtext (1));
//			}
//			//entrances
//			if (col.transform.tag == "Player" && transform.tag == "door") {
//				SceneManager.LoadScene (scene);
//			}
//			//collect item
//			if (col.transform.tag == "Player" && transform.tag == "item") {
//				col.GetComponent<Player> ().add_item (gameObject.name);
//				text.text = flavortext;
//				StartCoroutine (Showitemtext (1));
//			}
//
//		}
//	}
	void OnMouseEnter(){
		if (gameObject.GetComponent<Animator>() != null){
			gameObject.GetComponent<Animator> ().enabled = false;
		}

		if (taken && GetComponent<SpriteRenderer>().sprite == newsprite)
			gameObject.GetComponent<SpriteRenderer> ().sprite = glow1;
		else if (change && gameObject.GetComponent<SpriteRenderer> ().sprite == newsprite)
			gameObject.GetComponent<SpriteRenderer> ().sprite = glow1;
		else
			gameObject.GetComponent<SpriteRenderer> ().sprite = glow;
	}

	void OnMouseExit(){
		if (gameObject.GetComponent<Animator>() != null){
			gameObject.GetComponent<Animator> ().enabled = true;
		}
		if (taken && (GetComponent<SpriteRenderer>().sprite == glow1 || gameObject.GetComponent<SpriteRenderer>().sprite == newsprite))
			gameObject.GetComponent<SpriteRenderer> ().sprite = nonglow1;
		else if (change && (gameObject.GetComponent<SpriteRenderer> ().sprite == glow1 || gameObject.GetComponent<SpriteRenderer> ().sprite == newsprite))
			gameObject.GetComponent<SpriteRenderer> ().sprite = nonglow1;
		else
			gameObject.GetComponent<SpriteRenderer> ().sprite = nonglow;
	}

	void OnMouseDown(){		
		//Audio
		if (hasUniqueAudio) {
			SoundEffectSource.clip = onClickSound;
		} 
/*		else {
			int defaultSound = Random.Range (1, 3);
			switch (defaultSound) {
			case 2:
				default2.Play();
				print ("hmm2");
				break;
			default:
				default1.Play();
				print ("hmm1");
				break;
			}
		}
*/		if(!DialogueManager.dialogueActive && !player.talking){
			if (!isSegmentedAudio) {
				playAudio(0.01f,-1.0f);
			} 
			else {
				playAudio (aTimeStart, aTimeStop);
			
			}
		}

		if (gameObject.transform.tag == "interactable" && !DialogueManager.dialogueActive && !player.talking) {

			if ((gameObject.name == "Rotary Phone" || gameObject.name == "Service Bell") && player.check_item ("Phone Book")) {
				DialogueManager.ForceClose ();
			}
			if (gameObject.name == "Toilet2" && player.check_topic ("NOWATER")) {
				DialogueManager.ShowBox (flavortext1, true, false, false, false, "", "");
			}
			if (gameObject.name == "Hotel Room Door1" && player.check_topic ("ROOM1502")) {
				if (!player.check_topic("MEMORY"))
					player.add_topic ("MEMORY");
				DialogueManager.ForceClose ();
			}
			if (gameObject.name == "Safe" && player.check_topic ("SAFEKEYCODE")) {
				DialogueManager.ShowBox (flavortext1, true, false, false, false, "", "");
				if (!player.check_item (itemwanted.name)) {
					player.add_item (itemwanted.name);
					player.add_sprite_item (itemwanted.GetComponent<SpriteRenderer> ().sprite);
				}
			}
			if (taken && (GetComponent<SpriteRenderer> ().sprite == glow1 || gameObject.GetComponent<SpriteRenderer> ().sprite == newsprite)) {
				DialogueManager.ForceClose ();
				DialogueManager.ShowBox (flavortext1, true, false, false, false, "", "");
			} else {
				if (!DialogueManager.dialogueActive) {
					DialogueManager.ForceClose ();
					DialogueManager.ShowBox (flavortext, true, false, false, false, "", "");
				}
			}
			if (change) {
				switchImage ();
			}
//			StartCoroutine (Showtext (1));
		}
		if (gameObject.transform.tag == "item" && !DialogueManager.dialogueActive && !player.talking && !player.check_item (itemwanted.name)) {
			if (GetComponent<SpriteRenderer> ().sprite == nonglow1 || GetComponent<SpriteRenderer> ().sprite == glow1 || GetComponent<SpriteRenderer> ().sprite == newsprite) {
				DialogueManager.ShowBox (flavortext1, true, false, false, false, "", "");
			} else {
				if (!player.check_item(itemwanted.name)){
					if (itemwanted.name == "Candy" && player.candy)
						DialogueManager.ShowBox (flavortext1, true, false, false, false, "", "");
					else {
						player.add_item (itemwanted.name);
						if (!single)
							player.add_sprite_item (itemwanted.GetComponent<SpriteRenderer> ().sprite);
						else
							player.add_sprite_item (nonglow);
						itemwanted.SetActive (false);
						DialogueManager.ShowBox (flavortext, true, false, false, false, "", "");
					}

	//			Box.ShowBox ();
					//StartCoroutine (Showitemtext (1));

					if (change) {
						switchImage ();
					}
				}
			}
		} 
	}

//	IEnumerator Showtext (float showtime){
//		text.gameObject.SetActive (true);
//		yield return new WaitForSeconds (showtime);
//		text.gameObject.SetActive (false);
//	}
//
//	IEnumerator Showitemtext (float showtime){
//		text.gameObject.SetActive (true);
//		yield return new WaitForSeconds (showtime);
//		text.gameObject.SetActive (false);
//		Destroy (gameObject);
//	}

	public void switchImage(){
		if (gameObject.GetComponent<SpriteRenderer> ().sprite == newsprite)
			gameObject.GetComponent<SpriteRenderer> ().sprite = oldsprite;
		else
			gameObject.GetComponent<SpriteRenderer> ().sprite = newsprite;
	}
	void playAudio (float timeStart, float timeEnd) {
		if (hasUniqueAudio) {
//			print ("playing unique audio for " + onClickSound.name);
			SoundEffectSource.clip = onClickSound;
			SoundEffectSource.time = timeStart;
			SoundEffectSource.Play ();
		} 
		else {
			int defaultSound = Random.Range (1, 3);
			switch (defaultSound) {
			case 2:
				default2.Play();
				break;
			default:
				default1.Play();
				break;
			}
		}
		if (timeEnd > 0)
			StartCoroutine (delaySoundStop (timeEnd));
	}

	IEnumerator delaySoundStop(float timeEnd){
		while (SoundEffectSource.time < timeEnd) {
			yield return null;
		}
		SoundEffectSource.Stop ();
		default1.Stop ();
		default2.Stop ();
	}
}
