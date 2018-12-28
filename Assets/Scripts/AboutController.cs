using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutController : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject About;
    MoveCamera main;

    public GameObject firstSelectedMain;

    private void Start()
    {
        main = Camera.main.gameObject.GetComponent<MoveCamera>();
    }

    public void Back()
    {
        MainMenu.SetActive(true);
        About.SetActive(false);
        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().firstSelectedGameObject = firstSelectedMain;
        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(firstSelectedMain);
        main.MoveToMainMenu();
    }
}
