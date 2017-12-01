using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HPUpgrade : MonoBehaviour
{

    private GameObject phaseController;

    // Use this for initialization
    void Start()
    {
        phaseController = GameObject.Find("PhaseController");
    }

    // Update is called once per frame
    //Removes the upgrade when the ugrade phase is over.
    void Update()
    {
        if (!phaseController.GetComponent<PhaseController>().upgradePhase)
        {
            Destroy(gameObject);
        }
    }

    //Applies upgrade to player when picked up.
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            collision.gameObject.GetComponent<Stats>().HP += 1f;
            phaseController.GetComponent<PhaseController>().upgradePickedUp = true;
        }
    }
}
