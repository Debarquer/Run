using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour {

    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();

        FindObjectOfType<GameController>().OnTimerIncreased += OnTimerIncreased;
	}
	
	public void OnTimerIncreased(float timer)
    {
        text.text = string.Format("Timer: {000:0.00}", timer);
    }
}
