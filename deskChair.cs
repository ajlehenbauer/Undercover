using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deskChair : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        //gameObject.GetComponent<Animator>().SetBool("turnLeft", true);
    }
	
	//triggers chair spin animation
    private void OnTriggerExit2D(Collider2D collision)
    {
        
            if (player.GetComponent<SpriteRenderer>().flipX)
            {
                gameObject.GetComponent<Animator>().SetBool("turnLeft", true);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("turnLeft", false);
            }

        }
    
}
