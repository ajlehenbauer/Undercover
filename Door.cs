using System.Diagnostics;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Door : MonoBehaviour {
    public bool contact;
    public KeyCode interact = KeyCode.E;
    Animator m_Animator;
    GameObject player;
    Animator p_animator;
    public float secondsToWait;
    public bool needsToListen;
    public KeyCode listen = KeyCode.Q;
    public bool needsKey;
    public bool alwaysLocked;
    public Text playerText;
    public bool canListen;
    private AudioSource audioSource;
    
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
        audioSource.Play();
        secondsToWait = .3f;
        player = GameObject.FindGameObjectWithTag("Player");
        p_animator = player.GetComponent<Animator>();
        contact = false;
        m_Animator = GetComponent<Animator>();
        playerText = GameObject.FindGameObjectWithTag("playerText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
       
        if ((contact && Input.GetKeyDown(interact)&&!needsKey)|| (contact && Input.GetKeyDown(interact) && needsKey && player.GetComponent<PlayerInventory>().hasKey()))
        {
            
           
                StartCoroutine(open());

                if (!m_Animator.GetBool("openDoor") && !m_Animator.GetBool("openDoorReverse"))
                {
                    p_animator.SetBool("kick", true);

                }
            
        }
        else if (contact && Input.GetKeyDown(listen))
        {
            StartCoroutine(doorListen());

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {

            contact = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            contact = false;
            playerText.text = "";
        }
    }

    //
    public void openDoor()
    {
        if (alwaysLocked)
        {
            if (player.GetComponent<PlayerInventory>().hasKey())
            {
                playerText.text = "The key didn't work...";
                player.GetComponent<doorAudioController>().playLocked();

            }
            else
            {
                playerText.text = "It's locked!";
                player.GetComponent<doorAudioController>().playLocked();
            }
        }
        else if (!needsKey||(needsKey&&player.GetComponent<PlayerInventory>().hasKey()))
        {
            StartCoroutine(open());
            if (!m_Animator.GetBool("openDoor") && !m_Animator.GetBool("openDoorReverse"))
            {
                p_animator.SetBool("kick", true);
                player.GetComponent<doorAudioController>().playOpen();
            }
        }
        else
        {
            playerText.text = "It's locked!";
            player.GetComponent<doorAudioController>().playLocked();

        }
    }
    public void listenDoor()
    {
        StartCoroutine(doorListen());
    }
    IEnumerator doorListen()
    {
        audioSource.volume = 1;

        p_animator.SetBool("listen", true);
        yield return new WaitForSeconds(2);
        p_animator.SetBool("listen", false);
        audioSource.volume = 0;
    }
    IEnumerator open()
    {
        int tempSpeed = player.GetComponent<Player_Move>().playerSpeed;
        player.GetComponent<Player_Move>().playerSpeed = 0;
        yield return  new WaitForSeconds(secondsToWait);
        if (m_Animator.GetBool("openDoor"))
        {
            m_Animator.SetBool("openDoor", false);
            player.GetComponent<doorAudioController>().playClose();

        }
        else if (m_Animator.GetBool("openDoorReverse"))
        {
            m_Animator.SetBool("openDoorReverse", false);
            player.GetComponent<doorAudioController>().playClose();

        }
        else if (player.transform.position.x<gameObject.transform.position.x)
        {
            m_Animator.SetBool("openDoor", true);
        }
        else
        {
            m_Animator.SetBool("openDoorReverse", true);
        }
        p_animator.SetBool("kick", false);
        player.GetComponent<Player_Move>().playerSpeed = tempSpeed;
    }
}
