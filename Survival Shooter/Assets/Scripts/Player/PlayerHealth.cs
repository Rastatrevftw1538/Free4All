﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


namespace CompleteProject
{
	public class PlayerHealth : MonoBehaviour
    {
		public static GameObject TheMan;
		[SerializeField]
        public int startingHealth = 100;                            // The amount of health the player starts the game with.
        public int currentHealth; 									// The current health the player has.
		[SerializeField]
        public Slider healthSlider;                                 // Reference to the UI's health bar.
        public AudioClip deathClip;                                 // The audio clip to play when the player dies.
        public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
        public Color flashColour = new Color(0f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

		public Material damageImage;

        Animator anim;                   							// Reference to the Animator component.
        public AudioSource playerAudio;                                    // Reference to the AudioSource component.
        PlayerMovement playerMovement;                              // Reference to the player's movement.
		PlayerAttack playerAttack;                                  // Reference to the PlayerAttack script.
        public bool isDead;                                                // Whether the player is dead.
        public bool damaged;   										// True when the player gets damaged.
		public bool isOnExit;										// Whether player can exit								
        public SceneChangeColl _SceneChangeColl;

        private Slider Ice;
        private Slider Fire;
        private Slider Earth;

        void Start()
		{
			// Setting up the references.
			anim = GetComponent <Animator> ();
			playerAudio = GetComponent <AudioSource> ();
			playerMovement = GetComponent <PlayerMovement> ();
			playerAttack = GetComponentInChildren <PlayerAttack> ();

			TheMan = GameObject.FindGameObjectWithTag("Ice").GetComponent<GameObject>();
			TheMan = GameObject.FindGameObjectWithTag("Earth").GetComponent<GameObject>();
			TheMan = GameObject.FindGameObjectWithTag("Fire").GetComponent<GameObject>();


			// Set the initial health of the player.
			currentHealth = startingHealth;

			if (gameObject.tag == "Ice")
			{
				healthSlider = GetComponent("P1_HealthSlider") as Slider;
                healthSlider = GameObject.FindGameObjectWithTag("slideI").GetComponent<Slider>();
			}

			if (gameObject.tag == "Fire")
			{
				healthSlider = GetComponent("P2_HealthSlider") as Slider;
			    healthSlider = GameObject.FindGameObjectWithTag("slideF").GetComponent<Slider>();
            }

			if (gameObject.tag == "Earth")
			{
				healthSlider = GetComponent("P3_HealthSlider") as Slider;
			    healthSlider = GameObject.FindGameObjectWithTag("slideE").GetComponent<Slider>();
            }
		}


        void UpdateHealth (int amount)
		{
			// If the player has just been damaged...
			if (damaged)
			{
				// ... set the colour of the damageImage to the flash colour.
				damageImage.color = flashColour;

				currentHealth -= amount;


				// Set the health bar's value to the current health.
				healthSlider.value = currentHealth;
			}
            // Otherwise...
            else
			{
				// ... transition the colour back to clear.
				damageImage.color = Color.Lerp (damageImage.color, new Color (1f, 1f, 1f, 1f), flashSpeed * Time.deltaTime);
			}

			// Reset the damaged flag.
			damaged = false;

			if (!playerAttack.enabled && !isDead)
            {
				playerAttack.enabled = true;
			}
		}


        public void TakeDamage (int amount)
        {
            // Set the damaged flag so the screen will flash.
            damaged = true;

            // Reduce the current health by the damage amount.
		

				currentHealth -= amount;
	

				// Set the health bar's value to the current health.
				healthSlider.value = currentHealth;

				// Play the hurt sound effect.
				playerAudio.Play ();

				Debug.Log (gameObject.name + " has taken damage");

            // If the player has lost all it's health and the death flag hasn't been set yet...
            if(currentHealth <= 0 && !isDead)
            {
                // ... it should die.
                Death ();
				//playerAudio.clip = deathClip;
				playerAudio.PlayOneShot (deathClip);
                HealthManager.instance.CheckUp();
            }
        }

		public void GiveHealth (int amount)
		{

			currentHealth += amount;

			healthSlider.value = currentHealth;

			if (currentHealth >= 100) {
				return;
			}
		}

        void Death ()
        {
            _SceneChangeColl.alivePlayers -= 1;

            // Set the death flag so this function won't be called again.
            isDead = true;

            // Turn off any remaining shooting effects.
			playerAttack.DisableEffects ();

            // Tell the animator that the player is dead.
            anim.SetTrigger ("Die");

            // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).

            // Turn off the movement and shooting scripts.
            playerMovement.enabled = false;
			playerAttack.enabled = false;

			//Destroy(gameObject);
        }
        void OnTriggerEnter(Collider other)
        {
			if (other.gameObject.tag == "Exit")
			{
				isOnExit = true;
				//Switch.CheckSceneSwitch();
			    Debug.Log("How Long Can This Go On");
			}
		}
		private void OnTriggerExit(Collider other)
		{
			if(other.gameObject.tag == "Exit")
			{
				isOnExit = false;
			}
		}
    }
}