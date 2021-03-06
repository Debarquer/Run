﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private float timer = 0;
    FMODUnity.StudioEventEmitter musicEmitter;
    [System.NonSerialized]public bool stopTimer = false;
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
    public GameObject menuPanel;
    public GameObject optionsPanel;
    public Image fullScreenCheckmark;
    public Image muteAudioCheckmark;

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
        if (instance == null) {
            instance = this;
        }

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        if (!PlayerPrefs.HasKey("firstTime")) {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("fullscreen", Screen.fullScreen ? 1 : 0);
            PlayerPrefs.SetInt("muteAudio", 0);
            PlayerPrefs.SetInt("gameMode", 0);
            PlayerPrefs.SetInt("firstTime", 1);
        }

        Screen.fullScreen = PlayerPrefs.GetInt("fullscreen") == 1 ? true : false;
        FMODUnity.RuntimeManager.MuteAllEvents(PlayerPrefs.GetInt("muteAudio") == 1 ? true : false);
        mode = PlayerPrefs.GetInt("gameMode") == 1 ? GameMode.Timed : GameMode.Story;
        // Finding GameController with music emitter
        GameObject GameobjectTarget = GameObject.Find("GameController");
        musicEmitter = GameobjectTarget.GetComponent<FMODUnity.StudioEventEmitter>();
        //GetGameProgress();
    }
  
    void Update () {

        if(mode == GameMode.Timed)
        {
            if (!stopTimer)
            {
                Timer += Time.deltaTime;
                if (OnTimerIncreased != null)
                {
                    OnTimerIncreased(Timer);
                }
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

            menuPanel.SetActive(true);
            optionsPanel.SetActive(false);
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

    public void OnOptions() {
        menuPanel.SetActive(false);
        optionsPanel.SetActive(true);
        UpdateCheckmarkColor(fullScreenCheckmark, PlayerPrefs.GetInt("fullscreen"));
        UpdateCheckmarkColor(muteAudioCheckmark, PlayerPrefs.GetInt("muteAudio"));
    }

    public void OnMainMenu() {
        ToggleMenu();
        state = GameState.Menu;
        menu.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
        musicEmitter.SetParameter("AmbientMode", 1);
    }

    public void OnExit() {
        Application.Quit();
    }

    public void OnFullscreen() {
        int value = PlayerPrefs.GetInt("fullscreen") == 1 ? 0 : 1;
        PlayerPrefs.SetInt("fullscreen", value);
        UpdateCheckmarkColor(fullScreenCheckmark, value);
        Screen.fullScreen = value == 1 ? true : false;
    }

    public void OnMuteaudio() {
        int value = PlayerPrefs.GetInt("muteAudio") == 1 ? 0 : 1;
        PlayerPrefs.SetInt("muteAudio", value);
        UpdateCheckmarkColor(muteAudioCheckmark, value);
        FMODUnity.RuntimeManager.MuteAllEvents(value == 1 ? true : false);
    }

    public void OnBack() {
        optionsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void CompleteLevel(string scene)
    {
        Debug.Log("Time to completion: " + Timer);
        PlayerPrefs.SetInt(scene, 1);
        stopTimer = true;
        //FindObjectOfType<HighscoreController>().RecordHighscore(scene, Timer);
        Invoke("EnableScoreSubmitContainer", 2f);
    }

    public void EnableScoreSubmitContainer()
    {
        scoreSubmitContainer.SetActive(true);
    }

    public void UpdateCheckmarkColor(Image checkmark, int value) {
        if (value == 1)
            checkmark.color = Color.green;
        if (value == 0)
            checkmark.color = Color.black;
    }
}
