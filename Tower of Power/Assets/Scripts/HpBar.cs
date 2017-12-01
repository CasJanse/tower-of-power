using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour {

    public Text HPText;
    public GameObject player;

    // Changed the HP from the player to a string that is displayed as text in the UI.
	// Use this for initialization
	void Start () {
        HPText.text = "HP: " + player.GetComponent<Stats>().HP;
	}
	
	// Update is called once per frame
	void Update () {
        HPText.text = "HP: " + player.GetComponent<Stats>().HP;
    }
}
