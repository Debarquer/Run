using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour {

    public string LevelName;

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameController>().CompleteLevel(LevelName);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Exit Scene", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
