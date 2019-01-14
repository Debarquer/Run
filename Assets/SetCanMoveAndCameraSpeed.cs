using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCanMoveAndCameraSpeed : MonoBehaviour {

    public bool canMove = false;
    public float moveSpeed = 1000;
    public GameObject timerCanvas;

    bool hasBeenTriggered = false;

    GameController gc;

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canMove)
        {
            if (other.tag == "Player")
            {
                if(gc == null)
                {
                    gc = FindObjectOfType<GameController>();
                }

                player.canMove = canMove;
                //player.GetComponent<TrailRenderer>().enabled = true;
                Camera.main.GetComponent<CameraFollow>().speed = moveSpeed;

                if (gc.mode == GameController.GameMode.Timed)
                {
                    gc.stopTimer = false;
                    gc.Timer = 0;
                    timerCanvas.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!canMove)
        {
            if (other.tag == "Player")
            {
                if (gc == null)
                {
                    gc = FindObjectOfType<GameController>();
                }

                player.canMove = canMove;
                player.GetComponent<TrailRenderer>().enabled = false;
                Camera.main.GetComponent<CameraFollow>().speed = moveSpeed;

                if (gc.mode == GameController.GameMode.Timed)
                {
                    gc.Timer = 0;
                    timerCanvas.SetActive(true);
                }
            }
        }
    }
}
