using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewStairs : MonoBehaviour {
  
    public float speed = 0.3f;
    
    Animator p_animator;
    private GameObject player;
    private bool contact;
    public bool down;
    public bool up;
    private bool check1;
    private bool check2;
    private bool check3;
    private bool buttonDown;
    private bool buttonUp;
    private int savedSpeed;
    private GameObject stairUp;
    private GameObject stairDown;
    private List<GameObject> stairList;
    private GameObject currentStair;
    // Use this for initialization
    void Start () {
        stairUp = GameObject.FindGameObjectWithTag("stairUp");
        stairDown = GameObject.FindGameObjectWithTag("stairDown");
        stairDown.SetActive(false);
        stairUp.SetActive(false);
        stairList = new List<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player");
        savedSpeed = player.GetComponent<Player_Move>().playerSpeed;
        p_animator = player.GetComponent<Animator>();
        check1 = true;
        check2 = false;
        check3 = false;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (down)
        {
            stepDown(currentStair);
        }
        else if (up)
        {
            stepUp(currentStair);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "stairs")
        {
            stairList.Add(collision.gameObject);
            if (gameObject.transform.position.y > collision.GetComponent<Stairs>().pointB.position.y)
            {
                stairDown.SetActive(true);
            }
            else if (gameObject.transform.position.y < collision.GetComponent<Stairs>().pointB.position.y)
            {
                stairUp.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "stairs")
        {
            stairList.Remove(collision.gameObject);
            if (gameObject.transform.position.y > collision.GetComponent<Stairs>().pointB.position.y)
            {
                stairDown.SetActive(false);
            }
            else if (gameObject.transform.position.y < collision.GetComponent<Stairs>().pointB.position.y)
            {
                stairUp.SetActive(false);
            }
        }
    }


    
    public void moveDown()
    {
        down = true;
        foreach (GameObject x in stairList)
        {
            if (gameObject.transform.position.y > x.GetComponent<Stairs>().pointB.position.y)
            {
                currentStair=x;
                
            }
        }


    }
    public void moveUp()
    {

        foreach (GameObject x in stairList)
        {
            if (gameObject.transform.position.y < x.GetComponent<Stairs>().pointB.position.y)
            {
                currentStair = x;
                up = true;
            }
        }

    }
    void stepDown(GameObject stair)
    {

        
        if (check1)
        {
            lockPlayer();
            stepToA(stair);
            if (gameObject.transform.position == stair.GetComponent<Stairs>().pointA.position)
            {
                check1 = false;
                check2 = true;
            }
        }
        if (check2)
        {
            stepToB(stair);
            if (gameObject.transform.position == stair.GetComponent<Stairs>().pointB.position)
            {
                check2 = false;
                check3 = true;
            }
        }
        if (check3)
        {
            stepToC(stair);
            if (gameObject.transform.position == stair.GetComponent<Stairs>().pointC.position)
            {
                releasePlayer();
                check1 = true;
                check2 = false;
                check3 = false;
                

            }
        }
    }
    void stepUp(GameObject stair)
    {
        
        if (check1)
        {
            lockPlayer();
            stepToC(stair);
            if (gameObject.transform.position == stair.GetComponent<Stairs>().pointC.position)
            {
                check1 = false;
                check2 = true;

            }
        }
        if (check2)
        {
            stepToB(stair);
            if (gameObject.transform.position == stair.GetComponent<Stairs>().pointB.position)
            {
                check2 = false;
                check3 = true;
            }
        }
        if (check3)
        {
            stepToA(stair);
            if (gameObject.transform.position == stair.GetComponent<Stairs>().pointA.position)
            {
                check1 = true;
                check2 = false;
                check3 = false;
                releasePlayer();

            }
        }
    }
    void stepToA(GameObject stair)
    {
        if (player.transform.position.x> stair.GetComponent<Stairs>().pointA.position.x)
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
        player.transform.position = Vector3.MoveTowards(player.transform.position, stair.GetComponent<Stairs>().pointA.position, speed);

    }
    void stepToB(GameObject stair)
    {
        if (player.transform.position.x > stair.GetComponent<Stairs>().pointB.position.x)
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
        player.transform.position = Vector3.MoveTowards(player.transform.position, stair.GetComponent<Stairs>().pointB.position, speed);
    }
    void stepToC(GameObject stair)
    {
        if (player.transform.position.x > stair.GetComponent<Stairs>().pointC.position.x)
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
        player.transform.position = Vector3.MoveTowards(player.transform.position, stair.GetComponent<Stairs>().pointC.position, speed);
    }
    bool checkRelease(GameObject stair)
    {
        if(down && gameObject.transform.position == stair.GetComponent<Stairs>().pointC.position)
        {
            return true;
        }
        else if(up && gameObject.transform.position == stair.GetComponent<Stairs>().pointA.position)
        {
            return true;
        }
        return false;
    }
    void releasePlayer()
    {
        down = false;
        up = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 9.8f;
        player.GetComponent<Collider2D>().enabled = true;
        player.GetComponent<Player_Move>().playerSpeed = savedSpeed;
        gameObject.GetComponent<Animator>().SetBool("stairs", false);
    }
    void lockPlayer()
    {
        gameObject.GetComponent<Animator>().SetBool("stairs", true);
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<Collider2D>().enabled = false;
        
        player.GetComponent<Player_Move>().playerSpeed = 0;
    }
}
