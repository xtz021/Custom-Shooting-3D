using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float restartDelay = 5f;
    GameObject restartButton;
    GameObject saveScorePanel;
    


    Animator anim;
    float restartTimer;


    void Awake()
    {
        anim = GetComponent<Animator>();
        restartButton = GameObject.Find("RestartButton");
        restartButton.SetActive(false);
        saveScorePanel = GameObject.Find("SaveScorePanel");
        saveScorePanel.SetActive(false);
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            StartCoroutine(EnableRestartButton());
            //restartTimer += Time.deltaTime;

            //if (restartTimer >= restartDelay)
            //{
            //    StartCoroutine(WaitForSecs());
            //}
        }
    }

    IEnumerator EnableRestartButton()
    {
        yield return new WaitForSeconds(1);
        restartButton.SetActive(true);
        saveScorePanel.SetActive(true);
    }
}
