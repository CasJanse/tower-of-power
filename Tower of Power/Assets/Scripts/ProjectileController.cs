using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public Vector3 direction;
    public float movementSpeed;
    public float damage;
    public GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        GetComponent<Rigidbody2D>().velocity = direction.normalized * Time.deltaTime * movementSpeed;
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "House" || collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
