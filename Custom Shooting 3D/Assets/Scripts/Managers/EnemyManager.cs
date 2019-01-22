using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public float repeatTime = 3f;
    public Transform[] spawnPoints;
    public static int maxSpawnNumber = 20;


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, repeatTime);
    }


    void Spawn ()
    {
        if(playerHealth.getCurrentHealth() <= 0f)
        {
            return;
        }
        if (EnemyNumberManager.enemyCount < maxSpawnNumber)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            EnemyNumberManager.enemyCount++;
        }
    }
}
