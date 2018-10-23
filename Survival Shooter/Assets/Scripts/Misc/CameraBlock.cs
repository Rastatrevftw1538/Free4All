using System.Collections;
using System.Collections.Generic;
using CompleteProject;
using UnityEngine;

public class CameraBlock : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    var Camera = GameManager.instance.BadCamera;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ice" || col.gameObject.tag == "Fire" || col.gameObject.tag == "Earth")
        {
            
        }
    }
}
