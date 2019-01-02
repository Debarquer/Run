using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateASoundScript : MonoBehaviour {
    [FMODUnity.EventRef]
    public string enter;

    [FMODUnity.EventRef]
    public string exit;
  



    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Pillar")
       {
            FMODUnity.RuntimeManager.PlayOneShotAttached(enter, this.gameObject);
            
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
