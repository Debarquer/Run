using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCubeTriggerScript : MonoBehaviour {
    public GameObject[] thoseAboutToFall;

    private void OnTriggerEnter(Collider other)
    {

        foreach (var rb in thoseAboutToFall)
        {
            rb.AddComponent<Rigidbody>();
        }

    }
}
