using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerShooter2 : MonoBehaviour {

    [SerializeField]
    int damagePerHit = 15;

    [SerializeField]
    public float timeBetweenBullets = 0.05f;

    [SerializeField]
    public float range = 10f;
    
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

        var trigger = gunParticles.trigger;
        trigger.enter = enter ? ParticleSystemOverlapAction.Callback : ParticleSystemOverlapAction.Ignore;
        trigger.exit = exit ? ParticleSystemOverlapAction.Callback : ParticleSystemOverlapAction.Ignore;
        trigger.inside = inside ? ParticleSystemOverlapAction.Callback : ParticleSystemOverlapAction.Ignore;

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

    private void OnParticleTrigger()
    {
        if(enter)
        {
            List<ParticleSystem.Particle> enterList = new List<ParticleSystem.Particle>();
            int numEnter = gunParticles.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterList);
            Debug.Log("Particle has entered Collider!!!");

            for (int i = 0; i < numEnter; i++)
            {
                ParticleSystem.Particle p = enterList[i];
                p.startColor = new Color32(0, 0, 255, 255);
                enterList[i] = p;
            }

            gunParticles.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterList);
        }
        if(inside)
        {
            Debug.Log("Particle is inside Collider!!!");
        }
        
    }

}
