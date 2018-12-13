using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreManager : MonoBehaviour {

    public InputField iField;
    public GameObject saveScorePanel;
    public GameObject restartButton;
    public GameObject menuButton;
    public GameObject scoreBoardButton;
    Animator anim;
    private void Awake()
    {
        PlayerScoreInfo.Generate();
        anim = GameObject.Find("HUDCanvas").GetComponent<Animator>();
    }

    public void SavePlayerScore()
    {
        if(iField.text != null || iField.text != "")
        {
            //Get input player name from the Input Text Field
            PlayerScoreInfo.playerRName = iField.text;

            string newPlayerName = PlayerScoreInfo.playerRName;
            int newPlayerScore = PlayerScoreInfo.playerRScore;

            int i = CheckName(newPlayerName); //Check the position of the old player name in PlayerPrefs

            if (i > 0)   // If the name is already in the PlayerPrefs
            {
                // Check if the new Score is higher than the HighScore
                if (!PlayerPrefs.HasKey(i + "HScore") || newPlayerScore > PlayerPrefs.GetInt(i + "HScore"))
                {
                    //Save the new HighScore info into PlayerPrefs
                    PlayerPrefs.SetInt(i + "HScore", newPlayerScore);
                }
            }
            else        // If not
            {
                //Increase the number of HighScore infos that was saved in PlayerPrefs to save a new one
                i = PlayerScoreInfo.numberPlayersInfo;
                i++;
                PlayerScoreInfo.numberPlayersInfo = i;
                PlayerPrefs.SetInt("NumbPlayer", i);


                // Check if the new Score is higher than the HighScore
                if (!PlayerPrefs.HasKey(i + "HScore") || newPlayerScore > PlayerPrefs.GetInt(i + "HScore"))
                {
                    //Save the new HighScore info into PlayerPrefs
                    PlayerPrefs.SetInt(i + "HScore", newPlayerScore);
                    PlayerPrefs.SetString(i + "HScoreName", newPlayerName);
                }
            }
            restartButton.SetActive(true);
            menuButton.SetActive(true);
            scoreBoardButton.SetActive(true);
            anim.SetTrigger("ShowMenuButtons");

            //Close SaveScore panel box
            transform.parent.gameObject.SetActive(false);
        }
    }
    

    int CheckName(string pname)     // Check if pname is already in PlayerPrefs
    {
        int j = 0;
        while(j < PlayerScoreInfo.numberPlayersInfo)    //Get list info from PlayerPrefs
        {
            j++;
            if(pname.Equals(PlayerPrefs.GetString(j + "HScoreName")))
            {
                return j;
            }
        }
        return -1;
    }

}
