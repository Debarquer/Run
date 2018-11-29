using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJumpScript : MonoBehaviour {

    public bool grounded = true;
    public float jumpPower = 8;
    public GameObject jumpshadow;

    public Vector3 gravity = new Vector3(0, -9.81f * 1.5f, 0);
    public Vector3 velocity;
    public Vector3 maxVeloctity;
    public Vector3 minVelocity;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = GetComponent<Rigidbody>().velocity;

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                //GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 1.0f, 0.0f) * 2f, ForceMode.Impulse);
                velocity = new Vector3(0.0f, jumpPower, 0.0f);
            }
        }

        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hitinfo;
        Physics.Raycast(ray, out hitinfo);

        if (hitinfo.collider.isTrigger)
        {
            return;
        }

        Ray rayA = new Ray(new Vector3(transform.position.x + 0.49f, transform.position.y, transform.position.z + 0.49f), Vector3.down);
        RaycastHit hitinfoA;
        Physics.Raycast(rayA, out hitinfoA);

        Ray rayB = new Ray(new Vector3(transform.position.x + 0.49f, transform.position.y, transform.position.z - 0.49f), Vector3.down);
        RaycastHit hitinfoB;
        Physics.Raycast(rayB, out hitinfoB);

        Ray rayC = new Ray(new Vector3(transform.position.x - 0.49f, transform.position.y, transform.position.z + 0.49f), Vector3.down);
        RaycastHit hitinfoC;
        Physics.Raycast(rayC, out hitinfoC);

        Ray rayD = new Ray(new Vector3(transform.position.x - 0.49f, transform.position.y, transform.position.z - 0.49f), Vector3.down);
        RaycastHit hitinfoD;
        Physics.Raycast(rayD, out hitinfoD);

        //Debug.Log(GetComponent<Rigidbody>().velocity);
        jumpshadow.transform.position = hitinfo.point;

        if (Mathf.Abs(transform.position.y - hitinfoA.point.y) < 1.01f ||
            Mathf.Abs(transform.position.y - hitinfoB.point.y) < 1.01f ||
            Mathf.Abs(transform.position.y - hitinfoC.point.y) < 1.01f ||
            Mathf.Abs(transform.position.y - hitinfoD.point.y) < 1.01f)
        {
            grounded = true;
            //GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, GetComponent<Rigidbody>().velocity.z);
        }
        else
        {
            grounded = false;
        }

        if (velocity.x > maxVeloctity.x)
        {
            velocity.x = maxVeloctity.x;
        }
        if (velocity.x < minVelocity.x)
        {
            velocity.x = minVelocity.x;
        }

        if (velocity.y > maxVeloctity.y)
        {
            velocity.y = maxVeloctity.y;
        }
        if (velocity.y < minVelocity.y)
        {
            velocity.y = minVelocity.y;
        }

        if (velocity.z > maxVeloctity.z)
        {
            velocity.z = maxVeloctity.z;
        }
        if (velocity.z < minVelocity.z)
        {
            velocity.z = minVelocity.z;
        }

        GetComponent<Rigidbody>().velocity = velocity;
    }

    private void FixedUpdate()
    {
         GetComponent<Rigidbody>().AddForce(gravity);
    }
}
