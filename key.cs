using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<PlayerInventory>().getKey();
        Destroy(gameObject);
    }
}
