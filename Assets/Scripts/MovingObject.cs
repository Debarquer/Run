using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

    public Transform PositionA;
    public Transform PositionB;
    public bool reverseDirection;

    public float moveTimerMaxA = 2f;
    public float moveTimerMaxB = 1f;
    public float moveTimer = 5f;
    public float moveCurr = 0f;

    public float stopTimer = 2f;
    public float stopCurr;

    public float speed = 0f;
    public bool PressurePlateActivateOption;
    public bool RepeatOption;
    public bool isActive = false;
    public PressurePlateScript pressureplateScript;




    // Use this for initialization
    void Start () {

        if (PressurePlateActivateOption)
        {
            pressureplateScript.OnEnter += Activate;
            isActive = false;
        }
        StartMoving();
        
	}

    private void Activate()
    {
        isActive = true;
    }

    void StartMoving()
    {
        speed = Vector3.Distance(PositionA.position, PositionB.position) / moveTimer;
        if (!reverseDirection)
        {
            transform.position = PositionB.transform.position;
        }
        else
        {
            transform.position = PositionA.transform.position;
        }

    }

    // Update is called once per frame

    void FixedUpdate () {
        if (!isActive)
        {
            return;
        }

        if (RepeatOption == true) { 
            moveCurr += Time.deltaTime;
            if (moveCurr > moveTimer)
            {
                stopCurr += Time.deltaTime;

                if (reverseDirection)
                {
                    transform.position = PositionB.position;
                }
                else
                {
                    transform.position = PositionA.position;
                }

                    if (stopCurr > stopTimer)
                {
                    stopCurr = 0;
                    moveCurr = 0;
                    if (reverseDirection)
                    {
                        moveTimer = moveTimerMaxA;
                        reverseDirection = false;
                    }
                    else
                    {
                        moveTimer = moveTimerMaxB;
                        reverseDirection = true;
                    }
                }
            }
            else
            {
                //calculate what speed is needed to traverse from a to b in the correct time
                if (!reverseDirection)
                {
                    float moveSpeed = Vector3.Distance(PositionA.position, PositionB.position) / moveTimerMaxA;

                    transform.Translate((PositionA.position - transform.position).normalized * Time.deltaTime * moveSpeed);

                    //transform.localPosition = Vector3.Lerp(PositionB.localPosition, PositionA.localPosition, (moveCurr % moveTimer) / moveTimer);
                }
                else
                {
                    float moveSpeed = Vector3.Distance(PositionA.position, PositionB.position) / moveTimerMaxB;

                    transform.Translate((PositionB.position - transform.position).normalized * Time.deltaTime * moveSpeed);

                    //transform.localPosition = Vector3.Lerp(PositionA.localPosition, PositionB.localPosition, (moveCurr % moveTimer) / moveTimer);
                }
            }
        }
        else
        {
            //calculate what speed is needed to traverse from a to b in the correct time
            if (!reverseDirection)
            {
                float moveSpeed = Vector3.Distance(PositionA.position, PositionB.position) / moveTimerMaxA;

                transform.Translate((PositionA.position - transform.position).normalized * Time.deltaTime * moveSpeed);

                //transform.localPosition = Vector3.Lerp(PositionB.localPosition, PositionA.localPosition, (moveCurr % moveTimer) / moveTimer);
            }
            else
            {
                float moveSpeed = Vector3.Distance(PositionA.position, PositionB.position) / moveTimerMaxB;

                transform.Translate((PositionB.position - transform.position).normalized * Time.deltaTime * moveSpeed);

                //transform.localPosition = Vector3.Lerp(PositionA.localPosition, PositionB.localPosition, (moveCurr % moveTimer) / moveTimer);
            }
        }        
    }
}
