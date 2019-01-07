using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicParameterTrigger : MonoBehaviour {

    FMODUnity.StudioEventEmitter musicEmitter;
    public bool MakeAmbient;
    
	void OnEnable () {
        GameObject GameobjectTarget = GameObject.Find("GameController");
        musicEmitter = GameobjectTarget.GetComponent<FMODUnity.StudioEventEmitter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (MakeAmbient)
        {
            musicEmitter.SetParameter("AmbientMode", 1);
        }
        else if (!MakeAmbient)
        {
            musicEmitter.SetParameter("AmbientMode", 0);
        }
    }
}
