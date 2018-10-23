using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
	public class MoneyManager2 : MonoBehaviour
	{
		public static int money2;
		[SerializeField]

		Text text;                      // Reference to the Text component.


		void Start ()
		{
			// Set up the reference.
			text = GetComponent <Text> ();

            // Reset the score.

            PlayerPrefs.GetInt("money2");


        }


		void Update ()
		{
			// Set the displayed text to be the word "Score" followed by the score value.
			text.text = "Money: " + money2;
		}
	}
}