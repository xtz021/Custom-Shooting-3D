﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float restartDelay = 5f;
    public GameObject saveScorePanel;

    GameObject restartButton;
    GameObject menuButton;
    GameObject scoreBoardButton;
    FlameBoxCastShooting flameThrowerShooting;
    PlayerShooting rifleShooting;
    static bool usingFlameThrower;
    static bool usingRifle;
    
    Animator anim;
    float restartTimer;

    int check = 0;      // To call Coroutine

    void Awake()
    {
        anim = GetComponent<Animator>();
        restartButton = GameObject.Find("RestartButton");
        restartButton.SetActive(false);
        menuButton = GameObject.Find("MenuButton");
        menuButton.SetActive(false);
        scoreBoardButton = GameObject.Find("ScoreBoardButton");
        scoreBoardButton.SetActive(false);
        if (GameObject.Find("FlameThrower") != null)
        {
            usingFlameThrower = true;
        }
        else
            usingFlameThrower = false;
        if (GameObject.Find("GunRifle") != null)
        {
            usingRifle = true;
        }
        else
            usingRifle = false;
    }


    void Update()
    {
        if (playerHealth.getCurrentHealth() <= 0 && check == 0)
        {
            if(usingFlameThrower)
            {
                flameThrowerShooting = GameObject.Find("FlameThrower").GetComponent<FlameBoxCastShooting>();
                flameThrowerShooting.enabled = false;
            }
            if(usingRifle)
            {
                rifleShooting = GameObject.Find("GunRifle").GetComponent<PlayerShooting>();
                rifleShooting.enabled = false;
            }

            anim.SetTrigger("GameOver");

            check = 1;
        }
        if(check == 1)
        {
            check = -1;
            StartCoroutine(EnableEndGameMenu());
        }
        

    }

    IEnumerator EnableEndGameMenu()
    {
        yield return new WaitForSeconds(2);
        saveScorePanel.SetActive(true);
    }
}
