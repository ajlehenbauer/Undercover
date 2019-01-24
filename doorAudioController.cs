using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAudioController : MonoBehaviour {
    private AudioSource audioSource;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public AudioClip doorLocked;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    public void playOpen()
    {
        audioSource.clip = doorOpen;
        audioSource.Play();
    }
    public void playLocked()
    {
        audioSource.clip = doorLocked;
        audioSource.Play();
    }
    public void playClose()
    {
        audioSource.clip = doorClose;
        audioSource.Play();
    }




}
