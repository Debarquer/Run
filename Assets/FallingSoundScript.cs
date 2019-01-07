using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSoundScript : MonoBehaviour {

    [FMODUnity.EventRef]
    public string fallingSound;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FMODUnity.RuntimeManager.PlayOneShot(fallingSound);
        }
    }
}
