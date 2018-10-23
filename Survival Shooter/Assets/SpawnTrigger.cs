using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
public class SpawnTrigger : MonoBehaviour {

		EnemyManager Spawner;
		public BoxCollider Trigger;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Ice")
		{
				InvokeRepeating ("Spwan", 3, 3);
			Debug.Log("You activated my trap card");
		}
		if (other.gameObject.tag == "Fire")
		{
			InvokeRepeating ("Spawn", 3 , 3);
				Debug.Log("You activated my trap card");
		}
		if (other.gameObject.tag == "Air")
		{
			InvokeRepeating ("Spawn", 3, 3);
				Debug.Log("You activated my trap card");
		}
	}
	}
}
