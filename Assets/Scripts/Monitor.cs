using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour {

    public Material[] materials;
    public int id = 0;

    public float timerMax;
    public float timer;

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().material = materials[id % materials.Length];
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > timerMax)
        {
            timer = 0;
            id++;
            GetComponent<MeshRenderer>().material = materials[id % materials.Length];
        }
	}
}
