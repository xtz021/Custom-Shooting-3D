using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameParticlesTrigger : MonoBehaviour {

    [SerializeField]
    int damagePerHit = 5;

    [SerializeField]
    float timeBetweenBullets = 0.15f;

    ParticleSystem gunParticles;
    GameObject hitTarget;
    
    public List<ParticleCollisionEvent> collisionEvents;

    List<ParticleSystem.Particle> enterList = new List<ParticleSystem.Particle>();

    void OnEnable()
    {
        gunParticles = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    //void OnParticleTrigger()
    //{
    //    int numEnter = gunParticles.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterList);

    //    if(numEnter > 0)
    //    {
    //        Destroy(hitTarget);
    //    }

    //    //if (enter)
    //    //{
    //    //    List<ParticleSystem.Particle> enterList = new List<ParticleSystem.Particle>();
    //    //    int numEnter = gunParticles.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterList);
    //    //    Debug.Log("Particle has entered Collider!!!");

    //    for (int i = 0; i < numEnter; i++)
    //    {
    //        Debug.Log("Particle has entered Collider!!!");
    //    }

    //    gunParticles.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterList);
    //    //}

    //}

    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = gunParticles.GetCollisionEvents(other, collisionEvents);
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if(enemyHealth != null)
        {
            enemyHealth.TakeFlameDamage(damagePerHit);
        }

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
