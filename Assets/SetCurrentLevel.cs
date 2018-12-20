using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCurrentLevel : MonoBehaviour {
    public string levelName;
    public GameObject scoreSubmitCanvas;

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameController>().CurrentLevel = levelName;
        FindObjectOfType<GameController>().scoreSubmitContainer = scoreSubmitCanvas;
        //FindObjectOfType<GameController>().scoreSubmitContainer.SetActive(false);
    }
}
