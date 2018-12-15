using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBoxCastShooting : MonoBehaviour {

    public int damagePerShot = 15;
    public float timeBetweenBullets = 0.15f;
    public float range = 8f;
    //public GameObject impactEffect;
    //public GameObject impactEffect2;
    
    float timer;
    BoxCollider colliderBox;
    BoxCollider oldBox;
    RaycastHit[] shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    float effectsDisplayTime = 1f;

    // Use this for initialization
    void Awake () {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunParticles.Stop();
        gunAudio = GetComponent<AudioSource>();
        colliderBox = GetComponent<BoxCollider>();
        oldBox = colliderBox;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            oldBox = colliderBox;
            gunAudio.Play();
            gunParticles.Play();
            Shoot();
        }
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            StopShootingEffect();
            colliderBox = oldBox;
        }

    }

    void Shoot()
    {

        if (Physics.BoxCast(colliderBox.bounds.center,colliderBox.size,transform.forward,
            colliderBox.transform.rotation,range,shootableMask))
        {
            float xAxis = colliderBox.size.x;
            float yAxis = colliderBox.size.y;
            float zAxis = colliderBox.size.z;
            colliderBox.size.Set(xAxis * 1.5f, yAxis, zAxis);
            shootHit = Physics.BoxCastAll(colliderBox.bounds.center, colliderBox.size, transform.forward, colliderBox.transform.rotation, range, shootableMask);
            for(int i = 0; i < shootHit.Length; i++)
            {
                EnemyHealth enemyHealth = shootHit[i].collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damagePerShot, shootHit[i].point);

                    //Create fire effect on hit
                    //GameObject impactGO = Instantiate(impactEffect,shootHit.point, Quaternion.LookRotation(shootHit.normal));
                    //GameObject impactGO2 = Instantiate(impactEffect2, shootHit.point, Quaternion.LookRotation(shootHit.normal));
                    //Destroy(impactGO, 1f);
                    //Destroy(impactGO2, 2f);
                }
            }
        }

        timer = 0f;

    }

    void StopShootingEffect()
    {
        gunParticles.Stop();
        gunAudio.Stop();
    }

}