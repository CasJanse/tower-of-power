using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour {
    
    private float blinkTime;
    private float currentBlink;
    private bool rendererEnbaled;
    public float timeBetweenBlink;
    public float timeBetweenBlinkNeeded;

    // Use this for initialization
    void Start () {
        currentBlink = 0;
        blinkTime = 0;
	}
	
	// Update is called once per frame
    //This Update makes the player blink after he has been hit by an anemy attack. The function uses a timer to rapidly switch between the 
    //normal and blinked state. If the player shouldn't be blinking he is rendered normally.
	void Update () {
        if (currentBlink < blinkTime)
        {
            if (rendererEnbaled && timeBetweenBlink >= timeBetweenBlinkNeeded)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                rendererEnbaled = false;
                timeBetweenBlink = 0;
            }
            else if (!rendererEnbaled && timeBetweenBlink >= timeBetweenBlinkNeeded)
            {
                GetComponent<SpriteRenderer>().enabled = true;
                rendererEnbaled = true;
                timeBetweenBlink = 0;
            }
            currentBlink += 1 * Time.deltaTime;
            timeBetweenBlink += 1 * Time.deltaTime;
        }
        else
        {
            currentBlink = 0;
            blinkTime = 0;
            GetComponent<SpriteRenderer>().enabled = true;
            rendererEnbaled = true;
            timeBetweenBlink = timeBetweenBlinkNeeded;
        }
	}

    public void Blink(float blinkTime) {
        this.blinkTime = blinkTime;
    }
}
