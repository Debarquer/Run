using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBridgeSound : MonoBehaviour {

    [FMODUnity.EventRef]
    public string boomSound;

    bool hasFallen = false;
    private void OnTriggerEnter(Collider other)
    {
        if (hasFallen == false)
        {
            FMODUnity.RuntimeManager.PlayOneShot(boomSound);
            hasFallen = true;
        }
    }
}
