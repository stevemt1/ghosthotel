using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

//	private static Player Instance = null;
	private Transform[] children = null;
	public int cursor_value = 0;
	public float speed;
	public bool cutscene = true;
	public bool grounded = true;
	public bool facing_right = true;
	public bool item_open = false;
	public bool topics_open = false;
	public bool talking = false;
	public bool event0 = false;
	public bool event1 = false;
	public bool event2 = false;
	public bool event3 = false;
	public bool event4 = false;
	public bool event5 = false;
	public bool event6 = false;
	public bool event7 = false;
	public bool office = false;
	public bool event8 = false;
	public bool home = false;
	public bool candy = false;
	public bool pygogone = false;
	public bool russetgone = false;
	public bool fisheused = false;
	public bool telephonebooth = false;
	public bool door1 = false;
	public bool door2 = false;
	public bool door3 = false;
	public List<string> item_inv = new List<string>();
	public List<Sprite> sprite_item_inv = new List<Sprite> ();
	public List<string> topics_inv = new List<string>();
	public string topicS;
	public AcquiredBox box;
	//public Sprite[] item_inventory;
//	public string[] itemrec;
	public Image inventory;
	public GameObject inv;
	public Sprite notthinking;
	public Sprite thinking;

	public Texture2D Broch_texture;
	public Texture2D Letter_texture;
	public Texture2D Keychain_texture;
	public Texture2D Candy_texture;
	public Texture2D Plunger_texture;
	public Texture2D Fish_texture;
	public Texture2D Wallet_texture;
	public Texture2D Lampost_texture;
	public Texture2D Report_texture;
	public Texture2D Control_texture;
	public Texture2D Dollar_texture;
	public Texture2D Switch_texture;
	public Texture2D Card_texture;
	public Texture2D Necklace_texture;
	public Texture2D Valuables_texture;


	public CursorMode curMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	//public Text topicString;
