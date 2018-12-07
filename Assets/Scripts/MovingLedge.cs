using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLedge : MonoBehaviour {
    //VIDARS SCRIPT SOM HAN LÄR SIG AV!!!

    public PressurePlateScript pss;

    public float maxRange;

	// Use this for initialization
	void Start () {

        pss.OnEnter += MoveTheFNPillar;
	}
	
	// Update is called once per frame
	void MoveTheFNPillar () {

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), 0.01f);
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Max(transform.position.z, maxRange));
	}
}
