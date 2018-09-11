using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityChild : MonoBehaviour
{

    Security pScript;

    // Use this for initialization
    void Start()
    {
        pScript = this.gameObject.GetComponentInParent<Security>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            Debug.Log("Trigger Enter at: " + this.transform.position);
            pScript.TriggerEnter(collision);
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Trigger Exit at: " + this.transform.position);
            pScript.TriggerExit(collision);
        }
    }

}
