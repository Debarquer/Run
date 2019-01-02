using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private float timer = 0;
    public delegate void TimerIncreasedDelegate(float timer);
    public event TimerIncreasedDelegate OnTimerIncreased;

    public GameObject scoreSubmitContainer;

    public GameObject firstSelected;
    public UnityEngine.EventSystems.EventSystem eventsystem;

    string currentLevel;

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

    public GameState state = GameState.Game;
    public GameMode mode = GameMode.Timed;

    public string CurrentLevel
    {
        get
        {
            return currentLevel;
        }

        set
        {
            currentLevel = value;
        }
    }

    public float Timer
    {
        get
        {
            return timer;
        }

        set
        {
            timer = value;
        }
    }

    void Awake() {

        //For debug purposes only
        //PlayerPrefs.DeleteAll();

        if (!PlayerPrefs.HasKey("firstTime")) {
            PlayerPrefs.SetInt("fullscreen", Screen.fullScreen ? 1 : 0);
            PlayerPrefs.SetInt("firstTime", 1);
        }

        Screen.fullScreen = PlayerPrefs.GetInt("fullscreen") == 1 ? true : false;
        

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
            Timer += Time.deltaTime;
            if (OnTimerIncreased != null)
            {
                OnTimerIncreased(Timer);
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
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetButtonUp("GamepadStart")) {
            if (SceneManager.GetActiveScene().buildIndex == 0)
                OnExit();
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            ToggleMenu();
        }
        if (Input.GetButtonUp("Fire2"))
        {
            if (menu.gameObject.activeInHierarchy)
            {
                ToggleMenu();
            }
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

            eventsystem.firstSelectedGameObject = firstSelected;
            eventsystem.SetSelectedGameObject(firstSelected);
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
        Debug.Log("Time to completion: " + Timer);
        PlayerPrefs.SetInt(scene, 1);
        //FindObjectOfType<HighscoreController>().RecordHighscore(scene, Timer);
        scoreSubmitContainer.SetActive(true);
    }
}
