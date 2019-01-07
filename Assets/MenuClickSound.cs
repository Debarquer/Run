using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClickSound : MonoBehaviour {

    [FMODUnity.EventRef]
    public string clickSound;

    public void ClickSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(clickSound);
    }
}
