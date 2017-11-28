using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speedMultiplier;
    public float defaultHP;
    public float defaultMP;
    public float cooldownTimer;
    public Text cooldownText;
    public GameObject fireBlast;
    public Canvas canvas;
    public Stats statScript;
    public GameObject fireBlastInstance;
    public float invulnerabilityTimer;
    public float currentInvulnerabilityTimer;
    public float fireRate;
    public float scaleModifier;
    public float damageModifier;
    public bool hit;
    public bool cooldown;
    public float range;
    public AudioClip hitSound;
    private AudioSource source;


    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        source.clip = hitSound;
        damageModifier = 1;
        scaleModifier = 0;
        fireRate = 0.5f;
        invulnerabilityTimer = 1;
        currentInvulnerabilityTimer = 1;
        cooldownTimer = 0;
        cooldownText.text = cooldownTimer.ToString("F0");
        statScript = GetComponent<Stats>();
        hit = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float inputX = Input.GetAxis("Horizontal") * Time.deltaTime * speedMultiplier;
        float inputY = Input.GetAxis("Vertical") * Time.deltaTime * speedMultiplier;
        transform.Translate(new Vector3(inputX, inputY, 0));

        if (inputX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (inputX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (cooldownTimer > 0)
        {
            cooldown = false;
            cooldownTimer -= 1 * Time.deltaTime;
        }

        if (cooldownTimer < 0)
        {
            cooldownTimer = 0;
        }

        if (Input.GetMouseButton(0) && cooldownTimer <= 0)
        {
            SpawnControlBlast((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized);
        }

        cooldownText.text = cooldownTimer.ToString("F0");

        if (cooldownText.text == "0")
        {
            cooldownText.text = "";
            //canvas.transform.Find("BlastIcon").transform.Find("CooldownShade").gameObject.SetActive(false);
        }

        currentInvulnerabilityTimer -= 1 * Time.deltaTime;

        if (hit)
        {
            GetComponent<Blinking>().Blink(invulnerabilityTimer);
            hit = false;
        }
    }

    void SpawnControlBlast(Vector2 blastDirection)
    {
        fireBlastInstance = Instantiate(fireBlast, transform);
        fireBlastInstance.GetComponent<ControlBlastController>().direction = blastDirection;
        fireBlastInstance.transform.localScale = new Vector3(0.2f + scaleModifier, 0.2f + scaleModifier, 0.2f);
        fireBlastInstance.GetComponent<ControlBlastController>().damageModifier = damageModifier;
        fireBlastInstance.GetComponent<ControlBlastController>().range = range;
        Physics2D.IgnoreCollision(fireBlastInstance.GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>());
        fireBlastInstance.transform.SetParent(null);
        //canvas.transform.Find("BlastIcon").transform.Find("CooldownShade").gameObject.SetActive(true);
        cooldownTimer = fireRate;
        cooldown = true;
    }

    public void TakeDamage(float damage) {
        
        if (currentInvulnerabilityTimer <= 0)
        {
            source.PlayOneShot(hitSound, 1);
            hit = true;
            GetComponent<Stats>().HP -= damage;
            currentInvulnerabilityTimer = invulnerabilityTimer;
        }
    }
}
