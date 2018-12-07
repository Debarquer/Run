using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildObjectOnTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.transform.parent == this.transform)
            {
                other.transform.parent = null;
            }
        }
    }
}
