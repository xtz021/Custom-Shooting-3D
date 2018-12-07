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
        enemyCount = 0;
    }
    

    void Update ()
    {
        text.text = "Enemy: " + enemyCount;
	}
}
