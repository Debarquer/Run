using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAsync : MonoBehaviour {

    public DoorwayCloser doorwayCloser;
    public string sceneName;

    // Use this for initialization
    private void OnEnable()
    {
        doorwayCloser.OnDoorClosed += LoadNextLevel;
    }

    public void LoadNextLevel()
    {
        Debug.Log("Loading level " + sceneName);
        
        Vector3 roomStartPos = transform.parent.position;
        Camera.main.transform.position = Camera.main.transform.position - roomStartPos;
        FindObjectOfType<Player>().transform.position = FindObjectOfType<Player>().transform.position - roomStartPos;
        this.transform.parent.position -= roomStartPos;

        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        //StartCoroutine(StartLoading());
    }

    IEnumerator StartLoading()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            Debug.Log("Loading progress: " + (asyncOperation.progress * 100) + "%");

            if (asyncOperation.progress >= 0.9f)
            {
                SceneManager.MoveGameObjectToScene(FindObjectOfType<Player>().gameObject, SceneManager.GetSceneByName(sceneName));
                SceneManager.MoveGameObjectToScene(Camera.main.gameObject, SceneManager.GetSceneByName(sceneName));
                asyncOperation.allowSceneActivation = true;
                transform.parent.gameObject.SetActive(false);
            }

            yield return null;
        }
    }
}
