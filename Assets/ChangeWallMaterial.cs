using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWallMaterial : MonoBehaviour {

    public MeshRenderer a;
    public MeshRenderer b;
    public MeshRenderer c;
    public Material window;
    public DoorwayCloser doorwayCloser;

    // Use this for initialization
    void Start () {
        doorwayCloser.OnDoorClosed += OnDoorClosed;
	}

    public void OnDoorClosed()
    {
        a.material = window;
        b.material = window;
        c.material = window;
    }
}
