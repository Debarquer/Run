using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour {

    public static GameMenu instance = null;

	// Use this for initialization
	void Start () {
        if (instance == null) {
            instance = this;
        }

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
