using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowActive : MonoBehaviour {

    public GameObject targetEnemy;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            targetEnemy.SetActive(true);
        }
    }
}
