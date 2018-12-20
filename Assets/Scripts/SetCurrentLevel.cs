using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCurrentLevel : MonoBehaviour {
    public string levelName;

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameController>().CurrentLevel = levelName;
    }
}
