using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsHandler : MonoBehaviour {

    public GameObject ScoreBoardPanel;

    public void BackToMainScreen()
    {
        SceneManager.LoadScene("StartGameMenu");

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EnableScoreBoardPanel()
    {
        ScoreBoardPanel.SetActive(true);
    }

}
