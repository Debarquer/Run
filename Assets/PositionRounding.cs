using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRounding : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Transform[] transforms = GetComponentsInChildren<Transform>();

		foreach(Transform t in transforms)
        {
            float x = Mathf.Floor(t.position.x);
            float y = Mathf.Floor(t.position.y);
            float z = Mathf.Floor(t.position.z);

            t.position = new Vector3(x, y, z);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
