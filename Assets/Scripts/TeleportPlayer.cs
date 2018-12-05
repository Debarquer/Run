using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour {

    public Transform exit;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            other.transform.position = exit.transform.position;
        }
    }
}