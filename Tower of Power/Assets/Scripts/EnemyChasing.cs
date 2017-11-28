using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasing : MonoBehaviour {

    public GameObject player;
    public Vector3 currentTarget;
    private Vector2 moveDirection;
    private GameObject target;
    public bool attacking;
    public int movementSpeed;
    public bool hasTarget;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (hasTarget)
        {
            if (target.tag == "Soldier")
            {
                currentTarget = target.transform.position;
            }
        }
        else
        {
            currentTarget = player.transform.position;
        }


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

        if (Vector2.Distance(currentTarget, transform.position) <= 1)
        {
            attacking = true;
        }
    }
}
