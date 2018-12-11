using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingPillarStopper : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        MovingObject mo = collision.gameObject.GetComponent<MovingObject>();
        if(mo != null)
        {
            //mo.moveCurr = mo.moveTimer;
            //mo.reverseDirection = true;
        }
    }
}
