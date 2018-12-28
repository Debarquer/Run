using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionsController : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public Image fullScreenCheckmark;
    public Image muteAudioCheckmark;
    public Image speedModeCheckmark;

    MoveCamera main;
    private void Start()
    {
        main = Camera.main.gameObject.GetComponent<MoveCamera>();
        //ToggleCheckmarkColor(fullScreenCheckmark, PlayerPrefs.GetInt("fullscreen")); 
        ToggleCheckmarkColor(fullScreenCheckmark, 1);
    }
    public void ToggleFullscreen()
    {
        ToggleCheckmarkColor(fullScreenCheckmark, 0);
    }
    public void Button2()
    {

    }
    public void Button3()
    {

    }
    public void Back()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        main.MoveToMainMenu();
        
    }

    public void ToggleCheckmarkColor(Image checkmark, int value) {
        if (value == 1)
            checkmark.color = Color.green;
        if (value == 0)
            checkmark.color = Color.red;
    }
}
