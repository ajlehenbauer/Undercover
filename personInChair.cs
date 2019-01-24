using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personInChair : MonoBehaviour {
    public bool isListening;
    GameObject player;
    private AudioSource audioSource;
    Animator this_animator;
    Animation switch_anim;
    // Use this for initialization
    void Start () {
        this_animator = GetComponent<Animator>();
        
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        
        audioSource.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioSource.volume = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioSource.volume = 0;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
