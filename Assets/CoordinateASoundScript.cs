using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateASoundScript : MonoBehaviour {
    [FMODUnity.EventRef]
    public string enter;

    [FMODUnity.EventRef]
    public string exit;
    public GameObject triggerSetActive;

    private void Start()
    {
        if(triggerSetActive != null)
        {
            triggerSetActive.SetActive(false);
        }
    }




    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Pillar")
       {
            FMODUnity.RuntimeManager.PlayOneShotAttached(enter, this.gameObject);

            if(triggerSetActive != null)
            {
                triggerSetActive.SetActive(true);
            }
            else
            {
                //sDebug.Log("CoordinateASoundScript triggerSetActive is null", this);
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Pillar")
        {
            FMODUnity.RuntimeManager.PlayOneShotAttached(exit, this.gameObject);
           
        }
       
    }
}
