using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapingSoundScript : MonoBehaviour {

    [FMODUnity.EventRef]
    public string scraping;
    FMOD.Studio.EventInstance ScrapingSound;
    FMOD.Studio.ParameterInstance SoundorNot;



    // Use this for initialization
    void Start () {

        ScrapingSound = FMODUnity.RuntimeManager.CreateInstance(scraping);
        ScrapingSound.getParameter("Stoporgo", out SoundorNot);
        ScrapingSound.start();
        
	}

    // Update is called once per frame
    void Update()
        
    {
        Debug.Log(GetComponent<Rigidbody>().velocity);
        if (GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            SoundorNot.setValue(0f);
            //Debug.Log("noSound");
        }
        else
        {
            SoundorNot.setValue(6f);
            //Debug.Log("Sound");
        }
    }

}
