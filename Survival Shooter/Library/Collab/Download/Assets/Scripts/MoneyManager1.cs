using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
	public class MoneyManager1 : MonoBehaviour
	{
		public static int money1;
		[SerializeField]

		Text text;                      // Reference to the Text component.


		void Start ()
		{
			// Set up the reference.
			text = GetComponent <Text> ();

            // Reset the score.
		    if (GameManager.instance.currentScene == "Room 1")
		    {

		        PlayerPrefs.GetInt("money1");
            }
        }


		void Update ()
		{
			// Set the displayed text to be the word "Score" followed by the score value.
			text.text = "Money: " + money1;
		}
	}
}