using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheese : MonoBehaviour
{
    public GameObject SpawnI;

    public GameObject SpawnF;

    public GameObject SpawnE;

    public GameObject Ice;

    public GameObject Fire;

    public GameObject Air;

    public float wait;


	// Use this for initialization
	void Start ()
	{
	    wait = 3f;
        Ice = GameObject.FindGameObjectWithTag("Ice");
	    Fire = GameObject.FindGameObjectWithTag("Fire");
        Air = GameObject.FindGameObjectWithTag("Earth");
        Invoke("ParentI", wait);
        Invoke("ParentF", wait);
        Invoke("ParentE", wait);
	}

	// Update is called once per frame
	void ParentI ()
	{
	    SpawnI.transform.parent = Ice.transform;
	}
    void ParentF()
    {
        SpawnF.transform.parent = Fire.transform;
    }
    void ParentE()
    {
        SpawnE.transform.parent = Air.transform;
    }
}
