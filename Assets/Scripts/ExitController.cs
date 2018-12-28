using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject ExitMenu;

    public GameObject firstSelectedMain;

    public void Yes()
    {
        Application.Quit();
    }
    public void No()
    {
        MainMenu.SetActive(true);
        ExitMenu.SetActive(false);
        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().firstSelectedGameObject = firstSelectedMain;
        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(firstSelectedMain);
    }
}
