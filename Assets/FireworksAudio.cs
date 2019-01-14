using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ParticleSystem))]
public class FireworksAudio : MonoBehaviour {

    ParticleSystem ps;
    [FMODUnity.EventRef]
    public string fireWorkSound;

    public int _numberOfParticles = 0;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var count = ps.particleCount;
        if (count < _numberOfParticles)
        { //particle has died
            //if (!aso.isPlaying)
            //{
            //    aso.Play();
            //}
            //aso.Play();
            FMODUnity.RuntimeManager.PlayOneShot(fireWorkSound);
        }
        _numberOfParticles = count;
    }

}
