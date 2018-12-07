using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerShooting : MonoBehaviour {

    public int damagePerShot = 15;
    public float timeBetweenBullets = 0.15f;
    public float range = 12f;
    //public GameObject impactEffect;
    //public GameObject impactEffect2;


    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    float effectsDisplayTime = 1f;


    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunParticles.Stop();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            gunAudio.Play();
            gunParticles.Play();
            gunLine.enabled = true;
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            StopShootingEffect();
        }
    }


    public void StopShootingEffect()
    {
        gunLine.enabled = false;
        gunParticles.Stop();
        gunAudio.Stop();
    }

    IEnumerator DelayProjectileShooting()
    {
        yield return new WaitForSeconds(.5f);
        Shoot();
    }

    void Shoot()
    {
        
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);

                //Create fire effect on hit
                //GameObject impactGO = Instantiate(impactEffect,shootHit.point, Quaternion.LookRotation(shootHit.normal));
                //GameObject impactGO2 = Instantiate(impactEffect2, shootHit.point, Quaternion.LookRotation(shootHit.normal));
                //Destroy(impactGO, 1f);
                //Destroy(impactGO2, 2f);
            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }

        timer = 0f;
    }
}
