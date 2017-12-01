using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour {

    public GameObject projectile;
    public float fireCooldown;
    private float fireTimer;

	// Use this for initialization
	void Start () {
        fireTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        fireTimer += 1 * Time.deltaTime;
	}

    //Starts firing at the player when in range
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Fire(collision.gameObject);
        }
    }

    //Fire an ice projectile at the target location
    private void Fire(GameObject target)
    {
        if (fireTimer >= fireCooldown)
        {
            Vector2 direction = (target.transform.position - transform.position).normalized;
            GameObject projectileInstance = Instantiate(projectile, transform);
            projectileInstance.GetComponent<ProjectileController>().direction = direction;
            projectileInstance.transform.SetParent(null);
            fireTimer = 0;
        }
    }
}
