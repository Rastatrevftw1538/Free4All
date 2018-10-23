using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CompleteProject
{
public class HealthPack : MonoBehaviour {

	public GameObject healthPack;

	public Collider HealthBody;

	public int healthGain = -25;

	PlayerHealth Playerhealth;
	// Use this for initialization
	void Start () {
			HealthBody = GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () { 
			
		}

	public void Die(){
			Destroy (gameObject);
			Debug.Log ("hit");
	}

		void OnTriggerEnter (Collider other)
		{
			if (other.gameObject.tag == "Ice" && HealthManager.instance.iceHealth.currentHealth >=1 ) {
				if (HealthManager.instance.iceHealth.currentHealth <= 0) {
					return;
				}
				if (HealthManager.instance.iceHealth.currentHealth >= 100) {
					return;
				}
				if (HealthManager.instance.iceHealth.currentHealth >= 75) {
					HealthManager.instance.iceHealth.currentHealth = 100;
				}
				HealthManager.instance.iceHealth.GiveHealth (healthGain);
				Destroy(healthPack);
			}
			if (other.gameObject.tag == "Fire" && HealthManager.instance.fireHealth.currentHealth >=1) {
				if (HealthManager.instance.fireHealth.currentHealth <= 0) {
					return;
				}
				if (HealthManager.instance.fireHealth.currentHealth >= 100) {
					return;
				}
				if (HealthManager.instance.fireHealth.currentHealth >= 75) {
					HealthManager.instance.fireHealth.currentHealth = 100;
				}
				HealthManager.instance.fireHealth.GiveHealth (healthGain);
				Destroy(healthPack);
			}
			if (other.gameObject.tag == "Earth" && HealthManager.instance.earthHealth.currentHealth >=1) {
				if (HealthManager.instance.earthHealth.currentHealth <= 0) {
					return;
				}
				if (HealthManager.instance.earthHealth.currentHealth >= 100) {
					return;
				}
				if (HealthManager.instance.earthHealth.currentHealth >= 75) {
					HealthManager.instance.earthHealth.currentHealth = 100;
				}
				HealthManager.instance.earthHealth.GiveHealth (healthGain);
				Destroy(healthPack);
			}
		}
	}
}