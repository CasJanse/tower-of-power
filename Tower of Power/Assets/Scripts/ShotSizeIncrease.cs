using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotSizeIncrease : MonoBehaviour {

    public GameObject phaseController;

	// Use this for initialization
	void Start () {
        phaseController = GameObject.Find("PhaseController");	
	}
	
	// Update is called once per frame
	void Update () {
        if (!phaseController.GetComponent<PhaseController>().upgradePhase)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            collision.gameObject.GetComponent<PlayerController>().scaleModifier += 0.05f;
            phaseController.GetComponent<PhaseController>().upgradePickedUp = true;
        }
    }
}
