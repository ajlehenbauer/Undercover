using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour {
    public float waitTime;
    
    private float maxIntensity;
   
	// Use this for initialization
	void Start () {
        maxIntensity = gameObject.GetComponent<Light>().intensity;
        
        StartCoroutine(flicker());
        
	}
	
	// Update is called once per frame
	IEnumerator flicker()
    {

        while (true)
        {
            gameObject.GetComponent<Light>().intensity = Random.Range(0,maxIntensity);
            yield return new WaitForFixedUpdate();
        }
    }
}
