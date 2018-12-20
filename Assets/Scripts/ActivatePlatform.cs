using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlatform : MonoBehaviour {

    public PressurePlateScript pressurePlate;
	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);

		if(pressurePlate != null)
        {
            pressurePlate.OnEnter += PlatformActivate;
        }
	}

    private void PlatformActivate()
    {
        gameObject.SetActive(true);
    }
}
