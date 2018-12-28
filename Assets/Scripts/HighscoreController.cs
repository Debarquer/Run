using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighscoreController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //string text = "Highscores";
        //text += "\n\nRed level \n\nSimon -- 1s";
        //text += "\n\nGreen level \n\nSimon -- 1s";
        //text += "\n\nBlue level \n\nSimon -- 1s";
        //System.IO.File.WriteAllText(@"WriteText.txt", text);

        //Debug.Log(System.IO.File.ReadAllText(@"WriteText.txt"));
    }

    public void RecordHighscore(string levelName, string playerName, float time)
    {

        string text = System.IO.File.ReadAllText(levelName + ".txt");
        Debug.Log(text);

        text += "\n" + playerName + string.Format(" {000:0.00}", time); ;
        System.IO.File.WriteAllText(levelName + ".txt", text);
        
        //SceneManager.LoadScene("LevelSelect");
    }

    public void SortHighscore(string levelName)
    {

    }
}
