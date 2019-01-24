using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    private bool key;
	// Use this for initialization
	void Start () {
        key = false;
	}
	public void getKey()
    {
        key = true;
    }
    public bool hasKey()
    {
        return key;
    }
	
}
