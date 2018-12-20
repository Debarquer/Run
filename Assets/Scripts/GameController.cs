using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    float timer = 0;
    public delegate void TimerIncreasedDelegate(float timer);
    public event TimerIncreasedDelegate OnTimerIncreased;

    public enum GameState {
        Menu,
        Game
    }

    public enum GameMode
    {
        Story,
        Timed
    }

    Dictionary<Scene, bool> gameProgress;
    List<Scene> scenes;

    public static GameController instance = null;

    public Canvas menu;

    GameState state = GameState.Game;
    GameMode mode = GameMode.Timed;

    void Awake() {

        //For debug purposes only
        //PlayerPrefs.DeleteAll();

        if (instance == null) {
            instance = this;
        }

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        //GetGameProgress();
    }
  
    void Update () {

        if(mode == GameMode.Timed)
        {
            timer += Time.deltaTime;
            if (OnTimerIncreased != null)
            {
                OnTimerIncreased(timer);
            }
        }

        if (state == GameState.Menu)
        {
            Cursor.visible = true;
        }
        if (state == GameState.Game)
        {
            Cursor.visible = false;
        }
        if (Input.GetKeyUp(KeyCode.Escape)) {
            if (SceneManager.GetActiveScene().buildIndex == 0)
                OnExit();
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            ToggleMenu();
        }
    }

    void GetGameProgress() {
        scenes = new List<Scene>();
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++) {
            scenes.Add(SceneManager.GetSceneByBuildIndex(i));
            Debug.Log(scenes[i].name);
        }

        gameProgress = new Dictionary<Scene, bool>();

        foreach (Scene scene in scenes) {
            gameProgress.Add(scene, false);
        }

        foreach (KeyValuePair<Scene, bool> value in gameProgress) {
            Debug.Log(value);
        }
    }

    void ToggleMenu() {
        menu.gameObject.SetActive(!menu.gameObject.activeInHierarchy);
        if (menu.gameObject.activeInHierarchy)
        {
            state = GameState.Menu;
            Time.timeScale = 0f;
        }
        else{
            state = GameState.Game;
            Time.timeScale = 1f;
        }
    }

    public void OnResume() {
        ToggleMenu();
    }

    public void OnMainMenu() {
        ToggleMenu();
        state = GameState.Menu;
        menu.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void OnExit() {
        Application.Quit();
    }

    public void CompleteLevel(string scene)
    {
        Debug.Log("Time to completion: " + timer);
        PlayerPrefs.SetInt(scene, 1);
    }
}
