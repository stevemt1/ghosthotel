using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	//Main BGM
	private AudioSource HotelBGMSource;
	private AudioSource RestBGMSource;
	private AudioSource MemoryBGMSource;
	private AudioSource OutsideBGMSource;
	private AudioSource [] audioList;
	public AudioClip Lobby;
	public AudioClip Restaurant;
	public AudioClip Mall;
	public AudioClip Outside;
	private GameObject currentLocation;

	//Ambient Sounds.
	private AudioSource AMSource;
	public AudioClip resNoise1;
	public AudioClip resNoise2;

	void Start () {
		currentLocation = GameObject.FindGameObjectWithTag ("Room");
		audioList = GetComponents<AudioSource> ();
		for (int i = 0; i < audioList.Length; i++) {
			audioList [i].time = 0.01f;
		}
		HotelBGMSource = audioList [0];
		HotelBGMSource.clip = Lobby;
		RestBGMSource = audioList [1];
		RestBGMSource.clip = Restaurant;
		MemoryBGMSource = audioList [2];
		MemoryBGMSource.clip = Mall;
		OutsideBGMSource = audioList [3];
		OutsideBGMSource.clip = Outside;
		AMSource = audioList [4];
		changeBGM (currentLocation.name);
		
	}

	public void pauseAllBGM(){
	//pauses playback of all audio sources
		for (int i = 0; i < audioList.Length; i++) {
			audioList [i].Pause ();
		}
	}

	public void changeBGM(string locName){
	//when called from ChangeScene.cs
		pauseAllBGM();
		if (locName == "Restaurant" || locName == "Restaurant(Clone)") {
			RestBGMSource.Play ();
		} else if (locName == "Memory" || locName == "Memory(Clone)") {
			MemoryBGMSource.Play ();
		} else if (locName == "Hotel Exterior" || locName == "Hotel Exterior(Clone)") {
			OutsideBGMSource.Play ();
		} else if (locName == "Lobby" || locName == "Lobby(Clone)"){
			HotelBGMSource.Play ();
		}
		else {
			HotelBGMSource.Play ();

		}
	}
}
