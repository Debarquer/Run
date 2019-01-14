using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ParticleSystem))]
public class FireworksAudio : MonoBehaviour {

    ParticleSystem ps;
    AudioSource aso;

     //public AudioClip OnBirthSound;
     public AudioClip OnDeathSound;
 
     private int _numberOfParticles = 0;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        aso = GetComponent<AudioSource>();

        aso.clip = OnDeathSound;
    }

    void Update()
    {
        if (!OnDeathSound) { return; }
        var count = ps.particleCount;
        if (count < _numberOfParticles)
        { //particle has died
            //if (!aso.isPlaying)
            //{
            //    aso.Play();
            //}
            aso.Play();
        }
        else if (count > _numberOfParticles)
        { //particle has been born
            //SoundManager.Play(audio, OnBirthSound);
        }
        _numberOfParticles = count;
    }

}
