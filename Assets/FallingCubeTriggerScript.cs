using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCubeTriggerScript : MonoBehaviour {
    public GameObject[] thoseAboutToFall;
    public bool ApplyForce;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (var rb in thoseAboutToFall)
            {
                rb.AddComponent<Rigidbody>();
                if (ApplyForce)
                {
                    rb.GetComponent<Rigidbody>().AddForce(transform.up * 650);
                    rb.GetComponent<Rigidbody>().AddForce(transform.right * 20);
                }

            }
        }

    }

}
