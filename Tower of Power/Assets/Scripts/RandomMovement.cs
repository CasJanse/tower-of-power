using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {

    private Vector3 target;
    public float movementSpeed, roamingSpeed, followingSpeed;
    public bool roaming, controlled, attacking;
    public GameObject player;
    private Vector2 moveDirection;
    

	// Use this for initialization
	void Start () {
        movementSpeed = roamingSpeed;
        roaming = true;
        attacking = false;
        target = Random.insideUnitCircle * 5;
        target += transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Vector2.Distance(target, transform.position) < 1 && roaming)
        {
            movementSpeed = roamingSpeed;
            target = Random.insideUnitCircle * 5;
            target += transform.position;
        }

        if (controlled && !attacking)
        {
            movementSpeed = followingSpeed;
            target = player.transform.position;
        }

        moveDirection = (target - transform.position).normalized;

        if (roaming || (controlled && Vector3.Distance(target, transform.position) > 1) || attacking)
        {
            GetComponent<Rigidbody2D>().velocity = moveDirection * Time.deltaTime * movementSpeed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }

        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Soldier" && tag == "Enemy")
        {
            target = collision.transform.position;
            attacking = true;
            roaming = false;
        }
    }
}
