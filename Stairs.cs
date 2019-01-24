using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stairs : MonoBehaviour {


    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public float speed = 0.3f;
    

    private GameObject player;
    private bool contact;
    public bool down;
    public bool up;
    public bool firstDown;
    private bool secondDown;
    public bool firstUp;
    private bool secondUp;
    private bool thirdDown;
    private bool thirdUp;
    private bool buttonDown;
    private bool buttonUp;
    private int savedSpeed;


    Animator p_animator;
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
   
    
    
}
