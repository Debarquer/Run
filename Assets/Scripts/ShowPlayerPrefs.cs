using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlayerPrefs : MonoBehaviour {

    public int red;
    public int green;
    public int blue;

    // Use this for initialization
    void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
        red = PlayerPrefs.GetInt("RedLevel");
        green = PlayerPrefs.GetInt("Green Level");
        blue = PlayerPrefs.GetInt("BlueLevel");
    }    
}
