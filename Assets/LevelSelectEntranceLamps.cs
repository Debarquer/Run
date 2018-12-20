using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectEntranceLamps : MonoBehaviour {

    public Material emissiveMaterial;
    public Material nonEmissiveMaterial;
    //public GameObject lamps;
    public string levelName;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt(levelName) == 0)
        {
            GetComponent<Renderer>().material = nonEmissiveMaterial;
            GetComponent<Light>().enabled = true;
            //lamps.SetActive(false);
        }
        else if(PlayerPrefs.GetInt(levelName) == 1)
        {
            GetComponent<Renderer>().material = emissiveMaterial;
            //lamps.SetActive(true);
            GetComponent<Light>().enabled = false;
        }
        else
        {
            Debug.Log("LevelSelectEntranceLamps error: Invalid playerprefs result");
        }
	}
}
