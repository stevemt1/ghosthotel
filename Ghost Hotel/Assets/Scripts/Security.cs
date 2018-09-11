/* IMPORTANT!!!! Attach this script to an EMPTY gameobject and make it the PARENT
 * of all security trigger objects!!!!!*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security : MonoBehaviour {

    //need to check if the player is holding an item to determine whether the trigger goes off
    public bool isHold;
    //public Pickup pscript;

    public GameObject doors;

	//Audio
	public GameObject SoundEffectManager;
	public AudioClip doorSound;
	private AudioSource SoundEffectSource;

    // Use this for initialization
    void Start () {
        isHold = false;

        //the doors are also all children of an empty gameobject
        //because I can just loop through the children and close/open each door 
        doors = GameObject.FindGameObjectWithTag("Door");

		//Audio
		SoundEffectManager = GameObject.FindGameObjectWithTag ("soundeffects");
		SoundEffectSource = SoundEffectManager.GetComponent<AudioSource> ();
	}

    //NOT using OnTriggerEnter2D because it can't even get called here
    //because it is an empty game object only serving as a parent 
    //the player can't collide with am empty gameobject!
    public void TriggerEnter(Collider2D c)
    {
        //checks whether the player is holding an item upon entering the security trigger
        if (c.gameObject.tag == "Player" && c.gameObject.transform.childCount > 0)
        {
            //pscript = c.gameObject.GetComponentInChildren<Pickup>();
            isHold = true;
        }
        else
        {
            isHold = false;
        }
    }

    //NOT using OnTriggerExit2D because it can't even get called here
    public void TriggerExit(Collider2D c)
    {
		if (isHold)
        {
			isHold = false;
			//plays one door open/close sound
			SoundEffectSource.clip = doorSound;
			SoundEffectSource.time = 0.01f;
			SoundEffectSource.Play ();
			
            //loops through every door and opens/closes them
            foreach (Transform door in doors.transform)
            {
                //checking to see if the door is "closed"
                //by seeing if it is inactive
                if (door.gameObject.activeInHierarchy)
                {
                    door.gameObject.SetActive(false);
                }
                //checking to see if the door is "open"
                //by seeing if it is active
                else
                {
                    door.gameObject.SetActive(true);
                }
            }
        }
    }
}
