using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DebugView : MonoBehaviour {

    public Text debugText;
    public string output = "";
    public string stack = "";

    void OnEnable() {
        debugText.text = "";
        Application.logMessageReceived += HandleLog;

        DontDestroyOnLoad(gameObject);
    }

    void OnDisable() {
        Application.logMessageReceived -= HandleLog;
    }

    void Update() {
        if (Input.GetKeyUp("f"))
            debugText.enabled = !debugText.enabled;
    }

    void HandleLog(string logString, string stackTrace, LogType type) {
        output = logString;
        stack = stackTrace;
        debugText.text += "[" + type + "] [" + System.DateTime.Now.ToString("hh:mm:ss.ff") + "] " + output + "\n";
    }
}
