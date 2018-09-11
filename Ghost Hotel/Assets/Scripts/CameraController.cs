using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Player player;
	public bool explore;
	public Vector3 offset;
	private Animator anim;
	public bool anim1 = false;
	public GameObject Room;
	public int minPosition; // left border
	public int maxPosition; //  right border

	void Start(){
		explore = true;
	}

	// Use this for initialization
	void StartExplore() {
		anim = GetComponent<Animator> ();
		player = FindObjectOfType<Player> ();
		transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

		offset = transform.position - player.transform.position;

	}

	void Update() {

		Room = GameObject.FindGameObjectWithTag ("Room");
		if (!anim1 && Room.name == "Lobby(Clone)") {
//			anim.SetTrigger ("Lobby");
			anim1 = true;
		}
		if (Room.name == "Hotel Exterior" || Room.name == "Hotel Exterior(Clone)") {
			minPosition = -1;
			maxPosition = 12;
		}
		if (Room.name == "Lobby(Clone)") {
			minPosition = 12;
			maxPosition = 73;
		}
		if (Room.name == "Restaurant(Clone)") {
			minPosition = 12;
			maxPosition = 59;
		}
		if (Room.name == "Hallway(Clone)") {
			minPosition = 13;
			maxPosition = 40;
		}
		if (Room.name == "Bedroom1(Clone)" || Room.name == "Bedroom2(Clone)" || Room.name == "Bedroom3(Clone)") {
			minPosition = 22;
			maxPosition = 31;
		}
		if (Room.name == "Memory(Clone)") {

		}
	}


	
	void LateUpdate () {
		player = FindObjectOfType<Player>();
		if (explore) {
			Vector3 temp = transform.position;
			StartExplore ();
			transform.position = player.transform.position + offset;


			if (player.transform.position.x > maxPosition || player.transform.position.x < minPosition) {
				temp.x = Mathf.Clamp (transform.position.x, minPosition, maxPosition);
				transform.position = temp;
			}
		}
	}
}
