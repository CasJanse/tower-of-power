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

    public void DropGoo() {
        gooInstance = Instantiate(gooPatch, transform);
        //gooInstance.transform.localScale = new Vector3(6, 6, 1);
        gooInstance.transform.SetParent(null);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Upgrade")
        {
            Destroy(gameObject);
        }
    }
}
