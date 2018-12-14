using System;
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
        //flameThrowerShooting = GameObject.Find("Flames").GetComponent<FlameThrowerShooting>();
        flameThrowerShooting = GameObject.Find("Flames").GetComponent<FlameBoxCastShooting>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0 && check == 0)
        {
            flameThrowerShooting.enabled = false;
            anim.SetTrigger("GameOver");

            check = 1;
            //restartTimer += Time.deltaTime;

            //if (restartTimer >= restartDelay)
            //{
            //    StartCoroutine(WaitForSecs());
            //}
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
