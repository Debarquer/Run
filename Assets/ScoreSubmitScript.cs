using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSubmitScript : MonoBehaviour {


    
	// Use this for initialization
	void Start () {
        Cursor.visible = true;
    }

    public void SubmitScore()
    {
        Cursor.visible = false;

        FindObjectOfType<HighscoreController>().RecordHighscore("", FindObjectOfType<GameController>().Timer);

        gameObject.SetActive(false);
    }
}
