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
        numberPlayersInfo = 0;
        int c = 1;
        while(PlayerPrefs.HasKey(c + "HScoreName") || PlayerPrefs.HasKey(c + "HScore"))
        {
            if (PlayerPrefs.GetString(c + "HScoreName") == null || PlayerPrefs.GetString(c + "HScoreName") == "" || PlayerPrefs.GetInt(c + "HScore")==0)
            {
                PlayerPrefs.DeleteKey(c + "HScoreName");
                break;
            }
            numberPlayersInfo = c;
            c++;
        }
        
    }
}
