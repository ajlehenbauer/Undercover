using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha0 : MonoBehaviour {

    //used to set object to transparent upon enter and to original upon exit
    Color temp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            temp = gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().color = temp;
        }
    }
}
