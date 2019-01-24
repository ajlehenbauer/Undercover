using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public GameObject joyController;
    private float joyRadius;
    public GameObject joystick;
    public int playerSpeed = 10;
    // Use this for initialization
    void Start () {
        joyRadius = 100;
    }
	
	// Update is called once per frame
	void Update () {
        joyStickMove();
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
            else if(ys>0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            gameObject.GetComponent<Animator>().SetBool("IsRunning", true);
            joyController.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 20));
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xs, ys);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 mouse=new Vector2(Input.mousePosition.x,Input.mousePosition.y);
            Vector2 circle = Camera.main.WorldToScreenPoint(new Vector2(joystick.transform.position.x, joystick.transform.position.y));
            Vector2 point = circle + (joyRadius * ((mouse - circle) / (mouse - circle).magnitude));
            xs = point.x * playerSpeed / joyRadius;
            ys= point.y * playerSpeed / joyRadius;
            joyController.transform.position = point;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xs, ys);


        }
        else
        {
            joyController.transform.position = joystick.transform.position;
            gameObject.GetComponent<Animator>().SetBool("IsRunning", false);
        }

    }
}
