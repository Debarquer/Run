using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : MonoBehaviour {

    public GameObject targetRoom;
    public GameObject doorModel;

	// Use this for initialization
	void Start () {
        doorModel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            targetRoom.SetActive(true);
            //doorModel.SetActive(true);
        }
    }
}
