using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour {
	//public bool facing_right = true;
	//private Animator anim;
//	public float speed = 3;
//	public bool grounded = true;
//	public bool facing_right = true;
	Collision2D temp;

	public BoxCollider2D collider1;
	public bool isHolding = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){
//		if (Input.GetKey(KeyCode.))
//		{
//			isHolding = false;
//			transform.DetachChildren();
//		}
	}
//	void Update () {
//		if (Input.GetKey (KeyCode.D)) {
//			 
//		 	//transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//			  
//			 
//			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
//
//			if (!facing_right) {
//				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//				//foreach (Transform T in children)
//					//T.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
//				facing_right = !facing_right;
//			}
//			GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
//			 
//			 
//		}
//		//moves left -> y value in new vector allows players to move while falling from a jump
//		if (Input.GetKey (KeyCode.A)) {
//			 
//			//transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//		
//			 
//			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D> ().velocity.y);
//
//			if (facing_right) {
//				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//				//foreach (Transform T in children)
//					//T.localScale = new Vector3 (-0.5f, 0.5f, 0.5f);
//				facing_right = !facing_right;
//			}
//			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D> ().velocity.y);
//			 
//			 
//		}
//		//if (grounded) {
//			//jumping
//		/*if (Input.GetKey (KeyCode.W) && GetComponent<Rigidbody2D>().velocity.y == 0) {
//				 
//				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, speed * 3);
//
//		}*/
//
//		//if (Input.GetKey (KeyCode.W) && GetComponent<Rigidbody2D>().velocity.y == 0 )
//
//	}	
	 
	void OnCollisionStay2D(Collision2D col) 
	{
		//GetComponent<Collision2D>().collider
//		Collider player_min = GetComponent<Collider>().bounds.min; 

		/*Collider2D collider = col.collider;

		Vector3 contactPoint = col.contacts [0].point;
		Vector3 center = collider.bounds.center;

		bool top = contactPoint.y > center.y;*/

		if (Input.GetKey (KeyCode.S) && col.gameObject.tag == "Dropable") {
			temp = col;
			col.collider.enabled = false;

			StartCoroutine (ReactiveCol ());

			//col.gameObject.GetComponent<EdgeCollider2D> ().enabled = false;
		}

		if(collider1.IsTouching(col.collider))
		{
			//Vector3 temp = col.contacts [0].point.y;
			if (Input.GetKey (KeyCode.W)) {

				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 8);
			}

		}
	}

	IEnumerator ReactiveCol()
	{
		yield return new WaitForSeconds (0.5f);
		temp.collider.enabled = true;
	}
}
