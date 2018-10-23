using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class NextScene : MonoBehaviour {
	public string sceneToSwitchTo;


	// Use this for initialization
	void Start () {
		VideoPlayer vp = GetComponent<VideoPlayer>();
		vp.Play(); 
	}
	
	// Update is called once per frame
	void Update () {
		Invoke ("SceneChange", 6f);

	}
	void SceneChange (){
			
		SceneManager.LoadScene(sceneToSwitchTo);

	}
}