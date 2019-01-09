using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DebugView : MonoBehaviour {

    public static DebugView instance = null;

    public Text debugText;
    public GameObject debugView;
    public Text modeText;
    public Text legendText;
    public string output = "";
    public string stack = "";

    bool debugMode;
    bool value;

    void OnEnable() {
        if (instance == null) {
            instance = this;
        }

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        debugText.text = "";
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable() {
        Application.logMessageReceived -= HandleLog;
    }

    void Update() {
        // TODO: Only allow activating Debug Mode if "DebugAllowed" is checked in Inspector
        if (Input.GetKeyUp(KeyCode.F1)) {
            Debug.Log("F1 pressed");
            debugMode = !debugMode;
            modeText.enabled = debugMode;
            if (!debugMode) {
                legendText.enabled = false;
                debugView.SetActive(false);
            }
        }

        if (debugMode) {
            CheckDebugKeys();
        }
    }

    void CheckDebugKeys() {
        if (Input.GetKeyUp(KeyCode.R)) { 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyUp(KeyCode.G)) {
            GameObject.Find("Enemy").SetActive(!GameObject.Find("Enemy").activeInHierarchy);
        }
        if (Input.GetKeyUp(KeyCode.M)) {
            value = !value;
            FMODUnity.RuntimeManager.MuteAllEvents(value);
        }
        if (Input.GetKeyUp(KeyCode.F)) {
            debugView.SetActive(!debugView.activeInHierarchy);
        }
        if (Input.GetKeyUp(KeyCode.H)) {
            legendText.enabled = !legendText.enabled;
        }

    }

    void HandleLog(string logString, string stackTrace, LogType type) {
        output = logString;
        stack = stackTrace;
        debugText.text += "[" + type + "] [" + System.DateTime.Now.ToString("hh:mm:ss.ff") + "] " + output + "\n";
    }
}
