using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    GameObject playerObj;
    public Vector3 offset;
    

   void Start()
    {
     playerObj = GameObject.Find("Player");
    }

    void LateUpdate()
    {
        transform.position = playerObj.transform.position + offset;
    }
}
