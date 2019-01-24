using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.parent.GetComponent<Animator>().GetBool("openDoor")|| gameObject.transform.parent.GetComponent<Animator>().GetBool("openDoorReverse"))
        {
            GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            GetComponent<Collider2D>().enabled = true;
        }
    
    }
}
