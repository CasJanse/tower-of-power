using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooPatch : MonoBehaviour {

    public float timeLeft;
    public float damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 30)
        {
            Destroy(gameObject);
        }

        transform.localScale = new Vector3(( 6.0f * (1.0f / 60.0f) * timeLeft), 6.0f * ((1.0f / 60.0f) * timeLeft), 6.0f * ((1.0f / 60.0f) * timeLeft));
	}

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
