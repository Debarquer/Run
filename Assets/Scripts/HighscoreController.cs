using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

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
        string text = "";
        try
        {
            text = File.ReadAllText(levelName + ".txt");
            Debug.Log(text);
        }
        catch (ArgumentNullException e)
        {
            Debug.LogWarning(e.Message + ": " + levelName + ".txt does not exist");
        }
        catch (ArgumentException e)
        {
            Debug.LogWarning(e.Message + ": " + levelName + ".txt is empty or corrupt");
        }
        catch(Exception e)
        {
            Debug.LogWarning(e.Message + ": " + levelName + ".txt is empty or corrupt");
        }

        text += "\n" + playerName + string.Format(",{000:0.00}", time);

        try
        {
            File.WriteAllText(levelName + ".txt", text);
        }
        catch(Exception e){
            Debug.Log(e.Message + ": " + levelName + " does not exist");
            File.Create(levelName + ".txt");
            File.WriteAllText(levelName + ".txt", text);
        }
        
        //SceneManager.LoadScene("LevelSelect");
    }
}
