using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimationScript : MonoBehaviour {
    public Animator anim;
    public float tick;
    float nextTick = 0;

    [FMODUnity.EventRef]
    public string idlesound;

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
                FMODUnity.RuntimeManager.PlayOneShot(idlesound);

            }

            nextTick += Time.deltaTime;

        }
        else
        {

            nextTick = 0;
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.Equals("WinAnimBox"))
    //    {
    //        anim.Play("WinAnimation");
    //    }

    //}
}
