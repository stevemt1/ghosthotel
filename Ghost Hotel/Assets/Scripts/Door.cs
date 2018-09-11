/* Attach to every Door prefab that starts the scene in an "open" state.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    //closes the door when the scene starts
    void Start()
    {
        gameObject.SetActive(false);
    }
}
