using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityButton : MonoBehaviour {

	public GameObject[] gates;

	public GameObject player;
	public Rigidbody2D rb;
	public BoxCollider2D bc;
	public bool canClick;


	// Use this for initialization
	private void Start(){
		player = GameObject.Find("Player Platform");
		canClick = false;
		rb = gameObject.GetComponent<Rigidbody2D>();
	}


	private void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player")
		{
			canClick = true;
		}
	}


	private void OnMouseDown()
	{
		//code only executes if the player isn't holding anything
		if (canClick)
		{
			foreach (GameObject gate in gates) {
				if (gate.activeSelf) {
					gate.SetActive (false);
				} else {
					gate.SetActive (true);
				}
			}

			Debug.Log ("I CLICKIED");

		}
	}


}
