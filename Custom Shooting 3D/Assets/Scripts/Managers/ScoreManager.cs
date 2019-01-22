using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;


    Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0;
    }


    void Update ()
    {
        PlayerScoreInfo.playerRScore = score;
        PlayerScoreInfo.playerRName = "Unknown";
        text.text = "Score: " + score;
    }
}
