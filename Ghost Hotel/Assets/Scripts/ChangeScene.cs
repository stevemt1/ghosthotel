using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

	public DialogueManager DialogueManager;
	[TextArea (1,2)]
	public string[] text;
	public string scene;
	public bool changed = false;
	public GameObject flashback;
	public Vector3 location;
	public Vector3 location2;
	public GameObject locationPrefab;
	public GameObject locationPrefab2;
	public Player player;
	public Camera cam;
	public GameObject butt;

	//Audio
	public MusicController musicScript;
	public GameStateController gameStateScript;

	void Start(){
		butt = GameObject.Find ("Button");
		flashback = GameObject.Find ("Flashback");
		cam = FindObjectOfType<Camera> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();
		player = FindObjectOfType<Player> ();

		//Audio
		GameObject musicGO = GameObject.Find("MusicManager");
		musicScript = musicGO.GetComponent <MusicController>();
		GameObject gameStateGO = GameObject.Find ("GameStateManager");
		gameStateScript = gameStateGO.GetComponent<GameStateController> ();
	}

	public void Change(Vector3 loc, GameObject locPrefab){
		FindObjectOfType<Player> ().transform.position = loc;
		Destroy (GameObject.FindGameObjectWithTag ("Room"));
		GameObject.Instantiate (locPrefab);

	}

	void Update(){
		player = FindObjectOfType<Player> ();
		cam = FindObjectOfType<Camera> ();
	}
		
		
	void OnMouseDown(){
//		if (player.check_topic("JUMP")){
//			SceneManager.LoadScene("test");
//		}

		StartTutorial ();
//
//
//		if (player.check_topic("ROOM1502") && gameObject.name == "Hotel Room Door1"){
//			FindObjectOfType<Player> ().transform.position = location2;
//		}
		if (gameObject.name == "Hotel Room Door" && player.door1 && !player.talking && player.cursor_value == 0){
			flashback.GetComponent<UIFade> ().Reset ();
			DialogueManager.ForceClose ();
			FindObjectOfType<Player> ().transform.position = location;
			musicScript.changeBGM (locationPrefab.name);
			gameStateScript.setCurrentRoom (locationPrefab.name);
			Destroy (GameObject.FindGameObjectWithTag ("Room"));
			GameObject.Instantiate (locationPrefab);
			changed = true;
		}

		if (gameObject.name == "Hotel Room Door2" && player.door3 && !player.talking && player.cursor_value == 0){
			flashback.GetComponent<UIFade> ().Reset ();
			DialogueManager.ForceClose ();
			FindObjectOfType<Player> ().transform.position = location;
			musicScript.changeBGM (locationPrefab.name);
			gameStateScript.setCurrentRoom (locationPrefab.name);
			Destroy (GameObject.FindGameObjectWithTag ("Room"));
			GameObject.Instantiate (locationPrefab);
			changed = true;
		}

		if (gameObject.name == "Hotel Room Door1" && player.door2 && !player.talking) {
			if (player.check_topic ("ROOM1502")) {
				flashback.GetComponent<UIFade> ().Reset ();
				FindObjectOfType<Player> ().transform.position = location2;
				Destroy (GameObject.FindGameObjectWithTag ("Room"));
				GameObject.Instantiate (locationPrefab2);
				changed = true;
			} else {
				flashback.GetComponent<UIFade> ().Reset ();
				DialogueManager.ForceClose ();
				FindObjectOfType<Player> ().transform.position = location;
				musicScript.changeBGM (locationPrefab.name);
				gameStateScript.setCurrentRoom (locationPrefab.name);
				Destroy (GameObject.FindGameObjectWithTag ("Room"));
				GameObject.Instantiate (locationPrefab);
				changed = true;
			}
		}


		if ((GameObject.FindGameObjectWithTag ("Room").name == "Hotel Exterior" || GameObject.FindGameObjectWithTag ("Room").name == "Hotel Exterior(Clone)")&& !player.talking && !DialogueManager.dialogueActive) {
			flashback.GetComponent<UIFade>().Reset();
			if (butt != null) {
				butt.SetActive (false);
			}
			FindObjectOfType<Player> ().transform.position = location;
			musicScript.changeBGM (locationPrefab.name);
			Destroy (GameObject.FindGameObjectWithTag ("Room"));
			GameObject.Instantiate (locationPrefab);
			changed = true;
		}
		if (player.check_topic ("WATER") && !player.talking && !DialogueManager.dialogueActive && !changed) {
			flashback.GetComponent<UIFade>().Reset();
			FindObjectOfType<Player> ().transform.position = location;
			musicScript.changeBGM (locationPrefab.name);
			gameStateScript.setCurrentRoom (locationPrefab.name);
			Destroy (GameObject.FindGameObjectWithTag ("Room"));
			GameObject.Instantiate (locationPrefab);
			changed = true;

//		SceneManager.LoadScene("Title");
//		SceneManager.LoadScene (scene);
		}
		if (player.event1 && !player.check_topic ("WATER")) {
			if (!DialogueManager.dialogueActive)
				DialogueManager.ShowBox (text, true, false, false, false, "", "");
		}


		changed = false;
	}

	void StartTutorial() {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
		if (hit.collider.gameObject.tag == "Tut_button") {
			Destroy (GameObject.FindGameObjectWithTag ("Room"));
			GameObject.Instantiate (locationPrefab);
		}
	}
}
