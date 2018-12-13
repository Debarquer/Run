using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : MonoBehaviour {

    public GameObject targetRoom;
    public GameObject doorModel;
    public GameObject lightSource;

	// Use this for initialization
	void Start () {
        targetRoom.SetActive(false);
        //doorModel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (lightSource != null)
            {
                lightSource.SetActive(false);
            }
            targetRoom.SetActive(true);
            
            //doorModel.SetActive(true);

        }
    }
}
