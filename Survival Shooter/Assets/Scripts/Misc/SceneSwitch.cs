using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CompleteProject
{
    public class SceneSwitch : MonoBehaviour
    {
        public PlayerHealth Ph;
        private GameObject[] players;
        Scene currentScene;
        string sceneName;
        public bool canSwitch;
        public string sceneToSwitchTo;

        void Awake()
        {
            players = new GameObject[3];
            players[0] = GameObject.FindGameObjectWithTag("Ice");
            players[1] = GameObject.FindGameObjectWithTag("Fire");
            players[2] = GameObject.FindGameObjectWithTag("Earth");
            Scene currentScene = SceneManager.GetActiveScene();
            sceneName = currentScene.name;
            canSwitch = true;
        }

        public void CheckSceneSwitch()
        {
            foreach (GameObject player in players)
            {
                if (player.GetComponent<PlayerHealth>().isDead)
                {
                    continue;
                }
                else if (!player.GetComponent<PlayerHealth>().isOnExit)
                {
                    canSwitch = false;
                }
            }

            if (canSwitch == true)
            {

                SceneManager.LoadScene(sceneToSwitchTo);

            }
        }

        private void Update()
        {
            foreach(var player in players)
            {
                //distnace check to each player

                //find the exit dude - campfire
                var campfire = GameObject.FindGameObjectWithTag("Exit");

                var posCampfire = campfire.gameObject.transform.position;

                var posPlayer = player.gameObject.transform.position;

                var dist = (posCampfire.x - posPlayer.x) * (posCampfire.x - posPlayer.x) + (posCampfire.y - posPlayer.y) * (posCampfire.y - posPlayer.y);

                float ExitDistSq = 3 * 3;
                
               // Debug.Log(dist);

                var canExit = dist > ExitDistSq;

            }
        }
    }
}