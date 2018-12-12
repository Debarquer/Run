using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCube : MonoBehaviour {

    Rigidbody rb;

    private void FixedUpdate()
    {
        rb.AddForce(transform.up*100);
    }
}
