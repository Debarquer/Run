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

	// Use this for initialization
	void Start () {
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
	void Update () {
        moveCurr += Time.deltaTime;
        if(moveCurr > moveTimer)
        {
            stopCurr += Time.deltaTime;
            if(stopCurr > stopTimer)
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
            if (!reverseDirection)
            {
                transform.localPosition = Vector3.Lerp(PositionB.localPosition, PositionA.localPosition, (moveCurr % moveTimer) / moveTimer);
            }
            else
            {
                transform.localPosition = Vector3.Lerp(PositionA.localPosition, PositionB.localPosition, (moveCurr % moveTimer) / moveTimer);
            }
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if(other.transform.parent == this.transform)
            {
                other.transform.parent = null;
            }
        }
    }
}
