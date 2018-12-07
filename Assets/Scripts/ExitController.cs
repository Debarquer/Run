using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject ExitMenu;

    public void Yes()
    {
        Application.Quit();
    }
    public void No()
    {
        MainMenu.SetActive(true);
        ExitMenu.SetActive(false);
    }
}
