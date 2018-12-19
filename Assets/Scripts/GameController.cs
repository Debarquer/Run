using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public enum GameState {
        Menu,
        Game
    }

    Dictionary<Scene, bool> gameProgress;
    List<Scene> scenes;

    public static GameController instance = null;

    public Canvas menu;

    GameState state = GameState.Game;

    void Awake() {
        if (instance == null) {
            instance = this;
        }

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        //GetGameProgress();
    }

    void Update () {
        if (state == GameState.Menu) {
            Cursor.visible = true;
        }
        if (state == GameState.Game) {
            Cursor.visible = false;
        }
        if (Input.GetKeyUp(KeyCode.Escape)) {
            if (SceneManager.GetActiveScene().buildIndex == 0)
                OnExit();

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
            Time.timeScale = 0f;
        
        else
            Time.timeScale = 1f;

        switch (state) {
            case GameState.Menu:
                state = GameState.Game;
                break;
            case GameState.Game:
                state = GameState.Menu;
                break;
            default:
                Debug.LogError("ToggleMenu State Switch has somehow found a new state.");
                break;
        }
    }

    public void OnResume() {
        ToggleMenu();
    }

    public void OnMainMenu() {
        state = GameState.Menu;
        SceneManager.LoadScene(0);
    }

    public void OnExit() {
        Application.Quit();
    }
}
