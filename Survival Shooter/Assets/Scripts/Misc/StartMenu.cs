using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
	public Button butt;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return) || (Input.GetKeyDown(KeyCode.Joystick1Button9)) || (Input.GetKeyDown(KeyCode.Joystick2Button9)) || (Input.GetKeyDown(KeyCode.Joystick3Button9))){
					SceneManager.LoadScene ("Character selection");
			}
		if (Input.GetKeyDown ("Cancel")) {
			QuitGame ();
		}
			}
					public void StartSelection()
	{
		SceneManager.LoadScene("Character selection");
	}

	public void QuitGame()
	{
		Application.Quit();
		print("Game Quit");
	}
}
