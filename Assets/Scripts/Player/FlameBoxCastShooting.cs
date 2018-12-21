using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBoxCastShooting : MonoBehaviour {

    [SerializeField]
    int damagePerShot = 15;

    [SerializeField]
    float timeBetweenBullets = 0.15f;

    [SerializeField]
    float range = 9f;

    [SerializeField]
    GameObject impactEffect;

    [SerializeField]
    GameObject impactEffect2;

    float timer;
    BoxCollider colliderBox;
    RaycastHit[] shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    float effectsDisplayTime = 1f;

    float oldX;
    float xAxis;
    float currentRange;
    // Use this for initialization
    void Awake () {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunParticles.Stop();
        gunAudio = GetComponent<AudioSource>();
        //colliderBox = new BoxCollider();
        //colliderBox.size = new Vector3(2f,0.4f,0.5f);
        colliderBox = GetComponent<BoxCollider>();
        xAxis = colliderBox.size.x;
        oldX = xAxis;
        currentRange = 1;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            gunAudio.Play();
            gunParticles.Play();
            Shoot();
            if(xAxis < 3.5f)
            {
                xAxis += 0.2f;
            }
            if(currentRange < range)
            {
                currentRange += 1.5f;
                if (currentRange > range)
                {
                    currentRange = range;
                }
             }
            colliderBox.size = new Vector3(xAxis,colliderBox.size.y,colliderBox.size.z);
        }
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            StopShootingEffect();
            xAxis = oldX;
            currentRange = 1;
        }

    }

    void Shoot()
    {
        // catch a list of enemies in range
        shootHit = Physics.BoxCastAll(colliderBox.bounds.center, colliderBox.size/2, transform.forward, colliderBox.transform.rotation, currentRange, shootableMask);
        if (shootHit.Length > 0)    //check if there is any enemy target in range
        {
            for(int i = 0; i < shootHit.Length; i++) // Deals damage to every single one of them
            {
                EnemyHealth enemyHealth = shootHit[i].collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    //deal damage to the target enemy
                    enemyHealth.TakeDamage(damagePerShot, shootHit[i].point);

                    //Create fire effect on hit
                    GameObject impactGO = Instantiate(impactEffect, shootHit[i].point, Quaternion.LookRotation(shootHit[i].normal));
                    GameObject impactGO2 = Instantiate(impactEffect2, shootHit[i].point, Quaternion.LookRotation(shootHit[i].normal));
                    Destroy(impactGO, 1f);
                    Destroy(impactGO2, 2f);
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