using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingPillarStopper : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        MovingObject mo = other.gameObject.GetComponent<MovingObject>();
        if (mo != null)
        {
            mo.enabled = false;
        }
    }
}
