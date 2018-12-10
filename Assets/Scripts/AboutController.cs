using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutController : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject About;
    MoveCamera main;
    private void Start()
    {
        main = Camera.main.gameObject.GetComponent<MoveCamera>();
    }

    public void Back()
    {
        MainMenu.SetActive(true);
        About.SetActive(false);
        main.MoveToMainMenu();
    }
}
