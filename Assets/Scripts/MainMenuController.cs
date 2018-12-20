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
    private void Start()
    {
        //ExtrasMenu.SetActive(false);
        //OptionsMenu.SetActive(false);
        //AboutMenu.SetActive(false);
        //ExitMenu.SetActive(false);
        main = Camera.main.gameObject.GetComponent<MoveCamera>();
        gameController = GameObject.Find("GameController");
        gameController.SetActive(false);
    }

    public void Play()
    {
        MainMenu.SetActive(false);
        gameController.SetActive(true);
        Debug.Log("Play");
        SceneManager.LoadScene("LevelSelect");
    }
    public void Options()
    {
        MainMenu.SetActive (false);
        OptionsMenu.SetActive(true);
        main.MoveToOptions();

        Debug.Log("Options");
    }
    public void Extras()
    {
        MainMenu.SetActive(false);
        ExtrasMenu.SetActive(true);
        main.MoveToExtras();
        Debug.Log("Extras");
    }
    public void About()
    {
        MainMenu.SetActive(false);
        AboutMenu.SetActive(true);
        main.MoveToAbout();
        Debug.Log("About");
    }
    public void Exit()
    {
        MainMenu.SetActive(false);
        ExitMenu.SetActive(true);
        Debug.Log("Exit");
    }
    //public void Back()
    //{
    //    MainMenu.SetActive(true);
    //    main.MoveToMainMenu();

    //}


}
