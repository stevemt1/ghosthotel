/*Put on every Pickup prefab (ie every object that can be picked up)*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public Player player;
    public bool canClick;
    public bool isHolding;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
	public GameObject initialParent;

    //Make a reference to the player
    //canClick = whether the player can pick up the item or not
    //isHolding = whether the player is currently holding the item or not
    private void Start()
    {
		player = GameObject.Find("Player Platform").GetComponent<Player>();
        canClick = false;
        isHolding = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
		//initialParent.transform.parent = gameObject.transform.parent;
		//initialParent.transform.position = gameObject.transform.position;
    }

    private void Update()
    {
        //checking if the item isn't being carried by the player
        if (gameObject.transform.parent != player.transform)
        {
//            isHolding = false;
//            canClick = true;
			if (player.GetComponent<TestMovement> ().isHolding) {
				isHolding = true;
				canClick = false;
			}

            if (gameObject.GetComponent<Rigidbody2D>() == null)
            { 
                gameObject.AddComponent<Rigidbody2D>();
                rb = gameObject.GetComponent<Rigidbody2D>();
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
            }
        }

		if (Input.GetKeyDown (KeyCode.Space) && isHolding && !player.talking) {
			gameObject.transform.parent = null;
			//gameObject.transform.position = initialParent.transform.position;
			isHolding = false;
			player.GetComponent<TestMovement> ().isHolding = false;
			gameObject.GetComponent<CircleCollider2D> ().enabled = true;
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
		}
    }

    //Using a CircleCollider2D with a radius slightly bigger than the object itself, so the player can only pick it up if they are within the radius
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            canClick = true;
        }
    }
	private void OnTriggerExit2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") {
			canClick = false;
		}

	}

    //What happens when the player clicks on the item
    private void OnMouseDown()
    {
        //code only executes if the player isn't holding anything
        if (canClick)
        {
            //Make the item a child of the player, currently the player is carrying it on their head lol
            //also make it so it doesn't get jostled around when the player is carrying it
            //by freezing the x position
            gameObject.transform.parent = player.transform;
            gameObject.transform.position = player.transform.position;
            transform.localPosition = new Vector3(0, 0.5f, 0);
            Destroy(rb);

            //player can't pick up anymore items because they're holding one
            canClick = false;
            isHolding = true;
			gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			gameObject.GetComponent<BoxCollider2D>().enabled = false;

			player.GetComponent<TestMovement> ().isHolding = true;

        }
    }
		
}
