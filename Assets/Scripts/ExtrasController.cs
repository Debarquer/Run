using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrasController : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject Extras;
    MoveCamera main;

    public GameObject firstSelectedMain;

    private void Start()
    {
        main = Camera.main.gameObject.GetComponent<MoveCamera>();
    }

    private void Update()
    {
        if (Input.GetButtonUp("Fire2"))
        {
            Back();
        }
    }
    public void Back()
    {
        MainMenu.SetActive(true);
        Extras.SetActive(false);
        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().firstSelectedGameObject = firstSelectedMain;
        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(firstSelectedMain);
        main.MoveToMainMenu();
    }
}
