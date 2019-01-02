using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCubeAnimation : MonoBehaviour {

    bool hasAnimated = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.transform.name);

        if(collision.transform.tag == "Player")
        {
            if (!hasAnimated)
            {
                hasAnimated = true;
                GetComponentInParent<Animator>().Play("FallingCubeAnimation");
            }

        }
    }
}
