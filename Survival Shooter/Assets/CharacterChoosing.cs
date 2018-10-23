using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChoosing : MonoBehaviour{
	public GameObject BasePlayer;
	public Transform Here;
	public GameObject PowerPlayer;
	public GameObject Box;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			Destroy (other.gameObject);
			Instantiate (PowerPlayer, Here).transform.parent = null;
			Destroy (gameObject);
			}
		}
	}
