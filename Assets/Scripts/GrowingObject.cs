using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingObject : MonoBehaviour {

    public bool smooth = true;

    public float endScaleX = 1f;
    public float endScaleY = 1f;
    public float endScaleZ = 1f;

    public float growthTimeMax = 1f;
    float growthTimeCurr = 0;

    Vector3 startPos;
    Vector3 intervallScale;

    public bool hasPaused = false;
    public float pauseTimerMax = 2f;
    float pauseTimerCurr = 0;

    public float growthSizeIntervall = 1;

    public bool isTriggered = false;
    public PressurePlateScript pressurePlateScript;

	// Use this for initialization
	void Start () {
        intervallScale = transform.localScale;
        startPos = transform.position - new Vector3((transform.localScale.x-1)/2,(transform.localScale.y-1)/2, (transform.localScale.z-1)/2);

        if (pressurePlateScript != null)
        {
            pressurePlateScript.OnEnter += Activate;
            isTriggered = false;
        }
        else
        {
            isTriggered = true;
        }
    }

    // Update is called once per frame
    void Update () {
        if (!hasPaused)
        {
            pauseTimerCurr += Time.deltaTime;
            if(pauseTimerCurr > pauseTimerMax)
            {
                pauseTimerCurr = 0;
                hasPaused = true;
            }
            else
            {
                return;
            }
        }

        if (isTriggered)
        {
            if (transform.localScale.x < endScaleX ||
            transform.localScale.y < endScaleY ||
            transform.localScale.z < endScaleZ)
                notACoRoutine();
        }
    }

    private void Activate()
    {
        isTriggered = true;
    }

    public void notACoRoutine()
    {
        growthTimeCurr += Time.deltaTime;
        if (growthTimeCurr > growthTimeMax)
        {
            growthTimeCurr = 0;
            hasPaused = false;
            intervallScale = transform.localScale;
        }

        float newScaleX = intervallScale.x;
        float newScaleY = intervallScale.y;
        float newScaleZ = intervallScale.z;

        if(transform.localScale.x < endScaleX)
            newScaleX = Mathf.Lerp(intervallScale.x, intervallScale.x + growthSizeIntervall, growthTimeCurr / growthTimeMax);
        if (transform.localScale.y < endScaleY)
            newScaleY = Mathf.Lerp(intervallScale.y, intervallScale.x + growthSizeIntervall, growthTimeCurr / growthTimeMax);
        if(transform.localScale.z < endScaleZ)
            newScaleZ = Mathf.Lerp(intervallScale.z, intervallScale.x + growthSizeIntervall, growthTimeCurr / growthTimeMax);

        transform.localScale = new Vector3(newScaleX, newScaleY, newScaleZ);
        transform.position = startPos + new Vector3((newScaleX - 1) / 2, (newScaleY - 1) / 2, (newScaleZ - 1) / 2);
    }
}
