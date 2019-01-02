﻿using UnityEngine;

public class ScrapingSoundScript : MonoBehaviour {

    [FMODUnity.EventRef]
    public string scraping;
    FMOD.Studio.EventInstance ScrapingSound;
    FMOD.Studio.ParameterInstance SoundorNot;
    float xvel;
    float zvel;
    private Rigidbody rb;



    // Use this for initialization
    void Start () {

        ScrapingSound = FMODUnity.RuntimeManager.CreateInstance(scraping);
        ScrapingSound.getParameter("Stoporgo", out SoundorNot);
        ScrapingSound.start();
        rb = GetComponent<Rigidbody>();
        
	}

    // Update is called once per frame
    void Update()
        
    {
        xvel = Mathf.Min (6, Mathf.Abs(rb.velocity.x));
        zvel = Mathf.Min (6, Mathf.Abs(rb.velocity.z));

       


        if (xvel > 0f)
        {
            SoundorNot.setValue(xvel);
        }
        else if (zvel > 0f)
        {
            SoundorNot.setValue(zvel);
        }
        else
        {
            SoundorNot.setValue(0);
        }
        


    }

}