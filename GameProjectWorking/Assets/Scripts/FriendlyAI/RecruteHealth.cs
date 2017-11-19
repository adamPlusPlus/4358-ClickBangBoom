using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RecruteHealth : MonoBehaviour {
    public int startingHealth = 100;                            
    public int currentHealth;                                
    public Slider healthSlider;
    public Image damageImage;         
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    private float invincibleTime = 1.0f;
    private float nextDamage;

    Animator anim;                                              
    PlayerControl playerMovement;                              
    bool isDead;                                            
    bool damaged;


    void Awake()
    {
          // Set the initial health of the player.
        currentHealth = startingHealth;
    }
    // Use this for initialization
    void Start () {
		
	}

    void Update()
    {
        // If the Recrute has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
        healthSlider.value = currentHealth;

        if (isDead)
        {
            playerMovement.enabled = false;
            for (int i = 0; i < transform.childCount; ++i)
            { transform.GetChild(i).gameObject.active = false; }
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }


    }
    public void TakeDamage(int amount)
    {
        if (Time.time > nextDamage)
        {
            // Set the damaged flag so the screen will flash.
            damaged = true;

            // Reduce the current health by the damage amount.
            currentHealth -= amount;

            // Set the health bar's value to the current health.
            healthSlider.value = currentHealth;

            // Play the hurt sound effect.
            //playerAudio.Play();

            // If the player has lost all it's health and the death flag hasn't been set yet...
            if (currentHealth <= 0 && !isDead)
            {
                // ... it should die.
                Death();
            }

            nextDamage = Time.time + invincibleTime;
        }
    }
    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

       // anim.SetTrigger("Die");

    }
}
