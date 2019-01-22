using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour {
    
    [SerializeField]
    private PlayerHealth playerHealth;

    [SerializeField]
    private float spawnTime = 10f;

    [SerializeField]
    private float repeatTime = 40f;

    [SerializeField]
    private Transform[] spawnPoints;

    [SerializeField]
    List<GameObject> puList;


    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", spawnTime, repeatTime);
    }
	
	void Spawn()
    {
        if (playerHealth.getCurrentHealth() <= 0f)
        {
            return;
        }
        if (PowerUpsDuration.puCount == 0)
        {
            // random location index of the SpawnPoint
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            // random index of the spawning PowerUp in the PowerUps List
            int i = Random.Range(0, puList.Count);

            // spawn PowerUp at the location
            Instantiate(puList[i], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

            // Count up number of PowerUps in the map
            PowerUpsDuration.puCount++;
        }
    }
}
