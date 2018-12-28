using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCanMoveAndCameraSpeed : MonoBehaviour {

    public bool canMove = false;
    public float moveSpeed = 1000;
    public GameObject timerCanvas;

    private void OnTriggerEnter(Collider other)
    {if(other.tag == "Player")
        {
            FindObjectOfType<Player>().canMove = canMove;
            Camera.main.GetComponent<CameraFollow>().speed = moveSpeed;

            if(FindObjectOfType<GameController>().mode == GameController.GameMode.Timed)
            {
                FindObjectOfType<GameController>().Timer = 0;
                timerCanvas.SetActive(true);
            }
        }
    }
}
