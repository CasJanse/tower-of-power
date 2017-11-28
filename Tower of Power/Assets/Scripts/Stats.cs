using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    public float HP;
    public float MP;
    public int difficultyScore;
    public AudioClip deathSound;
    private AudioSource source;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (HP <=0)
        {
            if (name == "Orc(Clone)")
            {
                GetComponent<DropGooPatch>().DropGoo();
            }

            if (tag == "Player")
            {
                source = GetComponent<AudioSource>();
                source.clip = deathSound;
                source.PlayOneShot(deathSound, 1);
                GetComponent<SpriteRenderer>().enabled = false;
                Destroy(gameObject, deathSound.length);
            }
            Destroy(gameObject);
        }
	}
}
