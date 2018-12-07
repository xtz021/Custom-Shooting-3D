using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreInfo : MonoBehaviour {

    public static int playerRScore;
    public static string playerRName;
    public static int numberPlayersInfo;
    public static string highScoreName;
    public static int highScore;

    public static void Generate()
    {
        playerRName = null;
        playerRScore = 0;
        if(PlayerPrefs.HasKey("NumbPlayer"))
        {
            numberPlayersInfo = PlayerPrefs.GetInt("NumbPlayer");
        }
        else
        {
            numberPlayersInfo = 0;
        }
        if(PlayerPrefs.HasKey("HighScore"))         //Check if there was a highscore that was saved in PlayerPrefs
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highScore = 0;
            PlayerPrefs.SetInt("HighScore", 0);
        }
        if(PlayerPrefs.HasKey("HighScoreName"))     //Check highscore player's name that was saved in PlayerPrefs
        {
            highScoreName = PlayerPrefs.GetString("HighScoreName");
        }
        
    }
}
