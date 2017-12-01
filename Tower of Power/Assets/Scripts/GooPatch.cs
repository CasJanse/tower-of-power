using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooPatch : MonoBehaviour {

    private float timeLeft, destroyTimer, damage;

	// Use this for initialization
	void Start () {
        timeLeft = 60.0f;
        destroyTimer = 30.0f;
        damage = 1;
	}
	
	// Update is called once per frame
    //Timer that destroys the goo patch after 30 seconds.
	void Update () {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= destroyTimer)
        {
            Destroy(gameObject);
        }

        transform.localScale = new Vector3(( 6.0f * (1.0f / 60.0f) * timeLeft), 6.0f * ((1.0f / 60.0f) * timeLeft), 6.0f * ((1.0f / 60.0f) * timeLeft));
	}

    //Collision with the player or an upgrade.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }

        if (collision.tag == "Upgrade")
        {
            Destroy(gameObject);
        }
    }
}
