﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {
    public float speed = 6;
    public float snapSpeed = 0.5f;

    void Start () {

    }
	

	void Update () {
        // https://answers.unity.com/questions/1190224/how-can-i-normalize-2d-vectors.html

        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        direction.Normalize();
        transform.Translate(direction* Time.deltaTime *speed);
        if (direction == Vector3.zero) {
            Vector3 snapTarget = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
            transform.position = Vector3.Lerp(transform.position, snapTarget, snapSpeed);
        }

    }
}
/*  if (Input.GetKey(KeyCode.W)) {
     Debug.Log("test");
     transform.Translate((Vector3.forward * Time.deltaTime ).normalized *speed);
 }
 if (Input.GetKey(KeyCode.S))
 {
     transform.Translate((-Vector3.forward * Time.deltaTime ).normalized*speed);
 }
 if (Input.GetKey(KeyCode.D))
 {
     transform.Translate((Vector3.right * Time.deltaTime).normalized*speed);
 }
 if (Input.GetKey(KeyCode.A))
 {
     transform.Translate((Vector3.left*Time.deltaTime).normalized*speed);
 }
 */

