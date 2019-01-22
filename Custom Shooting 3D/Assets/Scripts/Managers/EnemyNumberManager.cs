using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyNumberManager : MonoBehaviour
{

    public static int enemyCount;

    Text text;

    void Awake()
    {
        text = GetComponent <Text> ();
        enemyCount = CountEnemies();
        if(enemyCount < 0)
        {
            enemyCount = 0;
        }
    }

    int CountEnemies()
    {
        int enemyNumb = GameObject.FindGameObjectsWithTag("Enemy").Length;
        return enemyNumb;
    }
    

    void Update ()
    {
        text.text = "Enemy: " + enemyCount;
	}
}
