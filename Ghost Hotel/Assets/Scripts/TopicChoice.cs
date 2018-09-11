using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopicChoice : MonoBehaviour {

	public Player player;
	public DialogueManager DialogueManager;
	public bool isactive = false;
	public GameObject ExitImage;
	public GameObject image1;
	public GameObject image2;
	public GameObject image3;
	public GameObject image4;
	public GameObject image5;
	public GameObject image6;
	public GameObject image7;
	public GameObject image8;
	public GameObject image9;
	public GameObject image10;
	public GameObject image11;
	public GameObject image12;
	public GameObject image13;
	public GameObject image14;
	public GameObject image15;
	public GameObject image16;
	public Text text1;
	public Text text2;
	public Text text3;
	public Text text4;
	public Text text5;
	public Text text6;
	public Text text7;
	public Text text8;
	public Text text9;
	public Text text10;
	public Text text11;
	public Text text12;
	public Text text13;
	public Text text14;
	public Text text15;
	public Text text16;

	public List<GameObject> images = new List<GameObject>();
	public List<Text> texts = new List<Text>();
	public List<string> topics = new List<string>();

	void Start(){
		DialogueManager = FindObjectOfType<DialogueManager> ();
		images.Add (image1);
		images.Add (image2);
		images.Add (image3);
		images.Add (image4);
		images.Add (image5);
		images.Add (image6);
		images.Add (image7);
		images.Add (image8);
		images.Add (image9);
		images.Add (image10);
		images.Add (image11);
		images.Add (image12);
		images.Add (image13);
		images.Add (image14);
		images.Add (image15);
		images.Add (image16);
		texts.Add (text1);
		texts.Add (text2);
		texts.Add (text3);
		texts.Add (text4);
		texts.Add (text5);
		texts.Add (text6);
		texts.Add (text7);
		texts.Add (text8);
		texts.Add (text9);
		texts.Add (text10);
		texts.Add (text11);
		texts.Add (text12);
		texts.Add (text13);
		texts.Add (text14);
		texts.Add (text15);
		texts.Add (text16);
	}

	public bool IsActive(){
		return isactive;
	}

	public void ShowBoxes(List<string> UsableTopics, string name){
		player = FindObjectOfType<Player> ();
		gameObject.GetComponent<SearchCharacter> ().Search (name);
		topics.Clear ();
		ExitImage.SetActive (true);
		foreach (string item in player.topics_inv) {
			if (UsableTopics.Contains (item)) {
				topics.Add (item);
			}
		}
		for (int i = 0; i < topics.Count; i++) {
			isactive = true;
			images [i].SetActive (true);
			texts [i].text = topics [i];
		}

	}
	public void Close(){
		isactive = false;
		ExitImage.SetActive (false);
		for (int i = 0; i < topics.Count; i++) {
			images [i].SetActive (false);
		}
	}

	public void Exit(){
		Close ();
		DialogueManager.ForceClose ();
		player.talking = false;
	}
}
