using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerShooter2 : MonoBehaviour {

    [SerializeField]
    int damagePerHit = 15;

    [SerializeField]
    float timeBetweenBullets = 0.05f;

    [SerializeField]
    float range = 10f;
    
    ParticleSystem gunParticles;
    Light gunLight;
    AudioSource gunAudio;
    int shootableMask;
    bool enter;
    bool exit;
    bool inside;


    // Use this for initialization
    void Awake () {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunParticles.Stop();
        gunAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        //var trigger = gunParticles.trigger;
        //trigger.enter = enter ? ParticleSystemOverlapAction.Callback : ParticleSystemOverlapAction.Ignore;
        //trigger.exit = exit ? ParticleSystemOverlapAction.Callback : ParticleSystemOverlapAction.Ignore;
        //trigger.inside = inside ? ParticleSystemOverlapAction.Callback : ParticleSystemOverlapAction.Ignore;

        if (Input.GetButtonDown("Fire1"))
        {
            gunParticles.Play();
            gunAudio.Play();
        }
        if(Input.GetButtonUp("Fire1"))
        {
            gunParticles.Stop();
            gunAudio.Stop();
        }
    }

    

}
