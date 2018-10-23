using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CompleteProject
{
public class Treasure : MonoBehaviour {
	
	public GameObject Loot;

	int Money = 25;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		public void Die()
		{
			Destroy (Loot);
		}
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Ice") {
				Destroy (Loot);
				MoneyManager1.money1 += Money;
				Debug.Log ("gettin money1");
			}
			if (other.gameObject.tag == "Fire") {
				Destroy (Loot);
				MoneyManager2.money2 += Money;
				Debug.Log ("gettin money2");
			}
			if (other.gameObject.tag == "Earth") {
				Destroy (Loot);
				MoneyManager3.money3 += Money;
				Debug.Log ("gettin money3");
			}
	}
}
}