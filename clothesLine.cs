using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clothesLine : MonoBehaviour {

    //triggers bounce animation
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.GetComponent<Animator>().SetTrigger("bounced");
        }
    }
}