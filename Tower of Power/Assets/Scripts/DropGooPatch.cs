using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGooPatch : MonoBehaviour {

    public GameObject gooPatch;
    private GameObject gooInstance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Drops a goo patch on the ground.
    public void DropGoo() {
        gooInstance = Instantiate(gooPatch, transform);
        gooInstance.transform.SetParent(null);
    }

    //Destroys the goo patch in the upgrade phase if it is over an upgrade.
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Upgrade")
        {
            Destroy(gameObject);
        }
    }
}
