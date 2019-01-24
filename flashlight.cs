using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour {
    GameObject player;
    // Use this for initialization
    float rotation;
    public float speed;
    public float min;
    public float max;
    Vector3 rotationVector;
    bool down;
    void Start () {
        down = true;
        player = GameObject.FindGameObjectWithTag("Player");
        rotationVector = gameObject.transform.rotation.eulerAngles;

    }
	
	// Update is called once per frame
	void Update () {


        if (player.GetComponent<Animator>().GetBool("IsRunning"))
        {
            

            if (rotation >= max)
            {
                down = false;
            }
            if (rotation <= min)
            {
                down = true;
            }

            if (down)
            {
                rotation +=  speed;
                rotationVector.x = rotation;
                gameObject.transform.eulerAngles = rotationVector;
            }
            else
            {
                rotation -= speed;
                rotationVector.x = rotation;
                gameObject.transform.eulerAngles = rotationVector;
            }


        }


	}
}
