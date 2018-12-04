using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDontDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] objCount = GameObject.FindGameObjectsWithTag("Music");
        if (objCount.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
	}
	

}
