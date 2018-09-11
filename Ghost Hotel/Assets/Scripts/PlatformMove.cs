using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {

	public float rightTopBound;
	public float leftBottomBound;
	public bool LrOrUd; //True means Left/Right, False means Up/Down	
	float speed;


	// Use this for initialization
	void Start () {
		speed = 2;
	}

	// Update is called once per frame
	void Update () {
		if (LrOrUd) { //Going Left/Right

			transform.Translate (speed * Time.deltaTime, 0, 0);

		} else { // Going Up/Down
			
				
			transform.Translate (0, speed * Time.deltaTime, 0);

		}


		if (LrOrUd) {

			if (transform.position.x > rightTopBound || transform.position.x < leftBottomBound) {
				speed = -speed;
			}

		} else {
			
			if (transform.position.y > rightTopBound || transform.position.y < leftBottomBound) {
				speed = -speed;
			}

		}



	}

	/*void OnCollisionEnter2D (Collision2D other){// This doesn't seem to work

		//if (other.transform.tag == "Player") {
		//	other.transform.SetParent(transform,false);
		//}


	}*/

	void OnCollisionEnter2D(Collision2D other) {
		if (other.transform.tag == "Player") {
			other.transform.parent = transform;



			//if (Input.GetKeyDown)
			//	GetComponent<Collider2D>.enabled = false;
		}

	}

	void OnCollisionExit2D(Collision2D other) {
		if (other.transform.tag == "Player") {
			other.transform.parent = null;
		}
	}

}

