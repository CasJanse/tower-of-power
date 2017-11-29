using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireRateUp : MonoBehaviour {

    public GameObject phaseController;

    // Use this for initialization
    void Start()
    {
        phaseController = GameObject.Find("PhaseController");
    }

    // Update is called once per frame
    //Destroys the upgrade when the game is not in the upgrade phase.
    void Update()
    {
        if (!phaseController.GetComponent<PhaseController>().upgradePhase)
        {
            Destroy(gameObject);
        }
    }

    //Allowes the player to pick up the upgrade and gain its effect.
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            collision.gameObject.GetComponent<PlayerController>().fireRate -= 0.02f;
            phaseController.GetComponent<PhaseController>().upgradePickedUp = true;
        }
    }
}
