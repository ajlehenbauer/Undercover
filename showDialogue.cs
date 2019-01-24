using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class showDialogue : MonoBehaviour {
    public GameObject canvas;
	// Use this for initialization
	void Start () {
        canvas.SetActive(false);
	}

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            canvas.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {

            canvas.SetActive(false);
        }
    }
}
