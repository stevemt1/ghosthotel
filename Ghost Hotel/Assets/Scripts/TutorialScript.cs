using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour {

	public Player player;
	public GameObject locationPrefab;
	public GameObject loadText0, loadText1, loadText2, loadText3, loadText4, loadText5, loadText6;
	public Sprite tutorialSprite;

	public CursorMode curMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	private bool temp = true;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		//GetComponent<Inventory> ().enabled = false;
		loadText0 = GameObject.Find ("Text0");
		loadText0.SetActive (true);
		loadText1 = GameObject.Find ("Text (1)");
		loadText1.SetActive (false);
		loadText2 = GameObject.Find ("Text (2)");
		loadText2.SetActive (false);
		loadText3 = GameObject.Find ("Text (3)");
		loadText3.SetActive (false);
		loadText4 = GameObject.Find ("Text (4)");
		loadText4.SetActive (false);
		loadText5 = GameObject.Find ("Text (5)");
		loadText5.SetActive (false);
		loadText6 = GameObject.Find ("Text (6)");
		loadText6.SetActive (false);
	}

	// Update is called once per frame
	void Update () {


		if(loadText0.activeSelf)
		{
			if (Input.GetKey (KeyCode.D)) {
				//GetComponent<Player>().transform.position.x
				GameObject.Find ("Text0").SetActive (false);
				loadText1.SetActive (true);
			}
		}

		if(loadText1.activeSelf) 
		{
			if (Input.GetKey (KeyCode.A)) {
				loadText1.SetActive (false);
				loadText2.SetActive (true);
			}
		}

		if(loadText2.activeSelf)
		{
			if (Input.GetKey (KeyCode.W)) {
				loadText2.SetActive (false);
				loadText3.SetActive (true);
			}
		}

		if (loadText3.activeSelf) {
			//GetComponent<Inventory> ().enabled = true; 
			if (Input.GetMouseButtonDown (0)) {
				CastRay ();

			}

		}

		if (loadText4.activeSelf) {
			StartCoroutine (ReactiveCol ());

		}

		if (loadText5.activeSelf) {
			if (temp) {
				temp = false;
			}

			/*if (Input.GetMouseButtonDown (0) && GameObject.Find("Player Ana").GetComponent<Player>().cursor_value == -1) {

			}*/

//			PlaceItem ();
		}

		if (loadText6.activeSelf) {
			if (Input.GetMouseButtonDown (1)) {
				loadText6.SetActive (false);
				Destroy (GameObject.FindGameObjectWithTag ("Room"));
				GameObject.Instantiate (locationPrefab);
				player.delete_item ("Lampost");
				player.delete_sprite_item (tutorialSprite);
			}
		}
			


	}

	IEnumerator ReactiveCol()
	{
		yield return new WaitForSeconds (5f);
		loadText4.SetActive (false);		loadText5.SetActive (true);
		yield return new WaitForSeconds (5f);
		loadText5.SetActive (false);		loadText6.SetActive (true);
	}

	void CastRay() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
		if (hit.collider.gameObject.name == "Lampost") {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().add_item ("Lampost");
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().add_sprite_item (tutorialSprite);
			loadText3.SetActive (false);
			loadText4.SetActive (true);
		}
	}    

//	void PlaceItem(){
//		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
//		if (hit.collider.gameObject.name == "Slot" && Input.GetMouseButtonDown (0) ) {
//			//Cursor.SetCursor (GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().Lampost_texture, hotSpot, curMode);
//			loadText5.SetActive (false);
//			loadText6.SetActive (true);
//		}
//
//	}

}