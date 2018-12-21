using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour {
    
    public PlayerHealth playerHealth;
    public float spawnTime = 10f;
    public float repeatTime = 40f;
    public Transform[] spawnPoints;

    [SerializeField]
    List<GameObject> puList;


    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", spawnTime, repeatTime);
    }
	
	void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        if (PowerUpsDuration.puCount == 0)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            int i = Random.Range(0, puList.Count);
            Instantiate(puList[i], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            PowerUpsDuration.puCount++;
        }
    }
}
