using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class television : MonoBehaviour {

    public bool isListening;
    GameObject player;
    Animator p_animator;
    private AudioSource audioSource;
    public AudioClip tv;
    public AudioClip channelSwitch;
    public float switchTime;
    public bool isListeningOutside;
    float channelSwitchLength;
    public float delayTime;

	// Use this for initialization
	void Start () {

        StartCoroutine(switchAudio());
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = 0;
        audioSource.clip = tv;
        isListening = false;
        isListeningOutside = false;
        player = GameObject.FindGameObjectWithTag("Player");
        p_animator = player.GetComponent<Animator>();
        channelSwitchLength = channelSwitch.length;
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {

        
        
        if (isListening)
        {
            audioSource.volume = 1;
        }
        else
        {
            audioSource.volume = 0;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            isListening = true;

        }

       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isListening = false;

        }
    }
    IEnumerator switchAudio()
    {

        
        float temp = delayTime;
        
        while( true )
        {
                if (temp != delayTime)
                {
                    yield return new WaitForSeconds(delayTime);
                }



            yield return new WaitForSeconds(switchTime);
            audioSource.clip = channelSwitch;
            audioSource.Play();
            yield return new WaitForSeconds(channelSwitchLength);
            audioSource.clip = tv;
            audioSource.Play();
            temp = delayTime;
            }



    }
}
