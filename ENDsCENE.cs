using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ENDsCENE : MonoBehaviour {

    private GameObject player;
    private Text playerText;

    /*
     * camera.fieldofview variable for zooming in
     * 
     * 
     * 
     * 
     * 
     */
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerText = GameObject.FindGameObjectWithTag("playerText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<Player_Move>().playerSpeed = 0;
            playerText.text = "He's gone!";
            
            StartCoroutine(end());
            
        }
    }
    IEnumerator end()
    {
       
        float endSize = Camera.main.orthographicSize - 6;
        while (Camera.main.orthographicSize >= endSize)
        {
            Camera.main.orthographicSize -= .05f;
            yield return new WaitForSeconds(.01f);
        }
        yield return new WaitForSeconds(1.5f);
        Camera.main.GetComponent<Camera_System>().fadeToBlack();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }
}
