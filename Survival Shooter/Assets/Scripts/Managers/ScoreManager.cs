using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class ScoreManager : MonoBehaviour
    {
		public static int score;
        public static ScoreManager instance;
        [SerializeField]

        Text text;                      // Reference to the Text component.

        public static ScoreManager Instance()
        {
            return instance;
        }

        void Start ()
        {
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

            // Set up the reference.
            text = GetComponent <Text>();

            // Reset the score.
            if (GameManager.instance.currentScene == "Room 1")
            {
                PlayerPrefs.DeleteAll();
            }

            PlayerPrefs.GetInt("Score");
            

        }


        void Update ()
        {
            // Set the displayed text to be the word "Score" followed by the score value.
            text.text = "Score: " + score;
            //Debug.Log(score);
        }

        
    }
}