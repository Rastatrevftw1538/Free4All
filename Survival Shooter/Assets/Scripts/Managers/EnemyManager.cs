﻿using UnityEngine;


namespace CompleteProject
{
	public class EnemyManager : MonoBehaviour
    {
        //public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject enemy;                // The enemy prefab to be spawned.
        public float spawnTime = 3f;            // How long between each spawn.
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
        public int enemiesAllowed = 20;      //The number of enemies allowed to be alive.
		public BoxCollider Trigger;


        void Start ()
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            InvokeRepeating ("Spawn", spawnTime, spawnTime);
        }

		/*void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Ice")
			{
				InvokeRepeating ("Spawn", spawnTime, spawnTime);
				Debug.Log("You fell into my trap card");
			}
		}*/

        void Spawn ()
        {
            // If the player has no health left...
            if(!HealthManager.instance.allPlayersAlive || HealthManager.instance.enemiesOnScreen.Length >= enemiesAllowed)
            {
                // ... exit the function.
                return;
            }

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
}