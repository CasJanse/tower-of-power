using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageUpgrade : MonoBehaviour
{

    public GameObject phaseController;

    // Use this for initialization
    void Start()
    {
        phaseController = GameObject.Find("PhaseController");
    }

    // Update is called once per frame
    //This function deletes the upgrade if the game shifts to the fighting phase.
    void Update()
    {
        if (!phaseController.GetComponent<PhaseController>().upgradePhase)
        {
            Destroy(gameObject);
        }
    }

    //Adds the damage upgrade when the player picks it up.
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            collision.gameObject.GetComponent<PlayerController>().damageModifier += 0.2f;
            phaseController.GetComponent<PhaseController>().upgradePickedUp = true;
        }
    }
}
