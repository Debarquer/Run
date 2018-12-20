using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayCloser : MonoBehaviour {

    public GameObject targetRoom;
    //public GameObject doorModel;

    public delegate void DoorClosedDelegate();
    public event DoorClosedDelegate OnDoorClosed;

    // Use this for initialization
    void Start()
    {
        //targetRoom.SetActive(false);
        //doorModel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            targetRoom.SetActive(false);

            if(OnDoorClosed != null)
                OnDoorClosed();

            Destroy(this);

            //doorModel.SetActive(true);

        }
    }
}
