using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDimmer : MonoBehaviour {
    Light lt;
    bool dimmingActive;
    float playerDist = 20f;
    float duration = 3.0f;
    public float intensityOffset = 7;

    public Transform player;

    void Start () {
        lt = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {

        if (dimmingActive)
        {
            playerDist = Vector3.Distance(player.position, transform.position);
            //Debug.Log("distance = " + playerDist);
            //var amplitude = Mathf.PingPong(Time.time, duration);           
        }
        lt.intensity = (2f * playerDist) - 7f;
        // 
        //Debug.Log("Distance is: " + playerDist);
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            dimmingActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            dimmingActive = false;
        }
    }
}
