using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour {
    [FMODUnity.EventRef]
    public string collisionSound;
    public bool hasBeenTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (hasBeenTriggered == false)
            {
                FMODUnity.RuntimeManager.PlayOneShot(collisionSound);
                Debug.Log("PlaySound");
                hasBeenTriggered = true;
            }
            
        }
        
    }
    
}
