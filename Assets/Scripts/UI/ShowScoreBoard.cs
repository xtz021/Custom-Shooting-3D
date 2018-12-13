﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScoreBoard : MonoBehaviour {

    List<PlayerInfoObject> listScore = new List<PlayerInfoObject>();

    public GameObject ItemListEntryPrefab;
    void Awake() {
        PlayerScoreInfo.Generate();
        
        // Get players score info list from PlayerPrefs
        int numbInfo = PlayerScoreInfo.numberPlayersInfo;
        
        if (numbInfo > 0)
        {
            int i = 0;
            while(i < numbInfo)
            {
                i++;
                PlayerInfoObject newInfo = new PlayerInfoObject(PlayerPrefs.GetString(i + "HScoreName"), 
                                                                PlayerPrefs.GetInt(i +"HScore"));
                listScore.Add(newInfo);
            }

            //Sort by score ranking
            SortingScoreRank(listScore);
        }
        for (int i = 0; i < listScore.Count; i++)
        {
            GameObject ScoreGO = (GameObject)Instantiate(ItemListEntryPrefab);
            ScoreGO.transform.SetParent(this.transform);
            ScoreGO.transform.Find("Rank").GetComponent<Text>().text = (i + 1).ToString();
            ScoreGO.transform.Find("Player Name").GetComponent<Text>().text = listScore[i].GetName();
            ScoreGO.transform.Find("Score").GetComponent<Text>().text = listScore[i].GetScore().ToString();
        }


    }

    void SortingScoreRank(List<PlayerInfoObject> ltScore)
    {
        for(int i = 0; i < ltScore.Count - 1; i++)
            for(int j = i+1; j < ltScore.Count; j++)
            {
                if(ltScore[i].GetScore() < ltScore[j].GetScore())
                {
                    PlayerInfoObject pio = ltScore[i];
                    ltScore[i] = ltScore[j];
                    ltScore[j] = pio;
                }
            }
    }
    

    private class PlayerInfoObject
    {
        string name;
        int score;

        public PlayerInfoObject(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public PlayerInfoObject()
        {
            this.name = null;
            this.score = 0;
        }

        public string GetName()
        {
            return name;
        }

        public int GetScore()
        {
            return score;
        }

        public void GetScore(int score)
        {
            this.score = score;
        }
    }


}
