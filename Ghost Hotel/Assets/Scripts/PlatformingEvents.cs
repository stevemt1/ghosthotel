using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformingEvents : MonoBehaviour {

	public DialogueManager DialogueManager;
	public Player player;

	public GameObject gunrusset;
	public GameObject deadrusset;


	[TextArea (1,20)]
	public string[] mall;
	[TextArea (1,20)]
	public string[] mall1;
	[TextArea (1,20)]
	public string[] mall2;
	[TextArea (1,20)]
	public string[] mall2b;
	[TextArea (1,20)]
	public string[] mall2c;
	[TextArea (1,20)]
	public string[] mall2d;
	[TextArea (1,20)]
	public string[] office1;
	[TextArea (1,20)]
	public string[] office2;
	[TextArea (1,20)]
	public string[] office3;
	[TextArea (1,20)]
	public string[] office4;
	[TextArea (1,20)]
	public string[] office5;
	[TextArea (1,30)]
	public string[] office6;
	[TextArea (1,20)]
	public string[] home1;
	[TextArea (1,20)]
	public string[] home2;
	[TextArea (1,20)]
	public string[] home3;
	[TextArea (1,20)]
	public string[] home4;
	[TextArea (1,20)]
	public string[] officeFinal;

	public bool entering;
	public bool mallevent1;
	public bool mallevent2;
	public bool mallevent2b;
	public bool mallevent2c;
	public bool mallevent2d;
	public bool officeevent1;
	public bool officeevent2;
	public bool officeevent3;
	public bool officeevent4;
	public bool officeevent5;
	public bool officeevent6;
	public bool homeevent1;
	public bool homeevent2;
	public bool homeevent3;
	public bool homeevent4;
	public bool officeEventFinal;

	public Queue<bool> malldirections1 = new Queue<bool> (new[] {true, false, false, true, false, false, false, false, true, true, false, false, true});
	public Queue<bool> malldirections2 = new Queue<bool> (new[] {true, true, false, false, true, true, true, false, false});
	public Queue<bool> malldirections2c = new Queue<bool> (new[] {false, true});
	public Queue<bool> officedirections1 = new Queue<bool> (new[] {false, false, true, true});
	public Queue<bool> officedirections2 = new Queue<bool> (new[] {false, false, false, false, true, true, true, false});
	public Queue<bool> officedirections5 = new Queue<bool> (new[] {true, false, false, false, false, true, false});
	public Queue<bool> officedirections6 = new Queue<bool> (new[] {false, false, false, false, true, false, false, false, false, true, true, true, false, false, false, false, false, false, false, false, true, true, true, true});
	public Queue<bool> homedirections1 = new Queue<bool> (new[] {false, false, false, true, false, false, false});
	public Queue<bool> homedirections4 = new Queue<bool> (new[] {false, false, true, true, true});
	public Queue<bool> finaldirections = new Queue<bool> (new[] {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false});


	void Start () {
		player = FindObjectOfType<Player> ();
		DialogueManager = FindObjectOfType<DialogueManager> ();
	}

	void Update(){
		if (player.talking && !DialogueManager.dialogueActive) {
			player.talking = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col) 
	{
		if (col.transform.tag == "Player") {
			gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
			player.talking = true;
			if (entering) {
				DialogueManager.ShowBox (mall,  true, false, false, false, "", "");
			}
			if (mallevent1) {
				DialogueManager.ShowBox (mall1, malldirections1, true, false, true, true, "Dore", "Russet");
			}
			if (mallevent2) {
				DialogueManager.ShowBox (mall2, malldirections2, true, false, true, true, "Dore", "Person");
			}
			if (mallevent2b) {
				DialogueManager.ShowBox (mall2b, true, false, false, false, "", "");
			}
			if (mallevent2c) {
				DialogueManager.ShowBox (mall2c, malldirections2c, true, false, true, true, "Dore", "Person");
			}
			if (mallevent2d) {
				player.add_topic ("PASSWORDS");
				player.event5 = true;
				DialogueManager.ShowBox (mall2d, true, false, false, false, "", "");
			}
			if (officeevent1 && !player.home) {
				DialogueManager.ShowBox (office1, officedirections1, true, false, true, false, "", "Russet");
			}
			if (officeevent2 && !player.home) {
				DialogueManager.ShowBox (office2, officedirections2, true, false, true, true, "Person", "Person");
			}
			if (officeevent3 && !player.home) {
				DialogueManager.ShowBox (office3, true, false, false, false, "", "");
			}
			if (officeevent4 && !player.home) {
				DialogueManager.ShowBox (office4, true, false, false, false, "", "");
			}
			if (officeevent5 && !player.home) {
				DialogueManager.ShowBox (office5, officedirections5, false, false, true, true, "Person", "Russet");
			}
			if (officeevent6 && !player.home) {
				DialogueManager.ShowBox (office6, officedirections6, true, false, true, false, "", "Russet");
			}
			if (homeevent1) {
				DialogueManager.ShowBox (home1, homedirections1, true, false, true, true, "Person", "Russet");
			}
			if (homeevent2) {
				DialogueManager.ShowBox (home2, true, false, false, false, "", "");
			}
			if (homeevent3) {
				gunrusset.SetActive (false);
				deadrusset.SetActive (true);
				DialogueManager.ShowBox (home3, true, false, false, false, "", "");
			}
			if (homeevent4) {
				DialogueManager.ShowBox (home4, homedirections4, true, false, true, false, "", "Person");
			}
			if (officeEventFinal) {
				DialogueManager.ShowBox (officeFinal, finaldirections, true, false, true, false, "", "Dore");
			}
		}
	}


}
