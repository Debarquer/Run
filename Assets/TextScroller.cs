﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScroller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0.005f, 0);
        if(transform.localPosition.y > 800)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, -220f, transform.localPosition.z);
        }
	}
}
