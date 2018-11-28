using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimationScript : MonoBehaviour {
    public Animator anim;
    public float tick;
    float nextTick = 0;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Rigidbody>().velocity == Vector3.zero)

        {
            if (nextTick > tick)
            {
                nextTick -= tick;
                anim.Play("Idle Anim");

            }

            nextTick += Time.deltaTime;

        }
        else
        {

            nextTick = 0;

        }
    }
}
