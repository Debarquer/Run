using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class PlayerStamina : MonoBehaviour {

    public bool isRunning = false;

    public float maxStamina;
    public float stamina;

    public Color maxStaminaColor;
    public Color noStaminaColor;

    MeshRenderer mr;

	// Use this for initialization
	void Start () {
        mr = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isRunning)
        {
            stamina -= Time.deltaTime;
            if (stamina <= 0)
                stamina = 0;
        }
        else
        {
            stamina += Time.deltaTime;
            if (stamina >= maxStamina)
                stamina = maxStamina;
        }
        
        mr.material.color = Color.Lerp(maxStaminaColor, noStaminaColor, stamina / maxStamina);
	}
}
