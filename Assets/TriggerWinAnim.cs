using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWinAnim : MonoBehaviour {
    public GameObject playerImpersonator;
    public Transform impersonatorPos;
    Transform playerPos;
    GameObject player;
    Player freeze;
    IdleAnimationScript idle;
    MeshRenderer mr;
    bool triggered;
    bool hasWon = false;
    float tick = 0;
    float nextTick;
    float currTick;
    [FMODUnity.EventRef]
    public string winSound;
   // private Transform animPos;

    private void Start()
    {
        player = GameObject.Find ("PlayerMonoScript");
        freeze = player.GetComponent<Player>();
        idle = player.GetComponent<IdleAnimationScript>();
        mr = player.GetComponent<MeshRenderer>();
        playerPos = player.GetComponent<Transform>();
       
    }


    private void Update()
    {
        tick += Time.deltaTime;
        //Debug.Log(tick);
        if (hasWon == true)
        {
            if (tick >= nextTick)
            {

                Debug.Log("PlayerEnabled");
                EnablePlayer();
                hasWon = false;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (triggered == false)
            {
                nextTick = tick + 2f;
                DisablePlayer();
                Debug.Log("Disabled player");
                FMODUnity.RuntimeManager.PlayOneShot(winSound);
                triggered = true;
                hasWon = true;

            }
        }

    }

    void DisablePlayer()
    {
        Instantiate<GameObject>(playerImpersonator, player.transform.position, Quaternion.identity);
        //animPos.transform.position = player.transform.position;
        freeze.canMove = false;
        idle.enabled = false;  
        mr.enabled = false;
        
    }
    void EnablePlayer()
    {
        freeze.canMove = true;
        idle.enabled = true;
        mr.enabled = true;
        //playerPos.transform.position = animPos.transform.position;

        Destroy (GameObject.FindGameObjectWithTag("Imp"));
        
    }
}
