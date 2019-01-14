using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour {

    public string LevelName;

    GameController gc;

    public ParticleSystem fireworks;

    private void Start()
    {
        gc = FindObjectOfType<GameController>();

        fireworks.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        fireworks.Play();

        if (gc.mode == GameController.GameMode.Timed)
        {
            FindObjectOfType<GameController>().CompleteLevel(LevelName);
        }
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Exit Scene", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