//	private DialogueManager DialogueManager;

	public GameStateController gameStateScript;

	//Audio
	private AudioSource audioWalkManager;
	private AudioSource audioVoiceManager;
	private Animator anim;
	public AudioClip step;
	public AudioClip moistStep;
	public AudioClip pickUp;
	public AudioClip jGrunt1;
	public AudioClip jGrunt2;
	public AudioClip jGrunt3;
	public bool not_walking = true;
	public float stepBuffer = 0.25f;
	public bool wetHallway = false;

	void Awake (){
//		DontDestroyOnLoad(this.gameObject);
//		if(Instance == null)
//		{
//			Instance = this;
//		} else if(Instance != this)
//		{
//			Destroy(this.gameObject);
//		}
	}


	// Use this for initialization
	void Start () {
		inventory = GameObject.Find ("Inventory Background").GetComponent<Image> ();
		inv = GameObject.Find ("Inventory Background");
		children = new Transform[transform.childCount];
		int i = 0;
		foreach (Transform T in transform)
			children [i++] = T;
//		DialogueManager = FindObjectOfType<DialogueManager> ();
		AudioSource[] audioList = GetComponents<AudioSource> ();
		audioWalkManager = audioList [0];
		audioVoiceManager = audioList [1];
		audioWalkManager.clip = step;
		GameObject gameStateGO = GameObject.Find ("GameStateManager");
		gameStateScript = gameStateGO.GetComponent<GameStateController> ();
//		wetHallway = GameObject.Find ("_Hotel Hallway (Water)");
//		wetRoom = GameObject.Find ("Water");

		foreach (GameObject slot in inv.GetComponent<Inventory>().allSlots)
			GameObject.Destroy (slot);
		inv.GetComponent<Inventory> ().create ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update(){
		if (Input.GetMouseButtonDown (1)) {
			Cursor.SetCursor (null, hotSpot, curMode);
			cursor_value = 0;
		}

		/*if (cursor_value != 0 && Input.GetMouseButtonDown (0)) {
			Cursor.SetCursor (null, hotSpot, curMode);
			cursor_value = 0;
		} */			
		/*change scene faster test
//		if (Input.GetKeyDown (KeyCode.Space)) {
//			SceneManager.LoadScene ("Lobby");	
//		}

		if (Input.GetKeyDown (KeyCode.I))
		{

			if (talking == false && !item_open)
			{
				//placeholder audio
				audioWalkManager.clip = pickUp;
				audioWalkManager.Play ();

				//open item inventory
				item_open = true;
				inventory.gameObject.SetActive (true); 
				inv.GetComponent<Inventory> ().create ();
				//inv.GetComponentInParent<Canvas>().enabled = true;
			}
			else
			{
				//close item inventory
				//inv.GetComponentInParent<Canvas>().enabled = false;
				foreach (GameObject slot in inv.GetComponent<Inventory>().allSlots)
					GameObject.Destroy (slot);
				inventory.gameObject.SetActive(false);
				item_open = false;
			}
		}*/
//		if (Input.GetKeyDown (KeyCode.T))
//		{
//			//placeholder audio
//			audioManager.clip = pickUp;
//			audioManager.Play ();
//			if(topics_open)
//			{
//				//close topics inventory
//				foreach (GameObject slot in inv.GetComponent<Inventory>().TopicSlots)
//					GameObject.Destroy (slot);
//				foreach (GameObject slot in inv.GetComponent<Inventory>().TopicTextList)
//					GameObject.Destroy (slot);
//				
//				topics_open = false;
//			}
//			else
//			{
//				//open topics inventory
//				topics_open = true;
//				inv.GetComponent<Inventory> ().createTopic ();
//
//
//
//			}
//		}

		if (!talking) {
			GetComponent<Animator> ().enabled = true;
			GetComponent<SpriteRenderer> ().sprite = notthinking;
//			wetHallway = GameObject.Find ("_Hotel Hallway (Water)");
//			wetRoom = GameObject.Find ("Water");

			//moves right -> y value in new vector allows players to move while falling from a jump
			if (Input.GetKey (KeyCode.D)) {
				if (!facing_right) {
					transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					foreach (Transform T in children)
						T.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
					facing_right = !facing_right;
				}
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
				anim.SetTrigger ("Walking");
				if (gameStateScript.checkIsFlooded ()) {
					walkInWater ();
				} else {
					WalkOnGround ();
				}
			}
			//moves left -> y value in new vector allows players to move while falling from a jump
			if (Input.GetKey (KeyCode.A)) {
				if (facing_right) {
					transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					foreach (Transform T in children)
						T.localScale = new Vector3 (-0.5f, 0.5f, 0.5f);
					facing_right = !facing_right;
				}
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D> ().velocity.y);
				anim.SetTrigger ("Walking");
				if (gameStateScript.checkIsFlooded ()) {
					walkInWater ();
				} else {
					WalkOnGround ();
				}
			}
			if (grounded) {
				//jumping
				if (Input.GetKey (KeyCode.W)) {
					playJumpGrunt ();
					anim.Play ("tr_ana_jumping");
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, speed * 2);
					grounded = false;
				} 
			}
		} else {
			GetComponent<Animator> ().enabled = false;
			GetComponent<SpriteRenderer> ().sprite = thinking;
		}
	}
	
	void OnCollisionEnter2D(Collision2D col) 
	{
		//jump check
		if (col.transform.tag == "floor")
			grounded = true;
	}
		
	public void add_item(string item)
	{
		if (item == "Candy") {
			candy = true;
		}
		//audio can be replaced later
		audioWalkManager.clip = pickUp;
		audioWalkManager.Play ();
//		box.acquired = item;
		item_inv.Add(item);

	}

	public void delete_item(string item){
		item_inv.Remove (item);
	}

	public void delete_sprite_item(Sprite item_image){
		sprite_item_inv.Remove (item_image);
		foreach (GameObject slot in inv.GetComponent<Inventory>().allSlots)
			GameObject.Destroy (slot);
		inv.GetComponent<Inventory> ().create ();
	}

	public void add_sprite_item(Sprite item_image)
	{
		sprite_item_inv.Add (item_image);
		foreach (GameObject slot in inv.GetComponent<Inventory>().allSlots)
			GameObject.Destroy (slot);
		inv.GetComponent<Inventory> ().create ();
	}

	public void remake_inv(Player other){
		foreach (string item in other.item_inv) {
			if (!item_inv.Contains(item))
				item_inv.Add (item);
		}
		foreach (Sprite sprite in other.sprite_item_inv){
			if (!sprite_item_inv.Contains(sprite))
				add_sprite_item (sprite);
		}
		foreach (string topic in other.topics_inv) {
			if (!topics_inv.Contains(topic))
				topics_inv.Add (topic);
		}

		foreach (GameObject slot in inv.GetComponent<Inventory>().allSlots)
			GameObject.Destroy (slot);
		inv.GetComponent<Inventory> ().create ();

		if (other.office)
			office = true;
		if (other.home)
			home = true;
	}

	public Sprite return_sprite_item(int num)
	{
		return sprite_item_inv [num];
	}

	public void add_topic(string topic)
	{
		//audio can be replaced later
//		audioWalkManager.clip = pickUp;
//		audioWalkManager.Play ();
//		box.acquired = topic;
		topics_inv.Add (topic);
		topicS += topic + "\n";
		//topicString.text = topicS;
//		itemrec [0] = "New Topic: " + topic;
//		DialogueManager.ShowBox (itemrec, talking, "System", "System");
	}

	public bool check_item(string item){
		return item_inv.Contains (item);
	}
	public bool check_topic(string topic){
		return topics_inv.Contains (topic);
	}

	public void WalkOnGround(){
		audioWalkManager.clip = step;
		audioWalkManager.volume = .75f;
		if (not_walking && grounded) {
			audioWalkManager.time = 0.01f;
			audioWalkManager.Play ();
			StartCoroutine (Stepping (stepBuffer));
		}
	}
		
	public void walkInWater(){
		audioWalkManager.clip = moistStep;
		audioWalkManager.volume = 0.5f;
		if (not_walking && grounded) {
			audioWalkManager.time = 0.2f;
			audioWalkManager.Play ();
			StartCoroutine (Stepping (stepBuffer));
		}
	}

	IEnumerator Stepping (float stepTime){
		not_walking = false;
		yield return new WaitForSeconds (stepTime);
		not_walking = true;
	}

	void playJumpGrunt(){
		int grunt = Random.Range (1,4);
		switch (grunt) {
		case 3:
			audioVoiceManager.clip = jGrunt3;
			break;
		case 2:
			audioVoiceManager.clip = jGrunt2;
			break;
		default:
			audioVoiceManager.clip = jGrunt1;
			break;
		}
		audioVoiceManager.Play ();
	}


	public void UseItem(string itemname){
		if (itemname == "Letter Opener") {
			Cursor.SetCursor (Letter_texture, hotSpot, curMode);
			cursor_value = 2;
//			if (Vector2.Distance (gameObject.transform.position, GameObject.Find("Telephone Booth").transform.position) <= 5 && !telephonebooth){
//				GameObject.Find ("Telephone Booth").GetComponent<ItemUsed> ().Openerused = true;
//				telephonebooth = true;
//			}
		}
		if (itemname == "Brochure") {
			cursor_value = 1;
			Cursor.SetCursor (Broch_texture, hotSpot, curMode);
		}

		if (itemname == "Keys") {
			Cursor.SetCursor (Keychain_texture, hotSpot, curMode);
			cursor_value = 3;
		}

		if (itemname == "Candy") {
			Cursor.SetCursor (Candy_texture, hotSpot, curMode);
			cursor_value = 4;
		}

		if (itemname == "Toilet Plunger") {
			Cursor.SetCursor (Plunger_texture, hotSpot, curMode);
			cursor_value = 5;
		}

		if (itemname == "Fish (torn)") {
			Cursor.SetCursor (Fish_texture, hotSpot, curMode);
			cursor_value = 6;
		}

		if (itemname == "Wallet") {
			Cursor.SetCursor (Wallet_texture, hotSpot, curMode);
			cursor_value = 7;
		}
		if (itemname == "Lampost") {
			Cursor.SetCursor (Lampost_texture, hotSpot, curMode);
			cursor_value = -1;
		}
		if (itemname == "Credit Report") {
			Cursor.SetCursor (Report_texture, hotSpot, curMode);
			cursor_value = 8;
		}
		if (itemname == "Master Control") {
			Cursor.SetCursor (Control_texture, hotSpot, curMode);
			cursor_value = 9;
		}
		if (itemname == "Dollar Bill") {
			Cursor.SetCursor (Dollar_texture, hotSpot, curMode);
			cursor_value = 10;
		}
		if (itemname == "TV Switch") {
			Cursor.SetCursor (Switch_texture, hotSpot, curMode);
			cursor_value = 11;
		}
		if (itemname == "Key Card") {
			Cursor.SetCursor (Card_texture, hotSpot, curMode);
			cursor_value = 12;
		}
		if (itemname == "Necklace") {
			Cursor.SetCursor (Necklace_texture, hotSpot, curMode);
			cursor_value = 13;
		}
		if (itemname == "Valuables") {
			Cursor.SetCursor (Valuables_texture, hotSpot, curMode);
			cursor_value = 14;
		}
	}

}
