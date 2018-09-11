using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacter : MonoBehaviour {

	public TopicChoice TopicChoice;
	public Cornelia Cornelia;
	public Manager Manager;
	public Pygo Pygo;
	public Russet Russet;
	public Milan Milan;
	public Computer computer;

	// Use this for initialization
	void Start () {
		TopicChoice = FindObjectOfType<TopicChoice>();
	}

	void Update(){

	}

	public void Search (string name){
		if (name == "Cornelia") {
			Cornelia = FindObjectOfType<Cornelia> ();
			Manager = null;
			Pygo = null;
			Russet = null;
			Milan = null;
			computer = null;
		}
		if (name == "Manager") {
			Manager = FindObjectOfType<Manager> ();
			Cornelia = null;
			Pygo = null;
			Russet = null;
			Milan = null;
			computer = null;
		}
		if (name == "Pygo") {
			Pygo = FindObjectOfType<Pygo> ();
			Cornelia = null;
			Manager = null;
			Russet = null;
			Milan = null;
			computer = null;
		}
		if (name == "Russet") {
			Russet = FindObjectOfType<Russet> ();
			Cornelia = null;
			Manager = null;
			Pygo = null;
			Milan = null;
			computer = null;
		}
		if (name == "Milan") {
			Milan = FindObjectOfType<Milan> ();
			Cornelia = null;
			Manager = null;
			Pygo = null;
			Russet = null;
			computer = null;
		}
		if (name == "Computer") {
			Cornelia = null;
			Manager = null;
			Pygo = null;
			Russet = null;
			Milan = null;
			computer = FindObjectOfType<Computer> ();
		}
	}


	public void returnChoiceOfCornelia(GameObject imageobject){
		if (Cornelia == null) {

		}
		else
			Cornelia.returnChoice (imageobject);
	}
	public void returnChoiceOfManager(GameObject imageobject){
		if (Manager == null) {

		}
		else
			Manager.returnChoice (imageobject);
	}
	public void returnChoiceOfPygo(GameObject imageobject){
		if (Pygo == null) {

		}
		else
			Pygo.returnChoice (imageobject);
	}
	public void returnChoiceOfRusset(GameObject imageobject){
		if (Russet == null) {

		}
		else
			Russet.returnChoice (imageobject);
	}
	public void returnChoiceOfMilan(GameObject imageobject){
		if (Milan == null) {

		}
		else
			Milan.returnChoice (imageobject);
	}
	public void returnChoiceOfComputer(GameObject imageobject){
		if (computer == null) {
			
		} else {
			computer.returnChoice (imageobject);
		}
	}
}
