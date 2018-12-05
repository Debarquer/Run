using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour {

    public PressurePlateScript pss;

	// Use this for initialization
	void Start () {
        pss.OnEnter += OnTriggered;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggered()
    {
        transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z + 1);
    }
}
