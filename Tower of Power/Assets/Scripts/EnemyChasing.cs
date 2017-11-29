using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasing : MonoBehaviour {

    public GameObject player;
    public Vector3 currentTarget;
    private Vector2 moveDirection;
    private GameObject target;
    public bool attacking;
    private float attackDistance;
    public int movementSpeed;

    // Use this for initialization
    void Start () {
        attackDistance = 1;
	}
	
	// Update is called once per frame
    //Moves the enemy towards the player.
	void Update () {
        
        currentTarget = player.transform.position;
        


        moveDirection = (currentTarget - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = moveDirection * Time.deltaTime * movementSpeed;

        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //Attack the player if he is close enough.
        if (Vector2.Distance(currentTarget, transform.position) <= attackDistance)
        {
            attacking = true;
        }
    }
}
