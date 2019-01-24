using System.Diagnostics;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    public Text message;
    public Text message2;
    private bool notHit;
    public GameObject npc;
    private int tempSpeed;
    
    void Start()
    {
        
        //Create Text component of a canvas object through unity named "Message"
        
        message.color = Color.white;
        message.text = "";
        message2.text = "";
        notHit =true;
        
    }
    private void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && notHit)
        {
            StartCoroutine(displayText(other));

        }
        //Message to display if main dialouge is done
        else if(other.gameObject.tag == "Player" && !notHit)
        {
            message.text = "touch to move left and right";
        }
    }
    IEnumerator displayText(Collider2D other)
    {
        tempSpeed = other.gameObject.GetComponent<Player_Move>().playerSpeed;
        other.gameObject.GetComponent<Player_Move>().playerSpeed = 0;

        while (!Camera.main.GetComponent<Camera_System>().start)
        {
            yield return null;
        }
        yield return new WaitForSeconds(2);
        message.text = "WITH THIS INFORMATION, WE COULD PUT HALF THE ORGANIZATION AWAY FOR GOOD";
        
        //will continue after mouse button is clicked
        //copy this block for every new line of dialouge
        while (!Input.GetMouseButtonDown(0)) {
        yield return null;
        }
        //audioSource.Play();
        message.text = "";
        message2.text = "IT'S THE OTHER HALF I THINK I'M WORRIED ABOUT";
        yield return new WaitForSeconds(.5f);
        //
        while (!Input.GetMouseButtonDown(0))
        {
                yield return null;
        }
        //audioSource.Play();
        message2.text = "";
        message.text = "THERE'S NO NEED TO WORRY, I WON'T LET THEM HURT YOU";
        yield return new WaitForSeconds(.5f);
        while (!Input.GetMouseButtonDown(0))
        {
                    yield return null;
        }
        //audioSource.Play();
        message.text = "";
        message2.text = "I'M SORRY...\n I WISH I BELIEVED THAT";
        yield return new WaitForSeconds(.5f);
        while (!Input.GetMouseButtonDown(0))
        {
                        yield return null;
        }
        //audioSource.Play();
        Camera.main.GetComponent<Camera_System>().fadeToBlack();
        message.text = "";
        message2.text = "";
        yield return new WaitForSeconds(2);
        message.alignment = TextAnchor.MiddleCenter;
        message.text = "touch to move left and right";
        Destroy(npc);
        //let player move again
        other.gameObject.GetComponent<Player_Move>().playerSpeed = tempSpeed;
        notHit=false;
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            message.text = "";
        }
    }
}
