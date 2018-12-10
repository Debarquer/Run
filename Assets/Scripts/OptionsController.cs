using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OptionsController : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    MoveCamera main;
    private void Start()
    {
        main = Camera.main.gameObject.GetComponent<MoveCamera>();
    }
    public void Button1()
    {

    }
    public void Button2()
    {

    }
    public void Button3()
    {

    }
    public void Button4()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        main.MoveToMainMenu();
        
    }
}
