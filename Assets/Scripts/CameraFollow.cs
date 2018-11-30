using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    GameObject playerObj;
    public Vector3 offset;
    public float speed = 2;

   void Start()
    {
     playerObj = GameObject.Find("Player");
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp (transform.position, playerObj.transform.position + offset, speed * Time.deltaTime);
    }
}
