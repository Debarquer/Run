using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWinAnim : MonoBehaviour {
    public GameObject playerImpersonator;
    public Transform impersonatorPos;
    GameObject player;
    Player freeze;
    IdleAnimationScript idle;
    MeshRenderer mr;
    bool triggered;
    float tick;
    float nextTick;
    float currTick;

    private void Start()
    {
        player = GameObject.Find ("PlayerMonoScript");
        freeze = player.GetComponent<Player>();
        idle = player.GetComponent<IdleAnimationScript>();
        mr = player.GetComponent<MeshRenderer>();
       
    }


    private void Update()
    {
        tick += Time.deltaTime;
        if (tick >= nextTick)
        {
            Debug.Log("PlayerEnabled");
            EnablePlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered == false)
        {
            nextTick = tick + 3;
            DisablePlayer();
            Debug.Log("Disabled player");
            triggered = true;

        }


    }

    void DisablePlayer()
    {
        Instantiate<GameObject>(playerImpersonator, impersonatorPos.position, impersonatorPos.rotation);
        freeze.canMove = false;
        idle.enabled = false;  
        mr.enabled = false;
        
    }
    void EnablePlayer()
    {
        freeze.canMove = true;
        idle.enabled = true;
        mr.enabled = true;
        Destroy(GameObject.Find ("PlayerImpersonator"));
    }
}
