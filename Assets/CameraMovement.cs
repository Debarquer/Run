using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovementScript>().transform;
    }

    private void LateUpdate()
    {
        this.transform.position = new Vector3(player.transform.position.x + 10, 27, player.transform.position.z - 20);
    }
}
