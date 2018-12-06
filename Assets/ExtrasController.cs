using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrasController : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject Extras;
public void Back()
    {
        MainMenu.SetActive(true);
        Extras.SetActive(false);
    }
}
