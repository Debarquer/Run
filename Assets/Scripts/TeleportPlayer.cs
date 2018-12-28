using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour {

    public Transform exit;

    [FMODUnity.EventRef]
    public string teleportSound;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            FMODUnity.RuntimeManager.PlayOneShot(teleportSound);
            other.transform.position = exit.transform.position;
        }
    }
}