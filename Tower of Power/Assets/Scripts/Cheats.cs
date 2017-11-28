using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    //This function is used for cheat inputs to make playtesting the game easier.
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level1");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        if (Input.GetKeyDown(KeyCode.T))
        {
            player.GetComponent<Stats>().HP += 100;
            player.GetComponent<PlayerController>().range += 10;
            player.GetComponent<PlayerController>().damageModifier += 3;
            player.GetComponent<PlayerController>().fireRate -= 0.1f;
        }
	}
}
