using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

    public string nextScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
        else
        {
            Destroy(other.gameObject);
            Debug.Log("This isn't a player");
        }
    }
}
