using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRushingWater : MonoBehaviour {

	public Player player;
	private AudioSource audioManager;
	public AudioClip rushingWater;
	public float timeStart = 0.5f;
	public float timeEnd = 3.0f;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		audioManager = GetComponent<AudioSource> ();
		audioManager.volume = 0.3f;
		playAudio (timeStart, timeEnd);
	}
	

	void playAudio (float timeStart, float timeEnd) {
		audioManager.clip = rushingWater;
		audioManager.time = timeStart;
		audioManager.Play ();
		StartCoroutine (delaySoundStop (timeEnd));
	}

	IEnumerator delaySoundStop(float timeEnd){
		while (audioManager.time < timeEnd) {
			yield return null;
		}
		audioManager.Stop ();
		playAudio (timeStart, timeEnd);
	}

	void Update(){
		if (player.check_topic("NOWATER")) {
			audioManager.Stop ();
		}
	}
}
