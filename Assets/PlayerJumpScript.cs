using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJumpScript : MonoBehaviour {

    public bool grounded = true;
    public float jumpPower = 8;
    public GameObject jumpshadow;

    public Vector3 gravity = new Vector3(0, -9.81f * 1.5f, 0);

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().useGravity = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Jump"))
        {
            if (grounded)
            {
                //GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 1.0f, 0.0f) * 2f, ForceMode.Impulse);
                GetComponent<Rigidbody>().velocity = new Vector3(0.0f, jumpPower, 0.0f);
            }
        }

        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hitinfo;
        Physics.Raycast(ray, out hitinfo);

        //Debug.Log(GetComponent<Rigidbody>().velocity);
        jumpshadow.transform.position = hitinfo.point;

        if (Mathf.Abs(transform.position.y - hitinfo.point.y) < 1.01f)
        {
            grounded = true;
            //GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, GetComponent<Rigidbody>().velocity.z);
        }
        else
        {
            grounded = false;
        }
    }

    private void FixedUpdate()
    {
        if(!grounded)
            GetComponent<Rigidbody>().AddForce(gravity);
    }
}
