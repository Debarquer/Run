using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStamina))]
public class PlayerMovementScript : MonoBehaviour
{
    public float speed = 6;
    public float snapSpeed = 0.5f;
    public Vector3 currentVelocity;
    Vector3 lastPosition;

    void FixedUpdate()
    {
        AddForceMovement();

        currentVelocity = GetComponent<Rigidbody>().velocity;
        if (currentVelocity != Vector3.zero)
        {
            GetComponent<PlayerStamina>().isRunning = true;
        }
        else
        {
            GetComponent<PlayerStamina>().isRunning = false;
        }
    }

    //void VelocityMovement()
    //{
    //    Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

    //    direction.Normalize();
    //    GetComponent<Rigidbody>().velocity = new Vector3(direction.x * speed, GetComponent<Rigidbody>().velocity.y, direction.z * speed);
    //}

    void AddForceMovement()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        direction.Normalize();
        GetComponent<Rigidbody>().AddForce(direction * speed * Time.deltaTime, ForceMode.Impulse);
    }

    private void SnapPosition()
    {
        Vector3 snapTarget = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
        transform.position = Vector3.Lerp(transform.position, snapTarget, snapSpeed);
    }
}

