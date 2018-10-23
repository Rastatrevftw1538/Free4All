using System.Collections;
using System.Collections.Generic;
using CompleteProject;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeColl : MonoBehaviour
{
    public string sceneToLoad;

    public int alivePlayers = 3;
    public int playersInColl = 0;
    public GameObject SceneSwitch;

    public bool canEnterF = true;
    public bool canEnterI = true;
    public bool canEnterE = true;
    public static int score;
    public CameraControl Camera;
    public bool I = true;
    public bool F = true;
    public bool E = true;

    void Start()
    {
        SceneSwitch.SetActive(true);
    }

    void Update()
    {
        if (score >= 500)
        {
            SceneSwitch.SetActive(true);
        }
        if (Camera.IDied == true && I == true)
        {
            alivePlayers -= 1;
            Camera.IDied = false;
            I = false;
        }
        if (Camera.FDied == true && F == true)
        {
            alivePlayers -= 1;
            Camera.FDied = false;
            F = false;
        }
        if (Camera.EDied == true && E == true)
        {
            alivePlayers -= 1;
            Camera.EDied = false;
            E = false;
        }
    }
    void OnTriggerEnter(Collider trig)
    {
        if (trig.tag == "Fire" && canEnterF)
        {
            canEnterF = false;
            playersInColl += 1;
           
            CheckChange();
        }
        if (trig.tag == "Ice" && canEnterI)
        {
            canEnterI = false;
            playersInColl += 1;

            CheckChange();
        }
        if (trig.tag == "Earth" && canEnterE)
        {
            canEnterE = false;
            playersInColl += 1;

            CheckChange();
        }
    }

    void OnTriggerExit(Collider trig)
    {
        if (trig.tag == "Fire" && canEnterF == false)
        {
            canEnterF = true;
            playersInColl -= 1;
            CheckChange();
        }
        if (trig.tag == "Ice" && canEnterI == false)
        {
            canEnterI = true;
            playersInColl -= 1;

            CheckChange();
        }
        if (trig.tag == "Earth" && canEnterE == false)
        {
            canEnterE = true;
            playersInColl -= 1;

            CheckChange();
        }
    }

    void CheckChange()
    {
        if (playersInColl == alivePlayers)
        {
            SceneManager.LoadScene(sceneToLoad);
        }

    }
}
