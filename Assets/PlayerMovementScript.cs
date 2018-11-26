using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W)) {
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

        

        
	}
}
