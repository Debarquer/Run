using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAsync : MonoBehaviour {

    public DoorwayCloser doorwayCloser;
    public string sceneName;

	// Use this for initialization
	void Start () {
        doorwayCloser.OnDoorClosed += LoadNextLevel;
	}
	
	public void LoadNextLevel()
    {
        Vector3 roomStartPos = transform.parent.position;
        Camera.main.transform.position = Camera.main.transform.position - roomStartPos;
        FindObjectOfType<Player>().transform.position = FindObjectOfType<Player>().transform.position - roomStartPos;
        this.transform.parent.position -= roomStartPos;

        StartCoroutine(StartLoading());
    }

    IEnumerator StartLoading()
    {
        AsyncOperation asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("RedLevel", LoadSceneMode.Additive);
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
