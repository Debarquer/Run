using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitHighscoreScript : MonoBehaviour {

    public Text scoreText;
    public InputField nameField;

    GameController gc;

	// Use this for initialization
	void Start () {
        gc = FindObjectOfType<GameController>();
        gc.state = GameController.GameState.Menu;
        //gc.mode = GameController.GameMode.Story;

        scoreText.text = "Your time: " + string.Format("{000:0.00}", gc.Timer); ;
    }

    public void SubmitHighscore()
    {
        highscoreUI.LoadLevelTexts();

        gc.state = GameController.GameState.Game;

        string currentLevel = gc.CurrentLevel;
        float timer = gc.Timer;
        FindObjectOfType<HighscoreController>().RecordHighscore(currentLevel, nameField.text, timer);

        gameObject.SetActive(false);
    }
}
