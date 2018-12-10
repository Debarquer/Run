using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrasController : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject Extras;
    MoveCamera main;
    private void Start()
    {
        main = Camera.main.gameObject.GetComponent<MoveCamera>();
    }
    public void Back()
    {
        MainMenu.SetActive(true);
        Extras.SetActive(false);
        main.MoveToMainMenu();
    }
}
