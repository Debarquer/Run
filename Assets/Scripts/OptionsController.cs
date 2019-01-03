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

    public GameObject firstSelectedMain;

    private void Start()
    {
        main = Camera.main.gameObject.GetComponent<MoveCamera>();
        UpdateCheckmarkColor(fullScreenCheckmark, PlayerPrefs.GetInt("fullscreen"));
        UpdateCheckmarkColor(muteAudioCheckmark, PlayerPrefs.GetInt("muteAudio"));
    }
    public void ToggleFullscreen()
    {
        int value = PlayerPrefs.GetInt("fullscreen") == 1 ? 0 : 1;
        PlayerPrefs.SetInt("fullscreen",  value);
        UpdateCheckmarkColor(fullScreenCheckmark, value);
        Screen.fullScreen = value == 1 ? true : false;

    }
    public void ToggleAudio()
    {
        int value = PlayerPrefs.GetInt("muteAudio") == 1 ? 0 : 1;
        PlayerPrefs.SetInt("muteAudio", value);
        UpdateCheckmarkColor(muteAudioCheckmark, value);
        FMODUnity.RuntimeManager.MuteAllEvents(value == 1 ? true : false);
    }
    public void ToggleMode()
    {

    }
    public void Back()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().firstSelectedGameObject = firstSelectedMain;
        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(firstSelectedMain);
        main.MoveToMainMenu();
    }

    public void UpdateCheckmarkColor(Image checkmark, int value) {
        if (value == 1)
            checkmark.color = Color.green;
        if (value == 0)
            checkmark.color = Color.black;
    }
}
