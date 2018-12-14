using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

    public Transform PositionA;
    public Transform PositionB;
    [Tooltip("Cannot be modified in the inspector.")]
    public bool reverseDirection;

    //public float moveTimerMaxA = 2f;
    //public float moveTimerMaxB = 1f;

    [Tooltip("Cannot be modified in the inspector.")]
    public float moveTimer = 5f;
    [Tooltip("Cannot be modified in the inspector.")]
    public float moveCurr = 0f;

    float stopTimer = 2f;
    float stopCurr;

    float speed = 0f;
    bool pressurePlateActivateOption;
    public bool RepeatOption;
    public bool isActive = false;
    public PressurePlateScript pressureplateScript;

    int currentPattern = 0;
    public MovingObjectPattern[] movingObjectPatterns;

    [System.Serializable]
    public class MovingObjectPattern
    {
        [Tooltip("Amount of time to move from point B to point A. Common values between 0.5 and 2")]
        public float moveTimerMaxA;
        [Tooltip("Amount of time to move from point A to point B. Common values between 0.5 and 2")]
        public float moveTimerMaxB;
        [Tooltip("Amount of time to stop after reaching A.")]
        public float stopTimerA;
        [Tooltip("Amount of time to stop after reaching B.")]
        public float stopTimerB;
    }


    // Use this for initialization
    void Start () {

        if (RepeatOption == true && (movingObjectPatterns == null || movingObjectPatterns.Length < 1)){
            Debug.LogError("Moving object error: " + name + " has no pattern");
            return;
        }

        currentPattern = 0;

        if(pressureplateScript != null){
            pressurePlateActivateOption = true;
            pressureplateScript.OnEnter += Activate;
            isActive = false;
        }
        else {
            pressurePlateActivateOption = false;
            isActive = true;
        }

        StartMoving();

        if(movingObjectPatterns != null && movingObjectPatterns.Length > 0)
        {
            stopTimer = movingObjectPatterns[currentPattern % movingObjectPatterns.Length].stopTimerA;
            moveTimer = movingObjectPatterns[currentPattern % movingObjectPatterns.Length].moveTimerMaxA;
        }
    }

    private void Activate()
    {
        isActive = true;
    }

    void StartMoving()
    {
        speed = Vector3.Distance(PositionA.position, PositionB.position) / moveTimer;
        if (!reverseDirection){
            transform.position = PositionB.transform.position;
        }
        else{
            transform.position = PositionA.transform.position;
        }

    }

    // Update is called once per frame

    void FixedUpdate () {
        if (!isActive){
            return;
        }

        if (RepeatOption == true){

            if (movingObjectPatterns == null || movingObjectPatterns.Length < 1){
                Debug.LogError("Moving object error: " + name + " has no pattern");
                return;
            }

            moveCurr += Time.deltaTime;

            if (moveCurr > moveTimer){
                if (reverseDirection){
                    transform.position = PositionB.position;
                }
                else {
                    transform.position = PositionA.position;
                }

                stopCurr += Time.deltaTime;
                if (stopCurr > stopTimer){
                    stopCurr = 0;
                    moveCurr = 0;

                    if (reverseDirection){
                        stopTimer = movingObjectPatterns[currentPattern % movingObjectPatterns.Length].stopTimerA;
                        moveTimer = movingObjectPatterns[currentPattern % movingObjectPatterns.Length].moveTimerMaxA;
                        reverseDirection = false;

                        currentPattern++;
                    }
                    else {
                        stopTimer = movingObjectPatterns[currentPattern % movingObjectPatterns.Length].stopTimerB;
                        moveTimer = movingObjectPatterns[currentPattern % movingObjectPatterns.Length].moveTimerMaxB;
                        reverseDirection = true;
                    }
                }
            }
            else{
                //calculate what speed is needed to traverse from a to b in the correct time
                if (!reverseDirection){
                    float moveSpeed = Vector3.Distance(PositionA.position, PositionB.position) / moveTimer;

                    transform.Translate((PositionA.position - transform.position).normalized * Time.deltaTime * moveSpeed);

                    //transform.localPosition = Vector3.Lerp(PositionB.localPosition, PositionA.localPosition, (moveCurr % moveTimer) / moveTimer);
                }
                else{
                    float moveSpeed = Vector3.Distance(PositionA.position, PositionB.position) / moveTimer;

                    transform.Translate((PositionB.position - transform.position).normalized * Time.deltaTime * moveSpeed);

                    //transform.localPosition = Vector3.Lerp(PositionA.localPosition, PositionB.localPosition, (moveCurr % moveTimer) / moveTimer);
                }
            }
        }
        else
        {
            if (moveCurr < moveTimer)
            {
                moveCurr += Time.deltaTime;

                //calculate what speed is needed to traverse from a to b in the correct time
                if (!reverseDirection){
                    float moveSpeed = Vector3.Distance(PositionA.position, PositionB.position) / moveTimer;

                    transform.Translate((PositionA.position - transform.position).normalized * Time.deltaTime * moveSpeed);

                    //transform.localPosition = Vector3.Lerp(PositionB.localPosition, PositionA.localPosition, (moveCurr % moveTimer) / moveTimer);
                }
                else{
                    float moveSpeed = Vector3.Distance(PositionA.position, PositionB.position) / moveTimer;

                    transform.Translate((PositionB.position - transform.position).normalized * Time.deltaTime * moveSpeed);

                    //transform.localPosition = Vector3.Lerp(PositionA.localPosition, PositionB.localPosition, (moveCurr % moveTimer) / moveTimer);
                }
            }
            else{
                transform.position = PositionA.position;
            }
        }        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        other.transform.parent = this.transform;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        other.transform.parent = null;
    //    }
    //}
}
