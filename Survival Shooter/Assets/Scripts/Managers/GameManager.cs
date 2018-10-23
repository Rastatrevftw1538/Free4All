
using UnityEngine;

namespace CompleteProject
{
	public class GameManager :MonoBehaviour
    {
        public static GameManager instance;
        public int Health;
        public PlayerHealth Ph;
        public GameObject[] players;
        private GameObject currentplayers;
        public GameObject Ice;
        public GameObject Fire;
        public GameObject Air;
        public Transform[] spawnPoints;
        public Camera BadCamera;
		public string currentScene;

        public bool runningMac = false;
        public bool runningWindows = false;




        public static GameManager Instance()
        {
            return instance;
        }


        void Awake()
        {

			BadCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            //Check if instance already exists
            if (instance == null)

                //if not, set instance to this
                instance = this;

            //If instance already exists and it's not this:
            else if (instance != this)

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);


            

            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            var iceGuy = Instantiate(Ice, spawnPoints[2].position, spawnPoints[2].rotation);
            var fireGuy = Instantiate(Fire, spawnPoints[2].position, spawnPoints[2].rotation);
            var airGuy = Instantiate(Air, spawnPoints[2].position, spawnPoints[2].rotation);

            players = new GameObject[3];
            players[0] = iceGuy;
            players[1] = fireGuy;
            players[2] = airGuy;

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                runningWindows = true;
            }

            if (Application.platform == RuntimePlatform.OSXEditor)
            {
				runningMac = true;
            }
        }
		void Update () { 
			BadCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

		}
    }
}
