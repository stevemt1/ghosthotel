using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour {

	public bool isFlooded = true;
	public string currentRoom = "";

	public void setCurrentRoom(string room){
		currentRoom = room;
	}

	public void setIsFlooded(bool state){
		//assume only the hallway and second bedroom get flooded
		isFlooded =  state;

	}
	public bool checkIsFlooded(){
		return isFlooded && (currentRoom == "Hallway" || currentRoom == "Bedroom2");
	}
}
