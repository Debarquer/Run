using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCanMoveAndCameraSpeed : MonoBehaviour {

    public bool canMove = false;
    public float moveSpeed = 1000;

    private void OnTriggerEnter(Collider other)
    {if(other.tag == "Player")
        {
            FindObjectOfType<Player>().canMove = canMove;
            Camera.main.GetComponent<CameraFollow>().speed = moveSpeed;
        }
        
    }
}
