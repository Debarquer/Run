using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DebugView : MonoBehaviour {

    public static DebugView instance = null;

    public Text debugText;
    public GameObject debugView;
    public string output = "";
    public string stack = "";

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
        if (Input.GetKeyUp("f")) { 
            debugView.SetActive(!debugView.activeInHierarchy);
        }
    }

    void HandleLog(string logString, string stackTrace, LogType type) {
        output = logString;
        stack = stackTrace;
        debugText.text += "[" + type + "] [" + System.DateTime.Now.ToString("hh:mm:ss.ff") + "] " + output + "\n";
    }
}
