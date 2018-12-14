using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShadowActive : MonoBehaviour {

    public GameObject targetEnemy;
    public Transform spawnpoint;
    public bool shadowActivate;



    private void OnTriggerEnter(Collider other) {
      
        
            
        if (other.tag == "Player")
        {
            

            if (shadowActivate == true)   
            {
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
            else if (shadowActivate == false)
            {
                targetEnemy.SetActive(false);
            }
        }

    }

    private void Teleport()
    {
        targetEnemy.GetComponent<NavMeshAgent>().Warp(spawnpoint.transform.position);

    }
}
