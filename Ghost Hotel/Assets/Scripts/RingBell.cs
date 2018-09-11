using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBell : MonoBehaviour {

	public Player player;
	public GameObject phone;
	public Sprite necessarysprite;
	public GameObject Manager;
	public DialogueManager DialogueManager;
	[TextArea (1,2)]
	public string[] managerintro;

	//Audio
/*	private AudioSource audioManager;
	public AudioClip bellChime;
	public float timeStart = 0.25f;
	public float timeEnd = 0.55f;
	private float ringCount = 0;
*/

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
//		audioManager = GetComponent<AudioSource> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if (player.event3 || player.event4 || player.event5) {
			DialogueManager.ShowBox (gameObject.GetComponent<Item>().flavortext, true, false, false, false, "", "");
		}

//		ringCount = 0;
//		playAudio(timeStart, timeEnd);		//can change it to ring once
		else if (phone.GetComponent<SpriteRenderer> ().sprite == necessarysprite && player.check_item ("Phone Book") && player.check_topic("NOISE") && !player.check_topic("WATER") && !player.talking) {
			DialogueManager.ShowBox (managerintro, false, false, false, false, "", "Manager");
			Manager.SetActive (true);
		}
	}
/*	void playAudio (float timeStart, float timeEnd) {
		audioManager.clip = bellChime;
		audioManager.time = timeStart;
		audioManager.Play ();
//		StartCoroutine (delaySoundStop (timeEnd));
	}

	IEnumerator delaySoundStop(float timeEnd){
		while (audioManager.time < timeEnd) {
			yield return null;
		}
		audioManager.Stop ();
		ringCount++;
		if (ringCount >= 2) {
			audioManager.time = timeStart;
			audioManager.Play ();
		}
		else {
			playAudio (timeStart, timeEnd);
	}
	}
*/
}
