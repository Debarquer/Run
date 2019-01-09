using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject ExtrasMenu;
    public GameObject AboutMenu;
    public GameObject ExitMenu;
    GameObject gameController;
    MoveCamera main;

    public GameObject optionsFirstSelected;
    public GameObject extrasFirstSelected;
    public GameObject aboutFirstSelected;
    public GameObject exitFirstSelected;

    public HighscoreUI highscoreUI;


    private void Start()
    {
        ExtrasMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        AboutMenu.SetActive(false);
        ExitMenu.SetActive(false);
        main = Camera.main.gameObject.GetComponent<MoveCamera>();
        gameController = GameObject.Find("GameController");
        gameController.SetActive(false);
    }

    public void Play()
    {
        MainMenu.SetActive(false);
        gameController.SetActive(true);
        gameController.GetComponent<GameController>().state = GameController.GameState.Game;
        Debug.Log("Play");
        SceneManager.LoadScene("LevelSelect");
    }
    public void Options()
    {
        MainMenu.SetActive (false);
        OptionsMenu.SetActive(true);
        main.MoveToOptions();

        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().firstSelectedGameObject = optionsFirstSelected;
        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(optionsFirstSelected);

        Debug.Log("Options");
    }
    public void Extras()
    {
        MainMenu.SetActive(false);
        Invoke("InvokeSetActive", 0.55f);
        main.MoveToExtras();
        highscoreUI.LoadLevelTexts();

        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().firstSelectedGameObject = extrasFirstSelected;
        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(extrasFirstSelected);

        Debug.Log("Extras");
    }
    public void About()
    {
        MainMenu.SetActive(false);
        AboutMenu.SetActive(true);
        main.MoveToAbout();

        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().firstSelectedGameObject = aboutFirstSelected;
        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(aboutFirstSelected);

        Debug.Log("About");
    }
    public void Exit()
    {
        MainMenu.SetActive(false);
        ExitMenu.SetActive(true);

        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().firstSelectedGameObject = exitFirstSelected;
        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(exitFirstSelected);

        Debug.Log("Exit");
    }

    void InvokeSetActive()
    {
        ExtrasMenu.SetActive(true);
    }
    //public void Back()
    //{
    //    MainMenu.SetActive(true);
    //    main.MoveToMainMenu();

    //}


}
