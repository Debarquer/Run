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
    private void Start()
    {
        ExtrasMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        AboutMenu.SetActive(false);
        ExitMenu.SetActive(false);
    }

    public void Play()
    {
        MainMenu.SetActive(false);
        Debug.Log("Play");
        SceneManager.LoadScene("Main");
        
    }
    public void Options()
    {
        MainMenu.SetActive (false);
        OptionsMenu.SetActive(true);

        Debug.Log("Options");
    }
    public void Extras()
    {
        MainMenu.SetActive(false);
        ExtrasMenu.SetActive(true);
        Debug.Log("Extras");
    }
    public void About()
    {
        MainMenu.SetActive(false);
        AboutMenu.SetActive(true);
        Debug.Log("About");
    }
    public void Exit()
    {
        MainMenu.SetActive(false);
        ExitMenu.SetActive(true);
        Debug.Log("Exit");
    }


}
