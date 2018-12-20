using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShadowActive : MonoBehaviour {

    public GameObject targetEnemy;
    public Transform spawnpoint;
    public bool shadowActivate;
    public bool hasBeenActivated = false;
    public Enemy enemy;
    public float SpeedUpdate;
    public bool ActivateToSetNewSpeed;
    public bool ActivateToResetSpeed;




    private void OnTriggerEnter(Collider other) {

        if (other.tag == "Player")
        {
            if (ActivateToSetNewSpeed == true)
            {
                NewSpeed();
            }
            if (ActivateToResetSpeed)
            {
                enemy.ResetSpeed();
            }
            if (hasBeenActivated == false)
            {
                if (shadowActivate == true)
                {
                    hasBeenActivated = true;
                    if (targetEnemy.activeInHierarchy)
                    {
                        Teleport();
                    }
                    else
                    {
                        targetEnemy.SetActive(true);
                        Teleport();                       
                    }
                }
                else if (shadowActivate == false && targetEnemy.activeInHierarchy)
                {
                    targetEnemy.SetActive(false);
                }
            }
        }
    }

    private void Teleport()
    {
        targetEnemy.GetComponent<NavMeshAgent>().Warp(spawnpoint.transform.position);
    }
    private void NewSpeed()
    {
        enemy.UpdateSpeed(SpeedUpdate);
    }

}
