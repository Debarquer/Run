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
        if(text != null)
        {
            text.text = string.Format("Timer: {0:0.00}", timer);
        }
    }

    private void OnDestroy()
    {
        FindObjectOfType<GameController>().OnTimerIncreased -= OnTimerIncreased;
    }
}
