using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUsed : MonoBehaviour {

	public DialogueManager DialogueManager;
	public Player player;
	public Camera cam;
	public bool Openerused = false;
	[TextArea (1,3)]
	public string[] phonebook;
	[TextArea (1,3)]
	public string[] keys;
	[TextArea (1,3)]
	public string[] fish;
	[TextArea (1,10)]
	public string[] pygo;
	[TextArea (1,10)]
	public string[] toliet;
	[TextArea (1,10)]
	public string[] russet;
	[TextArea (1,35)]
	public string[] russet2;
	[TextArea (1,35)]
	public string[] russet3;
	[TextArea (1,5)]
	public string[] walletcomp;
	[TextArea (1,15)]
	public string[] milan;
	[TextArea (1,15)]
	public string[] candy;
	[TextArea (1,30)]
	public string[] report;
	[TextArea (1,15)]
	public string[] dollar;
	[TextArea (1,30)]
	public string[] tvswitch;
	[TextArea (1,30)]
	public string[] mastercontrol;
	[TextArea (1,30)]
	public string[] valuables;
	[TextArea (1,30)]
	public string[] debit;
	[TextArea (1,30)]
	public string[] final;
	public bool pygogone;
	public bool russetgone;
	public bool once = true;
	public bool milanmove = false;
	public GameObject flashback;
	public bool flashbacking1 = false;
	public bool flashbacking2 = false;
	public bool flashbacking3 = false;
	public Pygo Pygo;
	public GameObject phonebookobject;
	public GameObject fishy;
	public GameObject fishy2;
	public GameObject dolla;
	public GameObject switches;
	public GameObject Gcandy;
	public GameObject wallet;
	public GameObject remote;
	public GameObject offdoor;
	public GameObject ChangeSceneObject;
	public GameObject bedroom1;
	public GameObject bedroom2;
	public GameObject bedroom3;
	public GameObject memory;
	public Queue<bool> directions = new Queue<bool> (new[] {false, true, true, false, true, false, true});
	public Queue<bool> directions2 = new Queue<bool> (new[] {true, true, false, true, true, true, true, true, false, false, false, false, true, false, false, true, false, false, true, true, true, true});
	public Queue<bool> directions3 = new Queue<bool> (new[] {true, false, false, false, true, false, true, false, false, true});
	public Queue<bool> directions4 = new Queue<bool> (new[] {true, false, true, false, false, false, true, false, false, false});
	public Queue<bool> directions5 = new Queue<bool> (new[] {true, true, false, true, false, true, true, false, true, true, false, false, true, false, false, false, false, true, false, false, true, false, false, true, true});
	public Queue<bool> directions6 = new Queue<bool> (new[] {true, false, true, true, false, true, false, false, true, false, true, false, true, true, false, true, false, false, true, false, false, false, false, true, true});
	public Queue<bool> directions7 = new Queue<bool> (new[] {true, false, false, true, false});
	public Queue<bool> directions8 = new Queue<bool> (new[] {true, false, false, true});
	public Queue<bool> directions9 = new Queue<bool> (new[] {true, false, true, false, false, true, false, true, true, false, true, false, false, true});
	public Queue<bool> directions10 = new Queue<bool> (new[] {true, true, false, false, true});
	public Queue<bool> directions11 = new Queue<bool> (new[] {true, true, false, true, false, false, true});



	public CursorMode curMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	public GameStateController gameStateScript;

	//Audio
	public GameObject SoundEffectManager;
	public AudioClip onClickSound;
	private AudioSource SoundEffectSource;
	public bool isSegmentedAudio = false;
	public float aTimeStart;
	public float aTimeStop;

	void Start(){
		flashback = GameObject.Find ("Flashback");
		cam = FindObjectOfType<Camera> ();
		player = FindObjectOfType<Player> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();
		//Audio
		SoundEffectManager = GameObject.FindGameObjectWithTag ("soundeffects");
		SoundEffectSource = SoundEffectManager.GetComponent<AudioSource> ();

		GameObject gameStateGO = GameObject.Find ("GameStateManager");
		gameStateScript = gameStateGO.GetComponent<GameStateController> ();
	}

	// Update is called once per frame
	void Update () {
		player = FindObjectOfType<Player> ();
		cam = FindObjectOfType<Camera> ();

		//if (Openerused && gameObject.name == "Telephone Booth") {
		/*if (Openerused && gameObject.name == "Telephone Booth") {
			player.add_item (phonebookobject.name);
			player.add_sprite_item (phonebookobject.GetComponent<SpriteRenderer>().sprite);
			Destroy (phonebookobject);
			DialogueManager.ShowBox1(phonebook);
			Openerused = false;
		}*/
		if (GameObject.FindGameObjectWithTag("Room").name == "Bedroom2" && player.check_topic("NOWATER")){
			if (GameObject.Find ("Water") != null)
				GameObject.Find ("Water").SetActive (false);
		}

		if (russetgone && DialogueManager.flavortexts.Count == 4 && once) {
			flashback.GetComponent<UIFade> ().Reset ();
			if (GameObject.FindObjectOfType<Russet>() != null)
				GameObject.FindObjectOfType<Russet> ().gameObject.SetActive (false);
			if (GameObject.FindObjectOfType<Cornelia>() != null)
				GameObject.FindObjectOfType<Cornelia> ().gameObject.SetActive (false);
			russetgone = false;
			once = false;
		}

		if (milanmove && player.event4 && DialogueManager.flavortexts.Count == 5) {
			flashback.GetComponent<UIFade> ().Reset ();
			player.transform.position = new Vector3(player.transform.position.x + 17, player.transform.position.y, player.transform.position.z);
			GameObject.Find ("Milan").transform.position = new Vector3(GameObject.Find ("Milan").transform.position.x + 17, GameObject.Find ("Milan").transform.position.y, GameObject.Find ("Milan").transform.position.z);
			milanmove = false;
		}

		if (pygogone && !DialogueManager.dialogueActive && DialogueManager.flavortexts.Count == 0) {
			flashback.GetComponent<UIFade> ().Reset ();
			GameObject.FindObjectOfType<Pygo> ().gameObject.SetActive (false);
			pygogone = false;
			player.fisheused = true;
		}

		if (flashbacking1 && DialogueManager.flavortexts.Count == 5) {
			flashback.GetComponent<UIFade> ().FadeOut ();
			flashbacking1 = !flashbacking1;
		}

		if (flashbacking2) {
			if (DialogueManager.flavortexts.Count == 23)
				flashback.GetComponent<UIFade> ().FadeOut ();
			else if (DialogueManager.flavortexts.Count == 20)
				flashback.GetComponent<UIFade> ().FadeIn ();
			else if (DialogueManager.flavortexts.Count == 19)
				flashback.GetComponent<UIFade> ().FadeOut ();
			else if (DialogueManager.flavortexts.Count == 17)
				flashback.GetComponent<UIFade> ().FadeIn ();
			else if (DialogueManager.flavortexts.Count == 15) {
				flashback.GetComponent<UIFade> ().FadeOut ();
				flashbacking2 = !flashbacking2;
			}
		}
		if (flashbacking3) {
			if (DialogueManager.flavortexts.Count == 24)
				flashback.GetComponent<UIFade> ().FadeIn ();
			else if (DialogueManager.flavortexts.Count == 23)
				flashback.GetComponent<UIFade> ().FadeOut ();
			else if (DialogueManager.flavortexts.Count == 13)
				flashback.GetComponent<UIFade> ().FadeIn ();
			else if (DialogueManager.flavortexts.Count == 6) {
				flashback.GetComponent<UIFade> ().FadeOut ();
				flashbacking3 = !flashbacking3;
			}
		}

		if (DialogueManager.dialogueActive) {
			player.talking = true;
		}

		if (player.talking && !DialogueManager.dialogueActive && DialogueManager.flavortexts.Count == 0) {
			player.talking = false;
//			if (flashback.GetComponent<Image> ().enabled == true) {
//				flashback.GetComponent<Image> ().enabled = false;
//			}
		}

		directions = new Queue<bool> (new[] {false, true, true, false, true, false, true});
		directions2 = new Queue<bool> (new[] {true, true, false, true, true, true, true, true, false, false, false, false, true, false, false, true, false, false, true, true, true, true});
		directions3 = new Queue<bool> (new[] {true, false, false, false, true, false, true, false, false, true});
		directions4 = new Queue<bool> (new[] {true, false, true, false, false, false, true, false, false, false});
		directions5 = new Queue<bool> (new[] {true, true, false, true, false, true, true, false, true, true, false, false, true, false, false, false, false, true, false, false, true, false, false, true, true});
		directions6 = new Queue<bool> (new[] {true, false, true, true, false, true, false, false, true, false, true, false, true, true, false, true, false, false, true, false, false, false, false, true, true});
		directions7 = new Queue<bool> (new[] {true, false, false, true, false});
		directions8 = new Queue<bool> (new[] {true, false, false, true});
		directions9 = new Queue<bool> (new[] {true, false, true, false, false, true, false, true, true, false, true, false, false, true});
		directions10 = new Queue<bool> (new[] {true, true, false, false, true});
		directions11 = new Queue<bool> (new[] {true, true, false, true, false, false, true});

	}

	void OnMouseDown()
	{
		Cursor.SetCursor (null, hotSpot, curMode);
		if (!player.talking) {
			if (player.cursor_value == 2 && gameObject.name == "Phone Book") {
				if (!player.check_item ("Phone Book")) {
					playAudio (aTimeStart, aTimeStop);
					player.add_item (phonebookobject.name);
					player.add_sprite_item (phonebookobject.GetComponent<SpriteRenderer> ().sprite);
					GameObject.Find ("Phone Book").SetActive (false);
					DialogueManager.ForceClose ();
					DialogueManager.ShowBox (phonebook, directions, true, false, false, false, "", "");
					Openerused = false;
				}
			}
			if (player.cursor_value == 2 && gameObject.name == "Fish") {
				if (!player.check_item ("Fish")) {
					playAudio (.1f, aTimeStop);
					player.add_item ("Fish");
					player.add_sprite_item (fishy2.GetComponent<SpriteRenderer> ().sprite);
					fishy.GetComponent<SpriteRenderer> ().sprite = fishy.GetComponent<Item> ().newsprite;
					DialogueManager.ForceClose ();
					DialogueManager.ShowBox (fish, true, false, false, false, "", "");
				}
			}

			if (player.cursor_value == 3) {
				if (gameObject.name == "Hotel Room Door" && !player.door1) {
					if (player.check_item ("Keys")) {
						playAudio (aTimeStart, aTimeStop);
						DialogueManager.ForceClose ();
						DialogueManager.ShowBox (keys, true, false, false, false, "", "");
//					ChangeSceneObject.GetComponent<ChangeScene> ().Change (new Vector3(15.5f, -2.3f, 0f), bedroom1);
						player.door1 = true;
					}
				}
				if (gameObject.name == "Hotel Room Door1" && !player.door2) {
					if (player.check_item ("Keys")) {
						playAudio (aTimeStart, aTimeStop);
//					if (player.check_topic("ROOM1502") && player.check_item("Wallet")){
//						cam.gameObject.SetActive (false);
////						ChangeSceneObject.GetComponent<ChangeScene>().Change(new Vector3(-4.28f, 1.26f, 0f), memory);
//					} else{
						DialogueManager.ForceClose ();
						DialogueManager.ShowBox (keys, true, false, false, false, "", "");
						player.door2 = true;
//						ChangeSceneObject.GetComponent<ChangeScene> ().Change (new Vector3(15.5f, -2.3f, 0f), bedroom2);
						//}
					}
				}
				if (gameObject.name == "Hotel Room Door2" && !player.door3) {
					if (player.check_item ("Keys")) {
						playAudio (aTimeStart, aTimeStop);
						DialogueManager.ForceClose ();
						DialogueManager.ShowBox (keys, true, false, false, false, "", "");
						player.door3 = true;
//					ChangeSceneObject.GetComponent<ChangeScene> ().Change (new Vector3(15.5f, -2.3f, 0f), bedroom3);
					}
				}
			}

			if (player.cursor_value == 4 && gameObject.name == "Milan" && player.event4 && player.check_topic ("CANDY")) {
				if (player.check_item ("Candy")) {
					player.delete_item ("Candy");
					player.delete_sprite_item (Gcandy.GetComponent<SpriteRenderer> ().sprite);
					milanmove = true;
					DialogueManager.ForceClose ();
					DialogueManager.ShowBox (candy, directions4, true, false, true, false, "", "Milan");
				}
			}

			if (player.cursor_value == 5 && gameObject.name == "Toilet2") {
				if (!player.check_item ("Wallet")) {
					DialogueManager.ForceClose ();
					DialogueManager.ShowBox (toliet, true, false, false, false, "", "");
					if (!player.check_topic ("NOWATER"))
						player.add_topic ("NOWATER");
					if (GameObject.Find ("Water") != null)
						GameObject.Find ("Water").SetActive (false);
					wallet.SetActive (true);
					gameStateScript.setIsFlooded (false);
				}
			}

			if (player.cursor_value == 6 && gameObject.name == "Pygo") {
				if (player.check_item ("Fish")) {
					player.delete_item ("Fish");
					player.delete_sprite_item (fishy2.GetComponent<SpriteRenderer> ().sprite);
					DialogueManager.ForceClose ();
					DialogueManager.ShowBox (pygo, true, true, false, false, "", "Pygo");
					pygogone = true;
				}
			}

			if (player.cursor_value == 7 && gameObject.name == "Russet") {
				if (player.check_item ("Wallet")) {
					if (GameObject.FindGameObjectWithTag ("Room").name == "Restaurant(Clone)" && player.event4) {
						flashback = GameObject.Find ("Flashback");
						flashback.GetComponent<UIFade> ().FadeIn ();
						flashbacking2 = true;
						DialogueManager.ForceClose ();
						DialogueManager.ShowBox (russet3, directions5, true, false, true, false, "", "Russet");
						if (!player.check_topic ("ROOM1502")) {
							player.add_topic ("ROOM1502");
						}
					} else if (player.check_topic ("WALLET")) {
						flashback = GameObject.Find ("Flashback");
						flashback.GetComponent<UIFade> ().FadeIn ();
						flashbacking1 = true;
						DialogueManager.ForceClose ();
						DialogueManager.ShowBox (russet, directions, false, false, true, false, "", "Russet");
						if (!player.check_topic ("SWIPE"))
							player.add_topic ("SWIPE");
					}
				}
			}
			if (player.cursor_value == 7 && gameObject.name == "Computer") {
				if (player.event8 && player.check_topic("MONEY") && player.check_topic("RUSSETREADY")) {
					DialogueManager.ForceClose ();
					DialogueManager.ShowBox (final, directions11, true, false, true, false, "", "Russet");
					if (!player.check_topic ("NEWGUEST")) {
						player.add_topic ("NEWGUEST");
					}
				}
				if (player.event4 && !player.event8) {
					DialogueManager.ForceClose ();
					DialogueManager.ShowBox (walletcomp, true, false, false, false, "", "");
					if (!player.check_topic ("CHECKCARDS"))
						player.add_topic ("CHECKCARDS");
				} else if (player.check_item ("Wallet") && player.check_topic ("SWIPE") && player.event3) {
					if (gameObject.GetComponent<Computer> ().loggedin) {
						russetgone = true;
						DialogueManager.ForceClose ();
						DialogueManager.ShowBox (russet2, directions2, true, false, true, false, "", "Russet");
						player.event4 = true;
						if (!player.check_topic ("CHECKCARDS"))
							player.add_topic ("CHECKCARDS");
					} else {
						DialogueManager.ForceClose ();
						DialogueManager.ShowBox (gameObject.GetComponent<Computer> ().beforepass, true, false, false, false, "", "");
					}
				}
			}
			if (player.cursor_value == 7 && gameObject.name == "Milan") {
				if (player.event4 && player.check_topic ("CHECKCARDS")) {
					DialogueManager.ForceClose ();
					DialogueManager.ShowBox (milan, directions3, true, false, true, false, "", "Milan");
					if (!player.check_topic ("CANDY")) {
						player.add_topic ("CANDY");
					}
				}
			}

			if (player.cursor_value == 7 && gameObject.name == "Cornelia") {
				if (player.event8 && player.check_topic ("DEBIT")) {
					DialogueManager.ForceClose ();
					DialogueManager.ShowBox (debit, directions10, true, false, true, false, "", "Cornelia");
					if (!player.check_topic ("MONEY")) {
						player.add_topic ("MONEY");
					}
				}
			}


			if (player.cursor_value == 8 && gameObject.name == "Russet") {
				if (player.event5 && player.check_item ("Credit Report")) {
					flashbacking3 = true;
					DialogueManager.ForceClose ();
					DialogueManager.ShowBox (report, directions6, true, false, true, false, "", "Russet");
					player.office = true;
				}
			}

			if (player.cursor_value == 9 && gameObject.name == "Milan") {
				if (player.check_item ("Master Control") && player.check_topic ("TVFIXED")) {
					player.delete_item ("Master Control");
					player.delete_sprite_item (remote.GetComponent<SpriteRenderer> ().sprite);
					DialogueManager.ForceClose ();
					DialogueManager.ShowBox (mastercontrol, directions8, true, false, true, false, "", "Milan");
					if (!player.check_topic ("SHOWS"))
						player.add_topic ("SHOWS");
				}
			}

			if (player.cursor_value == 10 && gameObject.name == "Pygo") {
				if (player.check_item ("Dollar Bill")) {
					player.delete_item ("Dollar Bill");
					player.delete_sprite_item (dolla.GetComponent<SpriteRenderer> ().sprite);
					DialogueManager.ForceClose ();
					DialogueManager.ShowBox (dollar, true, true, false, false, "", "Pygo");
					player.add_item ("TV Switch");
					player.add_sprite_item (switches.GetComponent<SpriteRenderer> ().sprite);
				}
			}

			if (player.cursor_value == 11 && gameObject.name == "Milan") {
				if (player.check_item ("TV Switch")) {
					player.delete_item ("TV Switch");
					player.delete_sprite_item (switches.GetComponent<SpriteRenderer> ().sprite);
					DialogueManager.ForceClose ();
					DialogueManager.ShowBox (tvswitch, directions7, true, false, true, false, "", "Milan");
					if (!player.check_topic ("TVFIXED"))
						player.add_topic ("TVFIXED");
				}
			}

			if (player.cursor_value == 12 && gameObject.name == "Keycard Reader") {
				if (player.check_item ("Key Card")) {
					offdoor.SetActive (false);
					DialogueManager.ForceClose ();
					DialogueManager.ShowBox (gameObject.GetComponent<Item> ().flavortext1, true, false, false, false, "", "");
				}
			}

			if (player.cursor_value == 14 && gameObject.name == "Cornelia") {
				if (player.check_topic ("GIVEVALUABLES")) {
					if (!player.check_topic ("DEBIT")) {
						player.add_topic ("DEBIT");				
					}
					DialogueManager.ForceClose ();
					DialogueManager.ShowBox (valuables, directions9, true, false, true, false, "", "Cornelia");
				}
			}
		}

		player.cursor_value = 0;
	}

	void playAudio (float timeStart, float timeEnd) {
		SoundEffectSource.clip = onClickSound;
		SoundEffectSource.time = timeStart;
		SoundEffectSource.Play ();
	}
}
