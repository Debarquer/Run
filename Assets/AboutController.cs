using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutController : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject About;

    public void Back()
    {
        MainMenu.SetActive(true);
        About.SetActive(false);
    }
}
