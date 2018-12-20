using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitHighscoreScript : MonoBehaviour {

    Text scoreText;
    InputField nameField;

	// Use this for initialization
	void Start () {
        Cursor.visible = true;
    }

    public void Highscore()
    {
        Cursor.visible = false;

        string currentLevel = FindObjectOfType<GameController>().CurrentLevel;
        FindObjectOfType<HighscoreController>
    }
}
