using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_System : MonoBehaviour {
    private GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public float v = .008f;
    public bool start;
    private GameObject mainUI;
    private GameObject doorUI;
    
    public GameObject ftb;
    
    // Use this for initialization
    void Start () {
        start = false;
        mainUI = GameObject.FindGameObjectWithTag("MainUI");
        mainUI.SetActive(false);
        player = GameObject.FindGameObjectWithTag("title");
        
	}
	
	// The camera speed will adjust according to distance away from player allowing for fluid camera movement
	void LateUpdate () {

        //player position within bounds
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y + 3f, yMin, yMax);
        //current camera position
        float x1 = gameObject.transform.position.x;
        float y1 = gameObject.transform.position.y;


       //distances from player to camera
        float distx = Mathf.Abs(x1 - x);
        float disty = Mathf.Abs(y1 - y);
       


        //finds new camera pos using distance and desired camera velocity
        
        if (x < x1 - .1f)
        {
            x1 -= v * distx;
        }
        else if (x > x1 + .1f)
        {
            x1 += v * distx;
        }
        if (y < y1 - .1f)
        {
            y1 -= v * disty;
        }
        else if (y > y1 + .1f)
        {
            y1 += v * disty;
        }

        //camera movement
        gameObject.transform.position = new Vector3(x1, y1, gameObject.transform.position.z);

    }


    
    public IEnumerator fade()
    {
        
        float alpha = 0;
        //fades camera to black using sprite placed in front of camera
        while (alpha < 1)
        {
            ftb.GetComponent<SpriteRenderer>().color= new Color(0,0,0,alpha);
            alpha += .05f;
            yield return new WaitForSeconds(.1f);
        }

        yield return new WaitForSeconds(.5f);

        //fades camera back from black
        while (ftb.GetComponent<SpriteRenderer>().color.a >0)
        {
            ftb.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha);
            alpha -= .05f;
            yield return new WaitForSeconds(.1f);
        }

    }

    //allows other classes to call fading to black
    public void fadeToBlack()
    {
        StartCoroutine(fade());
    }

    //these methods allow the camera to focus on different objects
    public void mainMenu()
    {
        player = GameObject.FindGameObjectWithTag("title");
    }
    public void controlMenu()
    {
        player = GameObject.FindGameObjectWithTag("controlsMenu");
    }
    public void credits()
    {
        player = GameObject.FindGameObjectWithTag("credits");
    }
    public void play()
    {
        start = true;
        mainUI.SetActive(true);
        player = GameObject.FindGameObjectWithTag("Player");
        //StartCoroutine(controls());
        
    }
    
}

    
