using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverButtonSound : MonoBehaviour {

    [FMODUnity.EventRef]
    public string hoverSound;

    public void HoverSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(hoverSound);
    }
}
