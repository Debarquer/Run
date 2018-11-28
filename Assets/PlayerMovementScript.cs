using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {
    public float speed = 6;
    public float snapSpeed = 0.5f;
    Vector3 currentVelocity;
    Vector3 lastPosition;
    public float tick;
    float nextTick = 0;

    void Start () {

    }
	

	void FixedUpdate () {
        VelocityMovement();
    }

    void VelocityMovement()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        direction.Normalize();
        GetComponent<Rigidbody>().velocity = new Vector3(direction.x * speed, GetComponent<Rigidbody>().velocity.y, direction.z * speed);
    }

    void AddForceMovement()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        direction.Normalize();
        GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
    }

    private void SnapPosition() {
        Vector3 snapTarget = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
        transform.position = Vector3.Lerp(transform.position, snapTarget, snapSpeed);
    }

    void TranslateMovement()
    {
        // https://answers.unity.com/questions/1190224/how-can-i-normalize-2d-vectors.html

        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        direction.Normalize();
        transform.Translate(direction * Time.deltaTime * speed);
        if (direction == Vector3.zero)
        {
            //SnapPosition();
        }

    }
    void Update()
        
    {
        if (nextTick > tick)
        {
            nextTick -= tick;
            if (GetComponent<Rigidbody>().velocity == Vector3.zero)

            {
                Debug.Log("Test");
            }

        }
        nextTick += Time.deltaTime;
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


