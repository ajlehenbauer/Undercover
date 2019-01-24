using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityStandardAssets.CrossPlatformInput;

public class Player_Move : MonoBehaviour {

	public int playerSpeed = 10;
	public int playerJumpPower = 1250;
	private float moveX;
    public bool isGrounded;
    public float distanceToBottomOfPlayer = 0.9f;
    public int jumpCount = 0;
    public bool doorCollision;
    public bool stairCollision;
    private GameObject door;
    int move;
    private GameObject doorUI;
    public GameObject buttonToListen;
    
    public GameObject joyController;
    private Text message;
    
    public GameObject joystick;

    private float joyRadius;
    //TODO
    /*
     * Set canvas buttons to stair up/down functions
     * 
     * 
     * 
     * 
     * 
     */

    private void Start()
    {
        //joyRadius = 200;
        joyRadius = 100;

        
        doorUI = GameObject.FindGameObjectWithTag("doorCanvas");
        doorUI.SetActive(false);

    }
    // Update is called once per frame
    void Update () {
        
        animate();
		PlayerMove ();
        PlayerMoveAlt();
        //checkFall();
        //joyStickMove();
        //PlayerRaycast();
	}
    private void checkFall()
    {
        float nextY = GetComponent<Rigidbody2D>().velocity.y+gameObject.transform.position.y;
        if (!GetComponent<Animator>().GetBool("stairs"))
        {
            if (nextY < gameObject.transform.position.y)
            {
                GetComponent<Animator>().SetBool("falling", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("falling", false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "door")
        {

            if (collision.GetComponent<Door>().canListen)
            {
                buttonToListen.SetActive(true);
            }
            else
            {
                buttonToListen.SetActive(false);

            }
            doorUI.SetActive(true); 
            doorCollision = true;
            door = collision.gameObject;
        }
        
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "door")
        {
            doorUI.SetActive(false);
            doorCollision = false;
        }
        
        
    }

    public void openButton()
    {
        if (doorCollision)
        {
            door.GetComponent<Door>().openDoor();
            
            move = 0;
            
        }
    }
    public void listenButton()
    {
        if (doorCollision)
        {
            door.GetComponent<Door>().listenDoor();
            
            move = 0;
            
        }
    }
    
    void animate()
    {
        //ANIMATIONS
        if ((moveX != 0 || move!=0) && playerSpeed!=0)
        {
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }
    }

    void joyStickMove()
    {

        Vector3 joyPo = Camera.main.WorldToScreenPoint(joystick.transform.position);

        float d = Mathf.Sqrt(Mathf.Pow(Input.mousePosition.x - joyPo.x, 2) + Mathf.Pow(Input.mousePosition.y - joyPo.y, 2));
        float xs = (Input.mousePosition.x - joyPo.x) * playerSpeed / joyRadius;
        float ys = (Input.mousePosition.y - joyPo.y) * playerSpeed / joyRadius;
        if (d < joyRadius && Input.GetMouseButton(0))
        {
            if (ys < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (ys > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            gameObject.GetComponent<Animator>().SetBool("IsRunning", true);
            joyController.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 20));
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xs, ys);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 circle = Camera.main.WorldToScreenPoint(new Vector2(joystick.transform.position.x, joystick.transform.position.y));
            Vector2 point = circle + (joyRadius * ((mouse - circle) / (mouse - circle).magnitude));
            xs = point.x * playerSpeed / joyRadius;
            ys = point.y * playerSpeed / joyRadius;
            joyController.transform.position = Camera.main.ScreenToWorldPoint(point);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xs, ys);

        }
        else
        {
            joyController.transform.position = joystick.transform.position;
            gameObject.GetComponent<Animator>().SetBool("IsRunning", false);
        }

    }
    void PlayerMoveAlt()
    {
        
        
        move = 0;
        if (Input.GetMouseButton(0))
        {
            if (doorCollision||stairCollision )
            {
                if (!(Input.mousePosition.x > Screen.width-200 && Input.mousePosition.y < 200))
                {
                    if (Input.mousePosition.x < Screen.width / 2)
                    {
                        move = -1;
                    }
                    else
                    {
                        move = 1;
                    }
                }
               
            }
            else
            {
                if (Input.mousePosition.x < Screen.width / 2)
                {
                    move = -1;
                }
                else
                {
                    move = 1;
                }
            }

        }
        else
        {
            move = 0;
        }
        
        

        //PLAYER DIRECTION
        if (move < 0.0f && gameObject.GetComponent<Rigidbody2D>().gravityScale != 0 && playerSpeed != 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (move > 0.0f && gameObject.GetComponent<Rigidbody2D>().gravityScale != 0 && playerSpeed != 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (moveX == 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(move * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }

    }
    void PlayerMove () {
		//CONTROLS
		moveX = Input.GetAxis("Horizontal");
        

		

		//PLAYER DIRECTION
		if (moveX < 0.0f && playerSpeed != 0) {
            GetComponent<SpriteRenderer>().flipX = true;
		} else if (moveX > 0.0f && playerSpeed != 0) {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //PHYSICS
        
        
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        
    }


    
   
    /*
    void PlayerRaycast()
    {
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottomOfPlayer && rayUp.collider.name == "CMG_StarBox") {
            Destroy (rayUp.collider.gameObject);
        }
            RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag == "Enemy") {
            GetComponent<Rigidbody2D>().AddForce(force: Vector2.up * 500);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce(Vector2.down * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //Destroy(hit.collider.gameObject);
        }
        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag != "Enemy") {
            isGrounded = true;
        }
    }*/
}
