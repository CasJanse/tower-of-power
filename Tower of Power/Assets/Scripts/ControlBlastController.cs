using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBlastController : MonoBehaviour {

    public Vector3 direction;
    public float movementSpeed, damage, damageModifier, range;
    public AudioClip enemyHitSound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        source.clip = enemyHitSound;
        damage = 1;
        GetComponent<Rigidbody2D>().velocity = direction.normalized * Time.deltaTime * movementSpeed;
    }
	
	// Update is called once per frame
	void Update () {

        //Give the fireball a direction and destroy the fireball once it has traveled as far as it is allowed to.
        
        range -= Time.deltaTime;
        
        if (range <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check if the fireball has hit an enemy. The enemies have a large trigger area around them to indicate their sight so the fireball
        //only hits the enemy if it didn't collide with another trigger.
        if (collision.isTrigger == false)
        {
            if (collision.tag == "Enemy")
            {
                collision.GetComponent<EnemyController>().hit = true;
                collision.GetComponent<EnemyController>().takeDamage = damage * damageModifier;
                source.PlayOneShot(enemyHitSound, 1);
                GetComponent<SpriteRenderer>().enabled = false;
                CircleCollider2D[] colliders = gameObject.GetComponents<CircleCollider2D>();
                colliders[1].enabled = false;
                Destroy(gameObject,enemyHitSound.length);
            }
        }
    }

    //This function destroys the fireball when it has hit a wall.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "House" || collision.gameObject.tag == "Wall" || collision.gameObject.tag == "InvisibleWall")
        {
            Destroy(gameObject);
        }
    }
}
