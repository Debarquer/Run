using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScroller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0.01f, 0);
        if(transform.localPosition.y > 1000)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, -479f, transform.localPosition.z);
        }
	}
}
