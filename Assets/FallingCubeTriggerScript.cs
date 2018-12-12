using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCubeTriggerScript : MonoBehaviour {
    public GameObject[] thoseAboutToFall;
    public bool ApplyForce;
    public bool TriggerOnce;
    [SerializeField] bool sprayRight;
    [SerializeField] bool sprayLeft;

   
    private void OnTriggerEnter(Collider other)
    {
        if (TriggerOnce)
        {

            if (other.tag == "Player")
            {
                foreach (var rb in thoseAboutToFall)
                {
                    rb.AddComponent<Rigidbody>();
                    if (ApplyForce)
                    {
                        Rigidbody rigidbody = rb.GetComponent<Rigidbody>();
                        rigidbody.AddForce(transform.up * 650);
                        if (sprayRight)
                        {
                        rigidbody.AddForce(transform.right * 100);
                        }
                        if (sprayLeft)
                        {
                        rigidbody.AddForce(transform.forward * 100);
                        }
                        rigidbody.mass = 4;
                    }

                }
                        TriggerOnce = false;
            }
        }
    }

}
