using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour {

    bool hasBeenTriggered = false;
    public bool MultiTrigger = false;
    public float triggerTimerMax = 1.0f;
    float triggerTimer = 0;

    public Material triggered;
    public Material unTriggered;
    GameObject plate;

    public delegate void PressurePlateEnterDelegate();
    public event PressurePlateEnterDelegate OnEnter;

    public delegate void PressurePlateExitDelegate();
    public event PressurePlateExitDelegate OnExit;

    private void Start()
    {
        int number = 0;
        number += 5;

        OnEnter += Test;
        OnEnter += Test2;
    }

    private void Update()
    {
        if (hasBeenTriggered && MultiTrigger)
        {
            triggerTimer += Time.deltaTime;
           // plate.GetComponent<Renderer>().material = triggered;
            if (triggerTimer > triggerTimerMax)
            {
                triggerTimer = 0;
                hasBeenTriggered = false;
                transform.parent.GetComponentInChildren<MeshRenderer>().material = unTriggered;
            }
        }
    }

    public void Test()
    {
        Debug.Log("testing");
    }

    public void Test2()
    {
        Debug.Log("testing2");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(hasBeenTriggered)
        {
            return;
        }
        else
        {
            hasBeenTriggered = true;

            Debug.Log("Help I am triggered");

            if (other.tag == "Player")
            {
                transform.parent.GetComponentInChildren<MeshRenderer>().material = triggered;

            }

            OnEnter();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }
    }
}
