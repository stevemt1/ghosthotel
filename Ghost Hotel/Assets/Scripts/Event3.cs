using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event3 : MonoBehaviour {

	private Player player;
	public DialogueManager DialogueManager;
	[TextArea(1,10)]
	public string[] dialogue;
	public GameObject russet;
	public GameObject milan;

	//bell Audio
	public GameObject SoundEffectManager;
	public AudioClip ringSound;
	private AudioSource SoundEffectSource;
	public float timeStart = 0.25f;
	public float timeEnd = 0.55f;
	private float ringCount = 0;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();
		SoundEffectManager = GameObject.FindGameObjectWithTag ("soundeffects");
		SoundEffectSource = SoundEffectManager.GetComponent<AudioSource> ();
		if (player.check_topic("SERVICE") && player.event3) {
			russet.SetActive (true);
			milan.SetActive (true);
			ringBell (timeStart, timeEnd);
			DialogueManager.ShowBox (dialogue, true, false, false, false, "", "");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ringBell(float timeStart, float timeEnd){
		SoundEffectSource.clip = ringSound;
		SoundEffectSource.time = timeStart;
		SoundEffectSource.Play ();
		StartCoroutine (delaySoundStop (timeEnd));

	}

	IEnumerator delaySoundStop(float timeEnd){
		while (SoundEffectSource.time < timeEnd) {
			yield return null;
		}
		SoundEffectSource.Stop ();
		ringCount++;
		if (ringCount >= 2) {
			SoundEffectSource.time = timeStart;
			SoundEffectSource.Play ();
		}
		else {
			ringBell (timeStart, timeEnd);
		}
	}
}
