using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour {

    public Text HPText;
    public GameObject player;

	// Use this for initialization
	void Start () {
        HPText.text = "HP: " + player.GetComponent<Stats>().HP;
	}
	
	// Update is called once per frame
	void Update () {
        HPText.text = "HP: " + player.GetComponent<Stats>().HP;
    }
}
