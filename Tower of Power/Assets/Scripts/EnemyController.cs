using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject player;
    public float damage;
    public bool hit;
    public float takeDamage;
    private Color collideColor;
    private Color normalColor;
    private bool colored;
    private float coloredTimer;
    private float coloredTime;

    // Use this for initialization
    void Start () {
        coloredTime = 0.15f;
        collideColor = new Color(255,0,0,10);
        normalColor = new Color(0, 0, 0);
	}
	
	// Update is called once per frame
    //This function causes the enemy to flash red whenever he get hit by a fireball.
	void Update () {
        if (hit)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            colored = true;
            coloredTimer = 0;
            GetComponent<Stats>().HP -= takeDamage;
            hit = false;
        }
        coloredTimer += 1 * Time.deltaTime;
        if (colored && coloredTimer >= coloredTime)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
	}

    //Damages the player whenever the enemy collides with him.
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "Player")
        {
            player.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
