using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCubeTriggerScript : MonoBehaviour {

    [FMODUnity.EventRef]
    public string BlockSound;

    public GameObject[] thoseAboutToFall;
    public bool ApplyForce;
    public bool TriggerOnce;
    float force = 650f;
    [SerializeField] bool sprayRight;
    [SerializeField] bool sprayLeft;
    [SerializeField] bool morePower;

    private void Start()
    {
        if (morePower)
        {
            force = force * 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (TriggerOnce)
        {

            if (other.tag == "Player")
            {
                FMODUnity.RuntimeManager.PlayOneShot(BlockSound);
                foreach (var rb in thoseAboutToFall)
                {
                    rb.AddComponent<Rigidbody>();
                    

                    if (ApplyForce)
                    {

                        Rigidbody rigidbody = rb.GetComponent<Rigidbody>();
                        rigidbody.AddForce(transform.up * force);
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
