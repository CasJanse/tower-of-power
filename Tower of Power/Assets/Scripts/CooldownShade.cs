using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownShade : MonoBehaviour {

    public GameObject player;
    public Image shade;
    private float defaultShadeHeight;
    private float shadeHeight;

	// Use this for initialization
	void Start () {
        defaultShadeHeight = 100;
	}
	
	// Update is called once per frame
    //This update regulates the size of the cooldownshade that's over the fireball UI icon.
	void Update () {
        if (player.GetComponent<PlayerController>().cooldown)
        {
            shadeHeight = defaultShadeHeight;
        }
        shadeHeight -= 2 / player.GetComponent<PlayerController>().fireRate;
        if (player.GetComponent<PlayerController>().fireRate <= 0)
        {
            shadeHeight = 0;
        }
        shade.rectTransform.sizeDelta = new Vector2(defaultShadeHeight, shadeHeight);
	}
}
