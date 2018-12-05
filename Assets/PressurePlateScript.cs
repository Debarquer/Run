using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour {
    
    public Material triggered;
    public Material Default;
    GameObject plate;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            plate = GameObject.FindGameObjectWithTag("Plate");
            plate.GetComponent<Renderer>().material = triggered;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            plate.GetComponent<Renderer>().material = Default;
        }
    }
}
