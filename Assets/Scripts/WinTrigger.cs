using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour {

    public string LevelName;

    GameController gc;

    private void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(gc.mode == GameController.GameMode.Timed)
        {
            FindObjectOfType<GameController>().CompleteLevel(LevelName);
        }
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Exit Scene", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
